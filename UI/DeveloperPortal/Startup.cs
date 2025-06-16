using System.Configuration;
using DeveloperPortal.Application.ProjectDetail;
using DeveloperPortal.Application.ProjectDetail.Implementation;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Repository;
using DeveloperPortal.Serilog;
using Microsoft.EntityFrameworkCore;

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
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.Name = ".AAHRDeveloperPortal.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDbContext<AAHREntities>(options =>
           options.UseSqlServer(_configuration.GetConnectionString("AAHR")));
            services.AddDbContext<AAHREntitiesHelper>(options =>
           options.UseSqlServer(_configuration.GetConnectionString("AAHR")));

            services.AddHttpClient();
            services.AddDataAccess();
            services.AddScoped<IAppConfigService, AppConfigService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IApnpinService, ApnpinService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProjectDetailService, ProjectDetailService>();

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

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // Correctly map Razor Pages
                endpoints.MapControllerRoute(name: "default",
               pattern: "{controller=Dashboard}/{action=GetProjectData}");
            });
               // app.MapRazorPages();

            //app.MapControllerRoute(name: "default",
              //  pattern: "{controller=DashboardService}/{action=GetProjectData}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            
        }
    }
}
