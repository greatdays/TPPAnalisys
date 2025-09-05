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



            services.AddSingleton<JwtGenerator>();
            services.AddScoped<IAngelenoAuthentication, AngelenoAuthenticationService>();
            services.AddScoped<ISignInServices, SignInServices>();
            services.AddDbContext<TPPDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("AAHR")));

            services.AddAuthentication(options =>
            {
                // These defaults will be used unless you override per‑attribute or per‑call
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.Cookie.Name = ".AAHRDeveloperPortal.Auth";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Lax;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JwtSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["JwtSettings:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                                                 Convert.FromBase64String(
                                                   _configuration["JwtSettings:Secret"])),
                    ValidateIssuerSigningKey = true
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
            app.UsePathBase("/AcHP.API");
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
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
