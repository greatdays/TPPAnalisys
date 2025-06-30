using Castle.Core.Logging;
using DeveloperPortal.Application.Security;
using DeveloperPortal.DataAccess;
using DeveloperPortal.DataAccess.Entity.EntityModels;
using DeveloperPortal.Domain.IDM;
using DeveloperPortal.Domain.Interfaces;
using DeveloperPortal.Models.IDM;
using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Cryptography;

namespace DeveloperPortal.Application.Services
{
    public class SignInServices : ISignInServices
    {
        private readonly IConfiguration _config;
        private readonly JwtGenerator _jwtGenerator;
        private readonly TPPDbContext _db;

        private const string AppKey = "AAHRDeveloperPortal";

        public SignInServices (IConfiguration config, TPPDbContext db, JwtGenerator jwtGenerator)
        {
            _config = config;
            _db = db;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<AuthenticateResponse> AuthenticateSqlAsync(LoginModel model)
        {
            var userToAuth = new User
            {
                AppKey = AppKey,
                UserName = model.Username.Trim(),
                Password = model.Password.Trim(),
                Provider = "SQL"
            };

            string idmApiBase = _config["IDMSettings:IDMPath"];
            if (string.IsNullOrEmpty(idmApiBase))
                throw new InvalidOperationException("IDM path not configured");

            AuthenticateResponse authResponse;
            try
            {
                authResponse = await Task.Run(() =>
                    IDMServiceClient.AuthenticateUser(userToAuth, idmApiBase));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Error calling IDM");
                throw;
            }

            if (authResponse == null || authResponse.UserId <= 0)
                throw new UnauthorizedAccessException(
                    authResponse?.ErrorMessage ?? "Invalid credentials");

            // ensure user has access to TPP
            var detail = authResponse.ApplicationDetail
                            .FirstOrDefault(d => d.AppKey == AppKey);
            if (detail == null)
                throw new UnauthorizedAccessException("Not authorized for TPP");

            var localUser = await _db.TPPUsers
                .SingleOrDefaultAsync(u => u.Email == authResponse.Email);

            if (localUser == null)
            {
                localUser = new TPPUser
                {
                    Email = authResponse.Email,
                    Provider = "SQL",
                    FirstName = authResponse.Firstname,
                    LastName = authResponse.Lastname,
                    CreatedOn = DateTime.UtcNow
                };
                _db.TPPUsers.Add(localUser);
                await _db.SaveChangesAsync();
            }
            else if (localUser.Provider != "SQL")
            {
                // If they existed via Angeleno before, update provider or keep both?
                localUser.Provider = "SQL";
                await _db.SaveChangesAsync();
            }

            return authResponse;
        }

        public async Task<AuthenticateResponse> AuthenticateAngelenoAsync(string email, string first, string last)
        {
            var user = await _db.TPPUsers
                                .SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                user = new TPPUser
                {
                    Email = email,
                    FirstName = first,
                    LastName = last,
                    CreatedOn = DateTime.UtcNow, 
                    Provider = "Angeleno"
                };
                _db.TPPUsers.Add(user);
                await _db.SaveChangesAsync();
            }

            var roles = new[] { "Guest", "NAC", "General Contractor", "Property Developer", "Architect" };
            var jwt = _jwtGenerator.CreateToken(
                            userId: user.UserId,
                            email: user.Email,
                            roles: roles);

            var detail = new ApplicationDetail
            {
                ApplicationId = 29,
                AppKey = "AAHRDeveloperPortal",
                AppName = "AAHRDeveloperPortal",
                ApplicationURL = "/dashboard",   
                JWTAccessCode = _config["ThisApplication:JwtAccessCode"],
                JWTToken = jwt,      
                Roles = roles.ToList(),
                ConnectionString = _config["AAHR"],
                Attributes = null,
                IsLocked = false,
                IsAppAssociated = true
            };

            // 3) Return the AuthenticateResponse with the JWTToken too
            return new AuthenticateResponse
            {
                UserId = user.UserId,
                Username = email,
                Fullname = $"{user.FirstName} {user.LastName}".Trim(),
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                Provider = "Angeleno",
                LastLogOn = DateTime.UtcNow,
                ApplicationDetail = new List<ApplicationDetail> { detail },
                JWTToken = jwt,           // ← also set top‐level if you use it
                IsAppAssociated = true,
                isAuthenticated = true
            };
        }

        public async Task SignInAsync(AuthenticateResponse authResponse, HttpContext httpContext, bool rememberMe)
        {
            var local = await _db.TPPUsers
                .SingleOrDefaultAsync(u => u.Email == authResponse.Email); 
            if (local == null)
            {
                local = new TPPUser
                {
                    Email = authResponse.Email,
                    Provider = "SQL",
                    FirstName = authResponse.Firstname,
                    LastName = authResponse.Lastname,
                    CreatedOn = DateTime.UtcNow
                };
                _db.TPPUsers.Add(local);
                await _db.SaveChangesAsync();
            }
            authResponse.UserId = local.UserId;

            var detail = authResponse.ApplicationDetail.First(d => d.AppKey == AppKey);
            var roles = detail.Roles ?? new List<string>();

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, authResponse.Username),
                new Claim(ClaimTypes.Role, string.Join(",", roles))
            }, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal
            );

            string accessToken = _jwtGenerator.CreateToken(
                userId: authResponse.UserId,
                email: authResponse.Email,
                roles: roles
            );
            detail.JWTToken = accessToken;
            authResponse.JWTToken = accessToken;

            await _db.RefreshTokens
                .Where(t => t.UserId == local.UserId && !t.IsRevoked)
                .ExecuteUpdateAsync(u => u.SetProperty(t => t.IsRevoked, true));
            await _db.SaveChangesAsync();

            string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            DateTime? refreshExpires = rememberMe
                            ? DateTime.UtcNow.AddDays(30)
                            : (DateTime?)null;

            var dbToken = new RefreshToken
            {
                UserId = local.UserId,
                Token = refreshToken,
                ExpiresOn = refreshExpires ?? DateTime.UtcNow.AddHours(8),
                CreatedOn = DateTime.UtcNow,
                IsRevoked = false
            };
            _db.RefreshTokens.Add(dbToken);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var baseEx = ex.GetBaseException();
                Console.WriteLine($"DbUpdateException: {baseEx.Message}");
                throw;
            }

            var cookieOpts = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            if (refreshExpires.HasValue) {
                cookieOpts.Expires = refreshExpires.Value;
            }
            httpContext.Response.Cookies.Append("TPP_RefreshToken", refreshToken, cookieOpts);

            var session = UserSession.AssignValues(
                httpContext,
                authResponse,
                null,    
                AppKey
            );
            UserSession.SetUserInSession(httpContext, session);
        }
    }
}
