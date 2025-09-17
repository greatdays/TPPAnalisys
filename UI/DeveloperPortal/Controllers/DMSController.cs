using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.Application.Notification.Interface;
using DeveloperPortal.Application.ProjectDetail.Implementation;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.ServiceClient;
using HCIDLA.ServiceClient.DMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Mime;

namespace DeveloperPortal.Controllers
{
    public class DMSController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IDocumentService _documentService;
        private IProjectDetailService _projectDetailService;
        private ISendNotificationEmail sendNotificationEmail;
        private string _BaseURL = "", _GoogleDriveId = "", _AAHP_Google_UName = "", AAHP_Google_Pwd = "";
        private bool _IsCreatedGoogleDriveFolder = false;
        private readonly IWebHostEnvironment _webHostEnvironment;
        // Inject IHttpContextAccessor instead of HttpContext
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DMSController(IDocumentService documentService, IProjectDetailService projectDetailService,
            IConfiguration config, ISendNotificationEmail _sendNotificationEmail, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this._config = config;
            this._documentService = documentService;
            this._projectDetailService = projectDetailService;
            this._BaseURL = _config["AAHRApiSettings:URL"].ToString();
            this._GoogleDriveId = _config["AAHRApiSettings:GoogleDrive"].ToString();
            this._IsCreatedGoogleDriveFolder = true;
            this.sendNotificationEmail = _sendNotificationEmail;
            this._AAHP_Google_UName = _config["LAHD:username"].ToString();
            this.AAHP_Google_Pwd = _config["LAHD:password"].ToString();
            this._webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
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

            return PartialView("~/Pages/DMS/DMSView.cshtml", model);
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
        public async Task<JsonResult> UploadFile(
                                          List<IFormFile> files,
                                          [FromForm] int projectId,
                                          [FromForm] string category,
                                          [FromForm] string comments = "" // Corrected parameter name
                                         )
        {
            try
            {
                // Validate input
                if (files == null || files.Count == 0)
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "No files were selected for upload."
                    });
                }

                if (projectId <= 0)
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "Invalid project ID."
                    });
                }

                if (string.IsNullOrWhiteSpace(category))
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "Category is required."
                    });
                }

                // Filter out empty files
                var validFiles = files.Where(f => f != null && f.Length > 0).ToList();
                if (validFiles.Count == 0)
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "No valid files found. Please ensure files are not empty."
                    });
                }

               

                var caseId = projectId;
                // Use the 'comments' parameter directly
                var comment = comments ?? string.Empty;
                var createdBy = DeveloperPortal.Models.IDM.UserSession.GetUserSession(_httpContextAccessor)?.UserName ?? "System";

                string fileCategory = "Project";
                string fileSubCategory = "Document";

                // Upload documents to DMS
                var responses = await new DMSService(_config).SubmitUploadedDocument(validFiles, caseId, fileCategory, fileSubCategory, createdBy);

                if (responses == null || responses.Count == 0)
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "Failed to upload documents. No response received from document service."
                    });
                }

                // Check for failed uploads
                var failedUploads = responses.Where(r => r.ReturnStatus == Status.Failed).ToList();
                if (failedUploads.Any())
                {
                    var errorMessages = failedUploads
                        .SelectMany(f => f.ErrorMessages)
                        .ToList();

                    return Json(new
                    {
                        Success = false,
                        Message = $"Failed to upload {failedUploads.Count} of {responses.Count} documents. Errors: {string.Join("; ", errorMessages)}"
                    });
                }

                // Save successful uploads to database
                var savedDocuments = new List<DocumentModel>();
                var successfulResponses = responses.Where(r => r.ReturnStatus == Status.Success).ToList();

                for (int i = 0; i < successfulResponses.Count && i < validFiles.Count; i++)
                {
                    var response = successfulResponses[i];
                    var file = validFiles[i];

                    try
                    {
                        var documentModel = new DocumentModel()
                        {
                            Name = file.FileName,
                            Link = response.UniqueId.ToString() ?? string.Empty,
                            Attributes = string.Empty,
                            FileSize = file.Length.ToString(),
                            CaseId = caseId,
                            Comment = comment, // Correctly using the 'comment' variable
                            OtherDocumentType = category,
                            CreatedBy = createdBy,
                            CreatedOn = DateTime.Now,
                            IsDeleted = false
                        };

                        var savedDocument = await _documentService.SaveDocument(documentModel);
                        savedDocuments.Add(savedDocument);
                    }
                    catch (Exception ex)
                    {
                        // Log the error but continue with other files
                        // _logger.LogError(ex, "Error saving document metadata for file: {FileName}", file.FileName);
                        Console.WriteLine($"Error saving document metadata for file {file.FileName}: {ex.Message}");
                    }
                }

                var successMessage = savedDocuments.Count == 1
                    ? "1 document uploaded successfully."
                    : $"{savedDocuments.Count} documents uploaded successfully.";

                return Json(new
                {
                    Success = true,
                    Message = successMessage,
                    UploadedCount = savedDocuments.Count,
                    TotalCount = validFiles.Count
                });
            }
            catch (Exception ex)
            {
                // Log the full exception details
                // _logger.LogError(ex, "Unexpected error during file upload for project {ProjectId}", projectId);
                Console.WriteLine($"Unexpected error during file upload: {ex}");

                return Json(new
                {
                    Success = false,
                    Message = "An unexpected error occurred during upload. Please try again."
                });
            }
        }
        [HttpPost]
        public ActionResult DeleteDocument(int id)
        {
            try
            {

                _documentService.DeleteDocument(id);
                return Json(new { success = true, message = "Document deleted successfully" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            // return Json(new { success = true, message = "Funding source saved successfully!" });
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
