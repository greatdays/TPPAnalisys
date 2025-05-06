using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using DeveloperPortal.Application;
using DeveloperPortal.Application.ProjectDetail.Interface;

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
            //builder.Services.addconf
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.Name = ".AAHRDeveloperPortal.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddScoped<IProjectDetailService, DeveloperPortal.Application.ProjectDetail.ProjectDetailService>();
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
              //  pattern: "{controller=Dashboard}/{action=GetProjectData}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            
        }
    }
}
