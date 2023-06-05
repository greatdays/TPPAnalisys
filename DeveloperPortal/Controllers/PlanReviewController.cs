using DeveloperPortal.Models.PlanReview;
using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Authorization;
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
        private string _BaseURL = "";
        private string _GoogleDriveId = "";
        // Here we are using Dependency Injection to inject the Configuration object
        public PlanReviewController(IConfiguration config)
        {
            _config = config;
            _BaseURL = _config["AAHRApiSettings:URL"].ToString();
            _GoogleDriveId = _config["AAHRApiSettings:GoogleDrive"].ToString();
        }
        public IConfigurationRoot Configuration { get; set; }
        public List<string?> DashboardData { get; private set; }

        // GET: api/<DashboardController>
        [HttpGet]
        [Route("GetFoderData")]
        public JsonResult GetFoderData(string folderName)
        {

            var folderModel = AAHRServiceClient.GetFolderData(_BaseURL, _GoogleDriveId, folderName);
            return Json(folderModel);
        }

        [HttpGet]
        [Route("CreateFolder")]
        public JsonResult CreateFolder(string folderName, string parentFolderName)
        {
            var folderPath = AAHRServiceClient.CreateFolder(_BaseURL, _GoogleDriveId, folderName, parentFolderName);
            return Json(folderPath);
        }

        [HttpPost]
        [Route("UploadFile")]
        public JsonResult UploadFile(string folderName, IFormFile files)
        {
            var folderPath = AAHRServiceClient.UploadFiel(_BaseURL, _GoogleDriveId, folderName, files);
            return Json(folderPath);
        }
    }
}
