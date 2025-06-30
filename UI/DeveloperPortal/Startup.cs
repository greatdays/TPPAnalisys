using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Application.Security;
using DeveloperPortal.Application.Services;
using DeveloperPortal.DataAccess;
using DeveloperPortal.Domain.Interfaces;
using DeveloperPortal.Serilog;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

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
            services.AddControllersWithViews();
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

            services.AddSingleton<JwtGenerator>();
            services.AddScoped<IProjectDetailService, DeveloperPortal.Application.ProjectDetail.ProjectDetailService>();
            services.AddScoped<IAngelenoAuthentication, AngelenoAuthenticationService>();
            services.AddScoped<ISignInServices, SignInServices>();
            services.AddDbContext<TPPDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("AAHR")));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login"; 
                options.Cookie.Name = ".AAHRDeveloperPortal.Auth";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Lax;
            });
            services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JwtSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["JwtSettings:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(_configuration["JwtSettings:Secret"])),
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
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=GetProjectData}/{id?}"
                );
            });
        }
    }
}
