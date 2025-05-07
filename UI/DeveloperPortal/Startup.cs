using DeveloperPortal.Serilog;

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
              //  pattern: "{controller=Dashboard}/{action=GetProjectData}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            
        }
    }
}
