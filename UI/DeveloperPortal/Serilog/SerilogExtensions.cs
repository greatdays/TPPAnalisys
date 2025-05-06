
using DeveloperPortal.Serilog;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace UNITe.AuthorisationService.WebAPI.Serilog
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
