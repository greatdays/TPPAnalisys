using System.Configuration;
using DeveloperPortal.Application.DMS.Implementation;
using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.Application.ProjectDetail;
using DeveloperPortal.Application.ProjectDetail.Implementation;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Application.Security;
using DeveloperPortal.Application.Services;
using DeveloperPortal.DataAccess;
using DeveloperPortal.Domain.Interfaces;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity;
using DeveloperPortal.DataAccess.Repository;
using DeveloperPortal.Serilog;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using DeveloperPortal.Application.Notification.Interface;
using DeveloperPortal.Application.Notification.Implementation;
using DeveloperPortal.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using DeveloperPortal.Models.IDM;

namespace DeveloperPortal
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(45);
                options.IOTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.Name = ".AAHRDeveloperPortal.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.Cookie.IsEssential = true;
            });
            services.AddDbContext<AAHREntities>(options =>
           options.UseSqlServer(_configuration.GetConnectionString("AAHR")));
            services.AddDbContext<AAHREntitiesHelper>(opts =>
    opts.UseSqlServer(_configuration.GetConnectionString("AAHR")));


            services.AddScoped<AAHREntitiesHelper>();
            services.AddDataAccess();
            services.AddScoped<IAppConfigService, AppConfigService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IApnpinService, ApnpinService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProjectDetailService, ProjectDetailService>();
            services.AddScoped<IUnitImportService, UnitImportService>();
            services.AddScoped<IBuildingIntakeService, BuildingIntakeService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IFloorPlanTypeService, FloorPlanTypeService>();
            services.AddScoped<ISendNotificationEmail, SendNotificationEmailService>();
            services.AddScoped<IFundingSourceService, FundingSourceService>();
            services.AddScoped<IDevelopmentTeamService, DevelopmentTeamService>();
            services.AddScoped<IContactIdentifiersService, ContactIdentifiersService>();
            


            services.AddSingleton<JwtGenerator>();
            services.AddScoped<IAngelenoAuthentication, AngelenoAuthenticationService>();
            services.AddScoped<ISignInServices, SignInServices>();
            services.AddDbContext<TPPDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("AAHR")));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/account/Login"; // or your login page
                options.Cookie.Name = ".AAHRDeveloperPortal.Auth";
                options.Cookie.Path = "/";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Lax;

                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // or whatever session length

                // ✅ Make cookie a session cookie (dies when browser closes)
                options.Cookie.IsEssential = true;
                options.Cookie.MaxAge = null; // null = session cookie
                options.Cookie.Expiration = null;
                options.SlidingExpiration = false;
                // ✅ Revalidate principal on every request
                options.Events = new CookieAuthenticationEvents
                {
                    OnValidatePrincipal = async context =>
                    {
                        try
                        {
                            var user = context.Principal;
                            var httpContext = context.HttpContext;

                            // 1️⃣ Reject if no identity or not authenticated
                            if (user?.Identity == null || !user.Identity.IsAuthenticated)
                            {
                                context.RejectPrincipal();
                                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                                return;
                            }

                            
                            var sessionUser = UserSession.GetUserSession(httpContext);
                            if (sessionUser == null || string.IsNullOrEmpty(sessionUser.UserName))
                            {
                                context.RejectPrincipal();
                                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                                return;
                            }

                            // 3️⃣ Validate required claims
                            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == "UserId" && !string.IsNullOrEmpty(c.Value));
                            if (userIdClaim == null || userIdClaim.Value == "0")
                            {
                                context.RejectPrincipal();
                                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                                return;
                            }

                            // 4️⃣ Validate cookie expiration
                            var expiresUtc = context.Properties?.ExpiresUtc;
                            if (expiresUtc != null && expiresUtc <= DateTimeOffset.UtcNow)
                            {
                                context.RejectPrincipal();
                                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                                return;
                            }

                            // ✅ All checks passed, keep the user authenticated
                        }
                        catch
                        {
                            // On any exception, reject principal and sign out
                            context.RejectPrincipal();
                            await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                        }
                    }
                };
            });
            

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            //app.UsePathBase("/AcHP.API");
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            //app.UseMiddleware<ProfileCompleteMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Dashboard}/{action=GetProjectData}");
                endpoints.MapRazorPages(); // Correctly map Razor Pages
            });


            // app.MapRazorPages();

            //app.MapControllerRoute(name: "default",
            //  pattern: "{controller=DashboardService}/{action=GetProjectData}");
        }
    }
}
