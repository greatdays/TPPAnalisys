
using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.Application.Notification.Interface;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Domain.Notification;
using DeveloperPortal.Domain.Resources;
using DeveloperPortal.ServiceClient;
using HCIDLA.ServiceClient.DMS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using NetTopologySuite.Index.HPRtree;
using System.Net.Mime;

namespace DeveloperPortal.Controllers
{
    [Authorize]
    public class DMSController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IDocumentService _documentService;
        private IProjectDetailService _projectDetailService;
        private ISendNotificationEmail sendNotificationEmail;
        private string _BaseURL = "", _GoogleDriveId = "", _AAHP_Google_UName = "", AAHP_Google_Pwd = "",GroupEmail="";
        private bool _IsCreatedGoogleDriveFolder = false;
        private readonly IWebHostEnvironment _webHostEnvironment;
        // Inject IHttpContextAccessor instead of HttpContext
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAppConfigService _appConfigService;

        public DMSController(IDocumentService documentService, IProjectDetailService projectDetailService,
            IConfiguration config, ISendNotificationEmail _sendNotificationEmail, 
            IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAppConfigService appConfigService)
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
            this.GroupEmail = _config["NotificationCredentialConfig:GroupEmail"].ToString();
            this._webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _appConfigService = appConfigService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilesById(int caseId,int projectId, int controlViewModelId)
        {
           


            var model = new DMSModel
            {
                FolderModel = await _documentService.GetAllDocumentsBasedOnProjectId(caseId, projectId),
                CaseId = caseId,
                ProjectId= projectId
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
        [RequestSizeLimit(629145600)] // 600 MB in bytes
        [RequestFormLimits(MultipartBodyLengthLimit = 629145600)]
        [DisableRequestSizeLimit] // Alternative: removes all limits
        public async Task<JsonResult> UploadFile(
                                          List<IFormFile> files,
                                          [FromForm] int projectId,
                                          [FromForm] int caseId,
                                          [FromForm] string category,
                                          [FromForm] string projectName,
                                          [FromForm] string categoryName,
                                          [FromForm] string categoryGroup,
                                          [FromForm] string comments = "" // Corrected parameter name
                                         )
        {
            // Define the background flag used in DMSService.ProcessFiles URL field
            const string BackgroundFlag = "BACKGROUND_PROCESSING_INITIATED";
            string finalMessage, fileCategory, fileSubCategory;
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
                // Use the 'comments' parameter directly
                var comment = comments ?? string.Empty;
                var createdBy = DeveloperPortal.Models.IDM.UserSession.GetUserSession(_httpContextAccessor)?.UserName ?? "System";
                var refProjectId = projectId;
                projectId = _documentService.GetActualProjectId(projectId);
                var projectSiteDetails = await _projectDetailService.GetProjectSiteDetails(projectId);
                projectSiteDetails.CaseID = caseId;
                fileCategory = categoryGroup; //"Project";
                fileSubCategory = categoryName;//"Document";
                projectSiteDetails.RefProjectID = refProjectId;
                var largeFileUploadPath = _appConfigService.getConfigValue("DMSLargeFileActualPath");

                // Upload documents to DMS
                var responses = await new DMSService(_config).SubmitUploadedDocument(validFiles, projectSiteDetails, fileCategory, fileSubCategory, createdBy, largeFileUploadPath);

                if (responses == null || responses.Count == 0)
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "Failed to upload documents. No response received from document service."
                    });
                }
                var backgroundProcessed = responses.Where(r => r.ReturnStatus == Status.Success &&
                                                        r.URL == BackgroundFlag).ToList();
                var successfulUploads = responses.Where(r => r.ReturnStatus == Status.Success &&r.URL != BackgroundFlag).ToList();

