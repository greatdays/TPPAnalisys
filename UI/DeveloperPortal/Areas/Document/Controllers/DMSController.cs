using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using DeveloperPortal.Areas.Document.Models;
using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.Domain.Dashboard;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Application.DMS.Implementation;
using DeveloperPortal.ServiceClient;
using DeveloperPortal.Models.PlanReview;
using Microsoft.AspNetCore.StaticFiles;
using DeveloperPortal.Application.ProjectDetail.Interface;
using System.Net.Http.Headers;
using DeveloperPortal.Application.Notification.Interface;
using DeveloperPortal.Domain.Notification;
using DeveloperPortal.Domain.Resources;
using System.Threading.Tasks;
using HCIDLA.ServiceClient.DMS;
using Microsoft.AspNetCore.Hosting;
using System.Net.Mime;


namespace DeveloperPortal.Areas.Document.Controllers
{
    [Area("Document")]
    public class DMSController : Controller
    {
        private IConfiguration _config;
        private readonly IDocumentService _documentService;
        private IProjectDetailService _projectDetailService;
        private ISendNotificationEmail sendNotificationEmail;
        private string _BaseURL = "", _GoogleDriveId = "",_AAHP_Google_UName="",AAHP_Google_Pwd="";
        private bool _IsCreatedGoogleDriveFolder = false;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DMSController(IDocumentService documentService, IProjectDetailService projectDetailService, 
            IConfiguration config, ISendNotificationEmail _sendNotificationEmail, IWebHostEnvironment webHostEnvironment)
        {
            this._config = config;
            this._documentService= documentService;
            this._projectDetailService = projectDetailService;
            this._BaseURL = _config["AAHRApiSettings:URL"].ToString();
            this._GoogleDriveId = _config["AAHRApiSettings:GoogleDrive"].ToString();
            this._IsCreatedGoogleDriveFolder = true;//Convert.ToBoolean(_config["AAHRApiSettings:IsCreatedGoogleDriveFolder"].ToString());
            this.sendNotificationEmail= _sendNotificationEmail;
            this._AAHP_Google_UName = _config["LAHD:username"].ToString();
            this.AAHP_Google_Pwd = _config["LAHD:password"].ToString();
            this._webHostEnvironment = webHostEnvironment;

        }

        [HttpGet]
        [Route("Document/DMS/GetFilesById")]
        public async Task<IActionResult> GetFilesById(int caseId, int controlViewModelId)
        {
           /* NotificationCredential notificationCredential = sendNotificationEmail.GetNotificationCrdential("AcHPIntranet");

            List<NotificationInfoModel> notificationInfoModels =  sendNotificationEmail.GetNotificationInfo("email to applicant signing up",null, "ananthakrishnan.mohandas@lacity.org", "", "");

           
            await sendNotificationEmail.SendMail(notificationInfoModels, notificationCredential, "SignUp");*/
                //sendNotification.SendMail(this.notificationInfoList, new NotificationCredential(), emailAction);
           

            var model = new DMSModel
            {
                FolderModel = await _documentService.GetAllDocumentsBasedOnProjectId(caseId),
                ProjectId = caseId
            };

            return View("~/Areas/Document/Views/DMS/DMSView.cshtml", model);
        }

        [HttpPost]
        [Route("CreateFolder")]
        public JsonResult CreateFolder(string folderName, string parentFolderName)
        {
            var folderPath = AAHRServiceClient.CreateFolder(_BaseURL, _GoogleDriveId, folderName, parentFolderName);
            return Json(folderPath);
        }
        [HttpPost]
        [Route("UploadFile")]
        public async Task<JsonResult> UploadFile()
        {
            IFormFile file = HttpContext.Request.Form.Files[0];
            var fileType = GetMimeTypeForFileExtension(file.FileName);
            var folderName = Convert.ToString(HttpContext.Request.Form["FolderName"]); //projectSummary?.AcHPFileProjectNumber + "-" + model.ProjectName; parent foldername
            var caseId = Convert.ToInt32(HttpContext.Request.Form["ProjectId"]);
            var category = Convert.ToString(HttpContext.Request.Form["Category"]);
            var comment = Convert.ToString(HttpContext.Request.Form["Description"]);
            //var folderId = Convert.ToInt32(HttpContext.Request.Form["FolderId"]);
            var documentType = fileType;
            var emailId = "ananthakrishnan.mohandas@lacity.org";

            var folderId = await _documentService.GetRecentFolderId();

            this._AAHP_Google_UName = _config["LAHD:username"].ToString();
            //var folderPath = AAHRServiceClient.UploadFileAsync(_BaseURL, _GoogleDriveId, folderName, file, fileType, _AAHP_Google_UName, AAHP_Google_Pwd);
            var uploadResponse = new DMSService(_config).SubmitUploadedDocument(file, emailId, caseId, category);

            var response = uploadResponse.Value as UploadResponse;

            if (response == null || (response.ErrorMessages != null && response.ErrorMessages.Length > 0))
            {
                return new JsonResult(new
                {
                    Success = false,
                    Message = "Failed to upload document.\n" +
                              (response?.ErrorMessages != null
                                  ? string.Join("; ", response.ErrorMessages)
                                  : "Unknown error")
                });
            }

            var documentModel = new DocumentModel()
            {
                Name = file.FileName,
                Link = response.UniqueId.ToString(),
                Attributes = "",
                FileSize = file.Length.ToString(),
                CaseId = caseId,
                FolderId = folderId,
                Comment= comment,
                OtherDocumentType = category,
                CreatedBy= "ananthakrishnan",
                CreatedOn=DateTime.Now,
                IsDeleted= false
               
            };

            var document = _documentService.SaveDocument(documentModel).Result;
            return Json(uploadResponse);
        }
        // GET: api/<DashboardController>
        [HttpGet]
        [Route("GetFoderData")]
        public JsonResult GetFoderData(string folderName)
        {

            var folderModel = AAHRServiceClient.GetFolderData(_BaseURL, _GoogleDriveId, folderName);
            return Json(folderModel);
        }
        public string GetMimeTypeForFileExtension(string filePath)
        {
            const string DefaultContentType = "application/octet-stream";

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filePath, out string contentType))
            {
                contentType = DefaultContentType;
            }

