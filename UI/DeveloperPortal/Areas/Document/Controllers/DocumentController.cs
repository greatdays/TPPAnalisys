using Microsoft.AspNetCore.Mvc;

namespace DeveloperPortal.Areas.Document.Controllers
{
    [Area("Document")]
    public class DocumentController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


    }
}