                // Check for failed uploads
                var failedUploads = responses.Where(r => r.ReturnStatus == Status.Failed).ToList();
                if (failedUploads.Any())
                {
                    var errorMessages = failedUploads.SelectMany(f => f.ErrorMessages).ToList();

                    return Json(new
                    {
                        Success = false,
                        Message = $"Failed to upload {failedUploads.Count} documents. Errors: {string.Join("; ", errorMessages)}"
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
                            Link = response.URL!=null?response.UniqueId.ToString():"",
                            Attributes = string.Empty,
                            FileSize = file.Length.ToString(),
                            CaseId = caseId,
                            Comment = comment, // Correctly using the 'comment' variable
                            DocumentCategoryId  = Convert.ToInt32(category),
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
                
                if (backgroundProcessed.Any())
                {
                    // Prioritize the background processing message
                    finalMessage = "Your file(s) are currently being uploaded. Please refresh the page after 1–2 minutes as the file size is large";
                }
                else if (savedDocuments.Any())
                {
                    // Standard success message for small files
                    finalMessage = savedDocuments.Count == 1
                        ? "1 document uploaded successfully."
                        : $"{savedDocuments.Count} documents uploaded successfully.";
                }
                else
                {
                    finalMessage = "Upload request processed, but no files were saved or started processing.";
                }

                await SendEmailNotifyUploadDocument(savedDocuments, projectId, projectName);



                return new JsonResult(new
                {
                    Success = true,
                    Message = finalMessage,
                    IsProcessingInBackground = backgroundProcessed.Any(),
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
        [Route("GetFolderData")]
        public JsonResult GetFolderData(string folderName)
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
        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            string[] categories = { "Project", "Property" };
            string[] referenceKey = { "ConstructionRetrofitProject", "ConstructionRetrofitProperty" };

            var result = _documentService.GetCategories(categories, referenceKey);

            return Ok(result); // returns JSON array
        }
        public async Task SendEmailNotifyUploadDocument(List<DocumentModel> documentList, int projectId, string projectName)
        {
            if (documentList == null || documentList.Count == 0)
                return; // nothing to send

            // Common file info
            string createdBy = documentList.First().CreatedBy;
            string fileNames = (documentList.Count > 1)
                ? string.Join(", ", documentList.Select(d => d.Name))
                : documentList.First().Name;

            var recipients = sendNotificationEmail.TPPProjectContactList(projectId);

            if (recipients != null && recipients.Count > 0)
            {
                foreach (var item in recipients)
                {
                    var notificationData = BuildNotificationData(projectName, createdBy, fileNames,
                        string.Join(" ", new[] { item.FirstName, item.MiddleName, item.LastName }
                            .Where(s => !string.IsNullOrWhiteSpace(s))));

                    var notificationInfo = sendNotificationEmail.GetNotificationInfo(
                        EmailTemplate.ET_SendEmailUploadFile,
                        notificationData,
                        item.Email);

                    // Need to update the application ID
                    var notificationCredential = sendNotificationEmail.GetNotificationCrdential("AAHR");

                    await sendNotificationEmail.SendMail(notificationInfo, notificationCredential, EmailAction.EA_Signup);
                }
            }
            else
            {
                var notificationData = BuildNotificationData(projectName, createdBy, fileNames, "Users");

                var notificationInfo = sendNotificationEmail.GetNotificationInfo(
                    EmailTemplate.ET_SendEmailUploadFile,
                    notificationData,
                    GroupEmail);

                var notificationCredential = sendNotificationEmail.GetNotificationCrdential("AcHPIntranet");

                await sendNotificationEmail.SendMail(notificationInfo, notificationCredential, "EA_SendEmailUploadFile");
            }
        }
        private Dictionary<string, string> BuildNotificationData(string projectName, string createdBy, string fileNames, string userName)
        {
            return new Dictionary<string, string>
            {
                ["ProjectName"] = projectName,
                ["CreatedBy"] = createdBy,
                ["FileName"] = fileNames,
                ["UserName"] = userName
            };
        }
        //public async Task SendEmailNotifyUploadDocument(List<DocumentModel> documentList,int projectId,string projectName)
        //{
        //    Dictionary<string, string> NotificationData = null;
        //    var getAssignedProjectContactEmails = sendNotificationEmail.TPPProjectContactList(projectId);
        //    if (getAssignedProjectContactEmails != null && getAssignedProjectContactEmails.Count > 0)
        //    {
        //        foreach (var item in getAssignedProjectContactEmails)
        //        {
        //            NotificationData = new Dictionary<string, string>();

        //            NotificationData.Add("ProjectName", projectName);
        //            NotificationData.Add("CreatedBy", documentList[0].CreatedBy);
        //            NotificationData.Add("FileName", (documentList?.Count > 1)
        //                                                ? string.Join(", ", documentList.Select(d => d.Name))
        //                                                : documentList?.FirstOrDefault()?.Name);

        //            NotificationData.Add("UserName",
        //                                 string.Join(" ", new[] { item.FirstName, item.MiddleName, item.LastName }
        //                                     .Where(s => !string.IsNullOrWhiteSpace(s))));
                    
        //            var notificationInfo = sendNotificationEmail.GetNotificationInfo(EmailTemplate.ET_SendEmailUploadFile, NotificationData, item.Email);
        //            var notificationCrdential = sendNotificationEmail.GetNotificationCrdential("ACHP");
        //            await sendNotificationEmail.SendMail(notificationInfo, notificationCrdential, EmailAction.EA_Signup);
        //        }
        //    }
        //    else
        //    {
        //        NotificationData = new Dictionary<string, string>();
                
        //        NotificationData.Add("ProjectName", projectName);
        //        NotificationData.Add("CreatedBy", documentList[0].CreatedBy);
        //        NotificationData.Add("FileName", (documentList?.Count > 1)
        //                                            ? string.Join(", ", documentList.Select(d => d.Name))
        //                                            : documentList?.FirstOrDefault()?.Name);

        //        NotificationData.Add("UserName", "Users");
        //        var notificationInfo = sendNotificationEmail.GetNotificationInfo(EmailTemplate.ET_SendEmailUploadFile, NotificationData, GroupEmail);
        //        var notificationCrdential = sendNotificationEmail.GetNotificationCrdential("AcHPIntranet");
        //        await sendNotificationEmail.SendMail(notificationInfo, notificationCrdential, "EA_SendEmailUploadFile");

        //    }
         
        //}
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