            return contentType;
        }
        /*public ActionResult GetFilesByIdNew(int controlViewModelId)
        {
            // Normally you'd call a real method here
            var controlViewModel = new ControlViewModel
            {
                ControlId = "mock-id",
                CaseId = 0,
                ProjectSiteId = 0
            };

            return GetFiles(controlViewModel, "DMSViewNew");
        }

        public ActionResult GetFiles(ControlViewModel controlView, string returnView)
        {
            var model = new DMSModel
            {
                ControlId = controlView.ControlId,
                ControlViewModel = controlView,
                SearchResults = new List<DMSResult>()
            };

            // Mock DataTable with headers only
            var dataTable = new DataTable();
            var columns = new[] { "Date", "Filename", "Category", "Uploader", "Shared", "Actions" };
            foreach (var columnName in columns)
            {
                var col = dataTable.Columns.Add(columnName);
                col.ExtendedProperties["Visible"] = true; // Required by your view
            }

            var newRow = dataTable.NewRow();
            newRow["Date"] = DateTime.Now.ToShortDateString();
            newRow["Filename"] = "ExampleFile.pdf";
            newRow["Category"] = "Category";
            newRow["Uploader"] = "UploaderName";
            newRow["Shared"] = "NAC";
            newRow["Actions"] = "Download";
            dataTable.Rows.Add(newRow);

            model.SearchResults.Add(new DMSResult
            {
                Data = dataTable,
                ColumnOrder = new List<int> { 0, 1, 2, 3, 4, 5 },
                TabName = "Default"
            });

            return PartialView("~/Areas/Document/Views/DMS/DMSViewNew.cshtml", model);
        }*/

       /* [HttpGet]
        [Route("DownloadDocument")]
        public async Task<IActionResult> DownloadDocument(string fileID)
        {
            var result = await AAHRServiceClient.DownloadDocument(_BaseURL, fileID);

            if (result == null)
            {
                string script = "<script>alert('File could not be found.'); window.history.back();</script>";
                return Content(script, "text/html");

            }

            var (stream, fileName, contentType) = result.Value;
            //return Content($"Stream Length: {stream.Length}, FileName: {fileName}, ContentType: {contentType}");

            return File(stream, contentType, fileName);
        }*/
        [HttpGet]
        [Route("DownloadDocument")]
        public async Task<IActionResult> DownloadDocument(string fileName, string filePath)
        {
            try
            {
                if (Guid.TryParse(filePath, out Guid guid))
                {
                    // Get configuration value using IConfiguration
                    //bool useFakeDMS = _config.GetValue<bool>("UseFakeDMS");
                    bool useFakeDMS = false;

                    var doc = new HCIDLA.ServiceClient.LaserFiche.Document();
                    var objDmsDocument = new DMSService(_config).GetDocument(guid, false);//await doc.GetDocumentAsync(guid, useFakeDMS);

                    if (objDmsDocument?.DocumentByte != null && objDmsDocument.DocumentByte.Length > 0)
                    {
                        return File(
                            objDmsDocument.DocumentByte,
                            MediaTypeNames.Application.Octet,
                            objDmsDocument.DocumentName);
                    }
                    else
                    {
                        return NotFound("Document not found or is empty.");
                    }
                }
                else
                {
                    // Use IWebHostEnvironment instead of HttpContext.Server.MapPath
                    string webRootPath = _webHostEnvironment.WebRootPath ?? _webHostEnvironment.ContentRootPath;
                    string fileAt = Path.Combine(webRootPath, filePath.TrimStart('/', '\\'));

                    // Validate file path to prevent directory traversal attacks
                    string fullPath = Path.GetFullPath(fileAt);
                    if (!fullPath.StartsWith(webRootPath))
                    {
                        return BadRequest("Invalid file path.");
                    }

                    if (!System.IO.File.Exists(fullPath))
                    {
                        return NotFound("File not found.");
                    }

                    byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(fullPath);
                    return File(fileBytes, MediaTypeNames.Application.Octet, fileName);
                }
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, "Error downloading document with fileName: {FileName}, filePath: {FilePath}", fileName, filePath);
                return StatusCode(500, "An error occurred while downloading the document.");
            }
        }
    }

}

