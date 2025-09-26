using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IO;
using System.Security.Claims;

namespace DeveloperPortal.Extensions
{
    public class AuthCookieMiddleware
    {

        private readonly RequestDelegate _next;
        private IConfiguration _config;
        public AuthCookieMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();
            var appUrl = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}{context.Request.Path}".ToLower();
            var homeUrl = _config["AppSettings:ApplicationURL"]?.ToLower();
            var loginUrl = $"{_config["IDMSettings:CentralIDMURL"]}&returnUrl={_config["AppSettings:ApplicationURL"]}";

            var result = await context.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result?.Principal != null)
            {
                context.User = result.Principal; // set authenticated user
            }

            if (appUrl.Contains("login/validatetoken"))
            {
                await _next(context);
                
            }

            if (!context.User.Identity.IsAuthenticated)
            {
                if (appUrl == homeUrl) // If request is for home page
                {
                    await _next(context);
                   
                }
                else // If request is for any other page
                {
                    context.Response.Redirect(loginUrl);
                    return;
                }
            }

            if (path.StartsWith("/dashboard") || path.StartsWith("/planreview"))
            {
                var profileComplete = context.Session.GetString("ProfileComplete");
                if (string.IsNullOrEmpty(profileComplete) || profileComplete != "true")
                {
                    context.Response.Redirect("/Account/MyAccount");
                    return;
                }
            }

            // 3. If authenticated → continue request pipeline
            await _next(context);
        }



    }
}
