using Microsoft.AspNetCore.Mvc;

namespace DeveloperPortal.Controllers
{
    public class AccountController : Controller
    {
        private IConfiguration _config;
        // Here we are using Dependency Injection to inject the Configuration object
        public AccountController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Login(string ReturnUrl)
        {
            return Redirect($"{_config["IDMSettings:CentralIDMURL"]}&returnUrl={_config["ThisApplication:ApplicationURL"]}{ReturnUrl}");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
