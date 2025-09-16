using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using static System.Net.WebRequestMethods;

namespace DeveloperPortal.Extensions
{

    public class ProfileCompleteMiddleware
    {
        private readonly RequestDelegate _next;

        public ProfileCompleteMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();

            // Only protect dashboard and PlanReview pages
            if (path.StartsWith("/dashboard") || path.StartsWith("/planreview"))
            {
                var profileComplete = context.Session.GetString("ProfileComplete");
                if (string.IsNullOrEmpty(profileComplete) || profileComplete != "true")
                {
                    context.Response.Redirect("/Account/MyAccount");
                    return;
                }
            }

            await _next(context);
        }
    }

}
