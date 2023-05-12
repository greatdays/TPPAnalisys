using DeveloperPortal.Models.PlanReview;
using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace DeveloperPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanReviewController : Controller
    {
        private IConfiguration _config;
        // Here we are using Dependency Injection to inject the Configuration object
        public PlanReviewController(IConfiguration config)
        {
            _config = config;
        }
        public IConfigurationRoot Configuration { get; set; }
        public List<string?> DashboardData { get; private set; }

        // GET: api/<DashboardController>
        [HttpGet]
        public JsonResult GetFoderData()
        {
            string folderName = Request.Form["folderName"].FirstOrDefault();
            string applicationName = _config["ThisApplication:Application"].ToString();
            string applicationURL = _config["ThisApplication:ApplicationURL"].ToString();
            var url = Configuration.GetSection("AAHRApiSettings:URL").Value;
            var googleDrive = Configuration.GetSection("AAHRApiSettings:GoogleDrive").Value;
            var folderModel = AAHRServiceClient.GetFolderData(url, googleDrive, folderName);
            return Json(folderModel);
        }
    }
}
