using ComCon.DataAccess.Models.Helpers;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Application.Security;
using DeveloperPortal.DataAccess;
using DeveloperPortal.DataAccess.Entity.EntityModels;
using DeveloperPortal.Domain.IDM;
using DeveloperPortal.Domain.Interfaces;
using DeveloperPortal.Models.IDM;
using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Cryptography;
using UserSession = DeveloperPortal.Models.IDM.UserSession;

namespace DeveloperPortal.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private readonly ILogger<AccountController> _logger;
        private readonly IAngelenoAuthentication _angelenoAuthentication;
        private readonly ISignInServices _signInService;
        private readonly IDashboardService _dashboardService;

        private readonly JwtGenerator _jwtGenerator;
        private readonly TPPDbContext _db;

        // Here we are using Dependency Injection to inject the Configuration object
        public LoginController(IConfiguration config, ILogger<AccountController> logger, IDashboardService dashboardService,
            IAngelenoAuthentication angelenoAuthentication, ISignInServices signInService, JwtGenerator jwtGenerator)
        {
            _logger = logger;
            _config = config;
           _dashboardService = dashboardService;
            _angelenoAuthentication = angelenoAuthentication;
            _signInService = signInService;
            _jwtGenerator = jwtGenerator;
        }

        // test user: tsony11@yopmail.com

        /// <summary>
        /// POST /Login/LoginSql
        /// </summary>
        [HttpPost("/Login/LoginSql")]
        public async Task<IActionResult> LoginSql([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Email and password are required." });

            AuthenticateResponse authResponse;
            try
            {
                authResponse = await _signInService.AuthenticateSqlAsync(model);
            }
            catch (UnauthorizedAccessException uex)
            {
                _logger.LogWarning(uex, "LoginSql failed");
                return BadRequest(new { success = false, message = uex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error in LoginSql");
                return BadRequest(new { success = false, message = "Could not reach IDM service." });
            }

            await _signInService.SignInAsync(authResponse, HttpContext, model.RememberMe);
            return Ok(new { success = true, redirectUrl = "/dashboard" });
        }
    

        /// <summary>
        /// Login based on AppSetting 'AuthenticationMode'
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="tabname"></param>
        /// <param name="jwtToken"></param>
        /// <returns></returns>
        public ActionResult Login(string userName = null, string tabname = null, string jwtToken = null)
        {
            UserSession userSession = UserSession.GetUserSession(HttpContext);
            if (string.IsNullOrEmpty(userSession.UserName))
            {
                return UserLogin(userName, tabname);
            }
            return RedirectToAction("GetProjectData", "Dashboard");
        }

        [HttpGet("/Login/AngelenoLogin")]
        public async Task<IActionResult> AngelenoLogin()
        {
            string guid = await _angelenoAuthentication.GenerateSessionID();

            HttpContext.Session.SetString("AngelenoState", guid);

            string redirectUrl =
                _config["Angeleno:BaseUrl"] +
                _config["Angeleno:AuthUrl"] +
                _config["Angeleno:RedirectUrl"] +
                guid;

            return Redirect(redirectUrl);
        }

        [HttpGet("/login/angelenocallback")]
        public async Task<IActionResult> AngelenoCallback([FromQuery] string guid,
                                 [FromQuery(Name = "email")] string email,
                                 [FromQuery(Name = "firstName")] string firstName,
                                 [FromQuery(Name = "lastName")] string lastName)
        {
            var originalGuid = HttpContext.Session.GetString("AngelenoState");
            HttpContext.Session.Remove("AngelenoState");
            if (originalGuid != guid)
                return BadRequest("Invalid state");

            var authResponse = await _signInService.AuthenticateAngelenoAsync(email, firstName, lastName);

            await _signInService.SignInAsync(authResponse, HttpContext, false);

            return Redirect("/dashboard");
        }


        #region Login for windows authetication
        /// <summary>
        ///  User login for windows authetication
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public ActionResult UserLogin(string UserName = null, string tabname = null)
        {
            /* Get Logon User */
            if (string.IsNullOrEmpty(UserName)) // UserName is null or empty only on LIVE MODE
            {
                UserName = GetLogonUser();
            }

            string applicationName = _config["AppSettings:Application"].ToString();
            string applicationURL = _config["AppSettings:ApplicationURL"].ToString();

            if (!string.IsNullOrEmpty(UserName))
            {
                User objUser = new User
                {
                    UserName = UserName,
                    Provider = "Active Directory"
                };
                string idmApiURL = _config["IDMSettings:IDMPath"].ToString();
                AuthenticateResponse authenticateResponse = IDMServiceClient.AuthenticateUser(objUser, idmApiURL);

                if ((null != authenticateResponse) && (authenticateResponse.UserId > 0))
                {
                    var userDetail = authenticateResponse.ApplicationDetail.FirstOrDefault(a => a.AppKey.Equals(applicationName));
                    if (userDetail != null)
                    {
                        //Create the identity for the user  
                        var identity = new ClaimsIdentity(new[] {
                                        new Claim(ClaimTypes.Name, authenticateResponse.Username),
                                        new Claim(ClaimTypes.Role,string.Join(",", userDetail.Roles))
                                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        UserSession.SetUserInSession(HttpContext, UserSession.AssignValues(HttpContext, authenticateResponse, null, applicationName));

                        return RedirectToAction("GetProjectData", "Dashboard");
                    }
                }
            }

            return Redirect($"{_config["IDMSettings:CentralIDMURL"]}&returnUrl={applicationURL}");
        }
        #endregion

        /// <summary>
        /// POST /Account/RefreshToken
        /// Issues a new access token using the refresh token stored in the cookie.
        /// </summary>
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            if (!Request.Cookies.TryGetValue("TPP_RefreshToken", out var refreshToken))
                return Unauthorized();

            var dbToken = await _db.RefreshTokens
                .SingleOrDefaultAsync(r => r.Token == refreshToken && !r.IsRevoked);

            if (dbToken == null || dbToken.ExpiresOn < DateTime.UtcNow)
                return Unauthorized();

            // Revoke the used refresh token
            dbToken.IsRevoked = true;
            _db.RefreshTokens.Update(dbToken);

            // Optionally rotate the refresh token
            var newRefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            var newExpiresOn = DateTime.UtcNow.AddDays(30);
            _db.RefreshTokens.Add(new RefreshToken
            {
                UserId = dbToken.UserId,
                Token = newRefreshToken,
                ExpiresOn = newExpiresOn,
                CreatedOn = DateTime.UtcNow
            });

            await _db.SaveChangesAsync();

            // Issue a new access token
            var user = await _db.TPPUsers.FindAsync(dbToken.UserId);
            var roles = new[] { "Guest" }; // or fetch actual roles
            var jwt = _jwtGenerator.CreateToken(user.UserId, user.Email, roles);

            // Set the new refresh token cookie
            Response.Cookies.Append(
                "TPP_RefreshToken", newRefreshToken,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = newExpiresOn
                }
            );

            return Ok(new { token = jwt });
        }

        /// <summary>
        /// authenticate idm user based on token.
        /// </summary>
        /// <param name="jwtToken"></param>
        /// <param name="tabname"></param>
        /// <returns>
        /// Redirect to landing page if authentication success.
        /// </returns>
        /// 
        public async Task<ActionResult> ValidateToken(string jwtToken, string tabname)
        {
            UserSession userSession = UserSession.GetUserSession(HttpContext);

            string applicationName = _config["AppSettings:Application"].ToString();
            string applicationURL = _config["AppSettings:ApplicationURL"].ToString();

            if (!string.IsNullOrEmpty(jwtToken))
            {
                //Common.Common.SetSession("JWTToken", jwtToken);
                // authenticate user token from api.             
                AuthenticateResponse authenticateResponse = IDMServiceClient.ValidateToken(jwtToken,
                    _config["AppSettings:JwtAccessCode"].ToString(),
                    _config["IDMSettings:SourceApp"].ToString(),
                    _config["IDMSettings:TargetApp"].ToString(),
                    _config["IDMSettings:IDMPath"].ToString());

                if ((null != authenticateResponse) && (authenticateResponse.UserId > 0))
                {
                    var userDetail = authenticateResponse.ApplicationDetail.FirstOrDefault(a => a.AppKey.Equals(applicationName));
                    if (userDetail != null)
                    {
                        if (!userDetail.Roles.Contains("Property Developer"))
                        {
                            return RedirectToAction("RoleError", "Account");
                        }
                       
                        var claims = new[]
                            {
                                new Claim("UserId", authenticateResponse.UserId.ToString()),
                                //new Claim("UserName", authenticateResponse.Username.ToString()),
                                new Claim(ClaimTypes.Name, authenticateResponse.Username),
                                new Claim(ClaimTypes.Role, string.Join(",", userDetail.Roles))
                            };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            principal,
                            new AuthenticationProperties
                            {
                                IsPersistent = true, // Session cookie: dies on browser close
                                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(45)
                            });




                        UserSession.SetUserInSession(HttpContext, UserSession.AssignValues(HttpContext, authenticateResponse, null, applicationName));
                        var data = _dashboardService.GetUserContactIdentifierData();

                        if (data != null)
                        {
                            HttpContext.Session.SetString("ProfileComplete", "true");
                            return RedirectToPage("/Dashboard");
                        }
                        else 
                        {
                            HttpContext.Session.SetString("ProfileComplete", "false");
                            return RedirectToPage("/Account/MyAccount");

                        }
                        //return RedirectToPage("/Dashboard");
                    }
                }
            }
            else if (null != HttpContext.Session && null != userSession && userSession.UserID > 0)
            {
                return RedirectToAction("Login", "Home");
            }

            return Redirect($"{_config["IDMSettings:CentralIDMURL"]}&returnUrl={applicationURL}");
        }

        /// <summary>
        /// Action for log off from application.
        /// </summary>
        /// <returns>
        /// Returns to login view.
        /// </returns>
        public ActionResult LogOff()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            string applicationURL = _config["AppSettings:ApplicationURL"].ToString();

            // return Redirect($"{_config["IDMSettings:CentralIDMURL"]}&returnUrl={applicationURL}");
            return Redirect(applicationURL);
        }

        #region Authenticate Windows User
        /* Function To Authenticate Windows User */
        /// <summary>
        ///  Get log on user for windows authetication
        /// </summary>
        /// <returns></returns>
        public string GetLogonUser()
        {
            /*Get Windows User Name*/
            System.Security.Principal.IIdentity id = HttpContext.User.Identity;
            string UserName = id.Name;
            if (id.IsAuthenticated)
            {
                int startIdx;
                if ((startIdx = UserName.IndexOf(@"\")) > 0)
                {
                    UserName = UserName.Substring(startIdx + 1);
                }
            }
            return UserName;
        }
        #endregion

        [HttpGet]
        [Authorize]
        public ActionResult MyAccount()
        {
            return View();
        }


        #region "Change Password"

        /// <summary>
        /// GET : Change Password
        /// </summary>
        /// <returns>Change Password</returns>
        [HttpGet]
        [Authorize]
        public ActionResult ChangePassword()
        {
            ChangePasswordModel changepasswordModel = new ChangePasswordModel();
            changepasswordModel.UserName = UserSession.GetUserSession(HttpContext).UserName == null ? "" : UserSession.GetUserSession(HttpContext).UserName;
            return PartialView(changepasswordModel);
        }

        /// <summary>
        /// POST : Change Password
        /// </summary>
        /// <returns>Change Password</returns>
        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordModel changepasswordModel)
        {
            JsonData<JsonStatus> data = new JsonData<JsonStatus>(new JsonStatus());

            if (ModelState.IsValid)
            {
                string Status = IDMServiceClient.ChangePassword(changepasswordModel.UserName, changepasswordModel.CurrentPassword, changepasswordModel.NewPassword, _config["IDMSettings:IDMPath"].ToString(), _config["AppSettings:AppKey"].ToString());
                if (Status == null || Status != "")
                {
                    if (Status.Contains("IDM106"))
                    {
                        data.Result.Status = false;
                    }
                    else
                    {
                        data.Result.Status = true;
                    }
                }
                else
                {
                    data.Result.Status = false;
                }
                data.Result.Data = new { ErrorMsg = Status };
                ModelState.Clear();
            }
            return Json(data);
        }
        #endregion
    }
}
