using Microsoft.AspNetCore.Mvc;

namespace DeveloperPortal.Controllers
{
    public class ContactComponentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
