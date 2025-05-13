using Serilog;
using Serilog.Exceptions;

namespace DeveloperPortal.Serilog
{
    public static class SerilogExtensions
    {
        
        public static IHostBuilder ConfigureSerilog(this IHostBuilder builder)
        {
            return builder.UseSerilog((context, services, configuration) =>
            {
                configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .Enrich.WithExceptionDetails()
                    .Enrich.FromLogContext();

            });
        }

    }
}
