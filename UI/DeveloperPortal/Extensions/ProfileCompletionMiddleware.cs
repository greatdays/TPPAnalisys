using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using static System.Net.WebRequestMethods;

namespace DeveloperPortal.Extensions
{

    public class ProfileCompleteMiddleware
    {
        private readonly RequestDelegate _next;
        private IConfiguration _config;
        public ProfileCompleteMiddleware(RequestDelegate next, IConfiguration config    )
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();


            //var userName = UserSession.GetUserSession(context).UserName;
            // if (path.Equals("/"))
            //{
            //    _next(context);
            //    //context.Response.Redirect($"{_config["AppSettings:ApplicationURL"]}");
            //}
            //else if(userName == null)
            //{
            //    context.Response.Redirect($"{_config["IDMSettings:CentralIDMURL"]}&returnUrl={_config["AppSettings:ApplicationURL"]}");
            //    // return RedirectToAction("Login", "Home");
            //}
            
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
