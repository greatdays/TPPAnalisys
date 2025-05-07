using System.Text.Json;
using Serilog;

namespace DeveloperPortal.Serilog
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IDiagnosticContext _diagnosticContext;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IDiagnosticContext diagnosticContext)
        {
            _next = next;
            _logger = logger;
            _diagnosticContext = diagnosticContext;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // continue down the pipeline
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    //Added detail level inner Exception
                    _logger.LogError("Inner Exception details : {ExceptionType} {ExceptionMessage}",
                    ex.InnerException.GetType().ToString(), ex.InnerException.Message);
                }
                else
                {
                    //added  Exception Details only 
                    var routeData = context.GetRouteData();
                    var controller = routeData?.Values["controller"]?.ToString();
                    var action = routeData?.Values["action"]?.ToString();

                    _logger.LogError(ex,"Unhandled exception in {Controller}.{Action}: {Message}\nStackTrace:\n{StackTrace}",
                        controller, action, ex.Message, ex.StackTrace);
                    _logger.LogError("Exception details : {ExceptionType} {ExceptionMessage}",
                   ex.GetType().ToString(), ex.Message);

                }

                //context.Response.WriteAsync("Error Occured");
            }
        }
    }
}
