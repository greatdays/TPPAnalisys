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
using DeveloperPortal.ServiceClient;
using System.Net.Http.Headers;


namespace DeveloperPortal.Areas.Document.Controllers
{
    [Area("Document")]
    public class DMSController : Controller
    {
        private IConfiguration _config;
        private readonly IDocumentService _documentService;
        private IProjectDetailService _projectDetailService;
        private string _BaseURL = "";
        private string _GoogleDriveId = "";
        private bool _IsCreatedGoogleDriveFolder = false;

        public DMSController(IDocumentService documentService, IProjectDetailService projectDetailService, IConfiguration config)
        {
            this._config = config;
            this._documentService= documentService;
            this._projectDetailService = projectDetailService;
            this._BaseURL = _config["AAHRApiSettings:URL"].ToString();
            this._GoogleDriveId = _config["AAHRApiSettings:GoogleDrive"].ToString();
            this._IsCreatedGoogleDriveFolder = true;//Convert.ToBoolean(_config["AAHRApiSettings:IsCreatedGoogleDriveFolder"].ToString());
        }

        [HttpGet]
        [Route("Document/DMS/GetFilesById")]
        public async Task<IActionResult> GetFilesById(int caseId, int controlViewModelId)
        {
            var model = new DMSModel();

            var projectSummary = _projectDetailService.GetProjectSummary(caseId);
            model.ProjectName = projectSummary?.ProjectName ?? "";
            model.ProjectId = projectSummary?.CaseID ?? 0;
            model.ProjectFolderName = projectSummary?.AcHPFileProjectNumber + "-" + model.ProjectName;

            // Get folder from Google Drive or other service
            //  model.DMSFolders =  AAHRServiceClient.GetFolderData(_BaseURL, _GoogleDriveId, model.ProjectFolderName);

            // If folder doesn't exist, create it
            /*  if (model.DMSFolders == null || string.IsNullOrEmpty(model.DMSFolders.Name))
              {
                  var folderModel = new FolderModel
                  {
                      Name = model.ProjectFolderName,
                      ParentFolderName = "ACHPAPITEST",
                      ProjectId = model.ProjectId
                  };//Check performance issue - create new sp to check whether the folder exists or not....

                  var driveFolderData = AAHRServiceClient.CreateFolder(_BaseURL, _GoogleDriveId, folderModel.Name, folderModel.ParentFolderName);
                  folderModel.Attributes = driveFolderData;
                  folderModel= await _documentService.SaveFolder(folderModel);

                  // You can fetch the folder details again or just set a default
                  model.FolderModel = new FolderDetails()
                  {
                      Name= folderModel.Name,
                      Id= folderModel.FolderId.ToString(),


                  };// Optional: populate this if needed
              }*/

            var folderModel = new FolderModel
            {
                Name = model.ProjectFolderName,
                ParentFolderName = "ACHPAPITEST",
                ProjectId = model.ProjectId
            };//Check performance issue - create new sp to check whether the folder exists or not....
            model.FolderModel = new FolderDetails()
            {
                Name = folderModel.Name,
                Id = folderModel.FolderId.ToString(),


            };// Optional: populate this if needed

            // Get existing documents for this case/project
            model.FolderModel.Files = await _documentService.GetAllDocumentsBasedOnProjectId(caseId);

            // Optionally store controlViewModelId if used later
           // model.ControlId = controlViewModelId;

            return View("~/Areas/Document/Views/DMS/DMSView.cshtml", model);
            //var list = await _documentService.GetAllDocumentsBasedOnProjectId(caseId);
            //return View("~/Areas/Document/Views/DMS/DMSView.cshtml", list); // Or Json(list) if it's an API
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
        public JsonResult UploadFile()
        {
            IFormFile file = HttpContext.Request.Form.Files[0];
            var fileType = GetMimeTypeForFileExtension(file.FileName);
            var folderName = Convert.ToString(HttpContext.Request.Form["FolderName"]);
            var caseId = Convert.ToInt32(HttpContext.Request.Form["ProjectId"]);
            var folderId = Convert.ToInt32(HttpContext.Request.Form["FolderId"]);
            var documentType = fileType;


            var folderPath = AAHRServiceClient.UploadFiel(_BaseURL, _GoogleDriveId, folderName, file, fileType);
            var documentModel = new DocumentModel()
            {
                Name = file.FileName,
                Link = folderPath,
                Attributes = "",
                FileSize = file.Length.ToString(),
                CaseId = caseId,
                FolderId = folderId,
                OtherDocumentType = documentType,
                CreatedBy="jalcanter",
                CreatedOn=DateTime.Now
               
            };

            var document = _documentService.SaveDocument(documentModel).Result;
            return Json(folderPath);
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

        [HttpGet]
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
        }

    }
}
