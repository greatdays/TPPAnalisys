using DeveloperPortal;
using DeveloperPortal.Serilog;
using Serilog;
/*
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
//builder.Services.addconf
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.Name = ".AAHRDeveloperPortal.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

/*builder.Services.AddScoped(client => 
    new HttpClient { BaseAddress = new Uri("http://43svc/AAHRDev.Api") }
);**\


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.MapControllerRoute(name: "default",
    pattern: "{controller=DashboardService}/{action=GetProjectData}");

app.Run();
*/

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureSerilog()
        .ConfigureAppConfiguration((hostingContext, config) =>
         {
             var env = hostingContext.HostingEnvironment;

             config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

             config.AddEnvironmentVariables(); // Optional but useful for Docker/Cloud
         })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder
                .UseStartup<Startup>();

        }).ConfigureLogging((logging) =>
        {
            logging.AddSerilog();
                
        });


}

