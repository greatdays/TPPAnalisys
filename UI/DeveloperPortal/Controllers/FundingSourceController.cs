using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.FundingSource;
using DeveloperPortal.Models.Common;
using DeveloperPortal.Models.IDM;
using DeveloperPortal.ServiceClient;
using HCIDLA.ServiceClient.DMS;
using HCIDLA.ServiceClient.LaserFiche;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Index.HPRtree;
using System.Net;
using System.Net.Mime;

[Authorize]
public class FundingSourceController : Controller
{
    private readonly IConfiguration _config;
    private readonly IDocumentService _documentService;
    private readonly IFundingSourceService _fundingSourceService;
    private static readonly object _lock = new object();
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAppConfigService _appConfigService;
    private IProjectDetailService _projectDetailService;

    // Mock data - replace with actual data source


    public FundingSourceController(IConfiguration configuration, IDocumentService documentService, IFundingSourceService fundingSourceService
        , IWebHostEnvironment webHostEnvironment,  
        IHttpContextAccessor httpContextAccessor, IAppConfigService appConfigService, IProjectDetailService projectDetailService)
    {
        _config = configuration;
        _documentService = documentService;
        _fundingSourceService = fundingSourceService;
        this._webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
        _appConfigService = appConfigService;
        _projectDetailService = projectDetailService;
    }

    // GET: /FundingSource/GetFundingSourcesById
    public IActionResult GetFundingSourcesById(string caseId,string projectId)
    {
        lock (_lock)
        {
            //foreach (var fs in fundingSourceData)
            //{
            //    fs.CaseId = caseId;
            //}
            var fundingsource = _fundingSourceService.GetAllFundingSourceDoc(caseId,projectId);
            var model = new FundingSourcePageViewModel
            {
                CaseId = caseId,
                ProjectId= projectId,
                // ControlViewModelId = controlViewModelId,
                FundingSources = fundingsource.Result
            };

            return PartialView("~/Pages/FundingSource/FundingSourceGrid.cshtml", model);
        }
    }

    /// <summary>
    /// Load Funding source first time
    /// </summary>
    /// 
    [HttpGet("{id}")]
    public ActionResult GetFundingSource(string Id, string ProjectId, int controlViewModelId)
    {
        var fundingsource = _fundingSourceService.GetAllFundingSourceDoc(Id,ProjectId);

        var pg = new FundingSourcePageViewModel
        {
            CaseId = Id,
            ControlViewModelId = controlViewModelId,
            FundingSources = fundingsource.Result,
            ProjectId = ProjectId
        };


        return PartialView("~/Pages/FundingSource/FundingSourceGrid.cshtml", pg);
    }



    /// <summary>
    /// Edit Funding source
    /// </summary>
    /// 
    
    public async Task<ActionResult> EditFundingSource(int id, int ProjectId)
    {

        var fundingSource = await _fundingSourceService.GetFundingSourceById(id);
        fundingSource.ProjectId = Convert.ToString(ProjectId);
        if (fundingSource == null)
        {
            return Json(new { success = false, message = "Funding source not found." });
        }
        return PartialView("~/Pages/FundingSource/FundingSourcePopUp.cshtml", fundingSource);
    }


    /// <summary>
    /// Delete Funding source
    /// </summary>
    /// 
    [HttpPost]
    public async Task<ActionResult> DeleteFundingSource(int id, string link)
    {

        try
        {
            string modifiedBy = UserSession.GetUserSession(_httpContextAccessor.HttpContext).UserName;
            _fundingSourceService.DeleteFundingSource(id, modifiedBy);
            await DeletedDocument(link);
            return Json(new { success = true, message = "Funding source saved successfully!" });

        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Funding source saved successfully!" });
        }
        // return Json(new { success = true, message = "Funding source saved successfully!" });
    }

    [HttpPost]
    public async Task<IActionResult> DeletedDocument(string link)
    {
        var response = new BaseResponse();

        if (string.IsNullOrWhiteSpace(link))
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseDescription = "Document link is required.";
            return StatusCode((int)response.ResponseCode, response);
        }

        try
        {
            var appIdStr = _config["DMSConfig:DMSAppIdExternal"];
            if (string.IsNullOrWhiteSpace(appIdStr) || !Guid.TryParse(appIdStr, out Guid appId))
            {
                response.ResponseCode = HttpStatusCode.InternalServerError;
                response.ResponseDescription = "DMS configuration is missing or invalid.";
                return StatusCode((int)response.ResponseCode, response);
            }

            var replaceDataInfo = new ReplaceDataInfo
            {
                ApplicationId = appId,
                UniqueId = Guid.Parse(link),
                MetaData = new Dictionary<FieldType, string[]>(),
                SysData = new Dictionary<SysFieldType, string>()
            };

            replaceDataInfo.MetaData.Add(FieldType.Status, new[] { "Deleted" });

            var username = UserSession.GetUserSession(_httpContextAccessor).UserName;
            replaceDataInfo.SysData.Add(SysFieldType.ModifiedBy, username);

            var replaceResult = DMSClientProxy.Update(replaceDataInfo);

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseDescription = "Document marked as deleted successfully.";
            response.Response = replaceResult;

            return StatusCode((int)response.ResponseCode, response);
        }
        catch (Exception ex)
        {

            response.ResponseCode = HttpStatusCode.InternalServerError;
            response.ResponseDescription = "An error occurred while deleting the document.";

            return StatusCode((int)response.ResponseCode, response);
        }
    }


    /// <summary>
    /// Add Funding source
    /// </summary>
    public ActionResult AddFundingSource(string id,string projectId)
    {
        FundingSourceViewModel fundingSourceViewModel = new FundingSourceViewModel();
        fundingSourceViewModel.CaseId = id;
        fundingSourceViewModel.ProjectId= projectId;
        return PartialView("~/Pages/FundingSource/FundingSourcePopUp.cshtml", fundingSourceViewModel);
    }


    /// <summary>
    /// Add/Edit Funding source
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> SaveFundingSource(FundingSourceViewModel viewModel, List<IFormFile> File)
    {
        
        var fileCategory = "Project";
        var fileSubCategory = "Funding Source";
        viewModel.CreatedBy = viewModel.ModifiedBy = UserSession.GetUserSession(_httpContextAccessor.HttpContext).UserName;
        viewModel.CreatedDate = DateTime.Now;
        viewModel.ModifiedDate = DateTime.Now;


        // Your logic to find and update the funding source
        if (viewModel.File != null && viewModel.File[0].Length > 0)
        {
            UploadResponse up = await SubmitUploadedDocument(File, Convert.ToInt32(viewModel.ProjectId), Convert.ToInt32(viewModel.CaseId), fileCategory, fileSubCategory, viewModel.Notes, viewModel);
            viewModel.Link = up.UniqueId.ToString();
            viewModel.FileSize = File[0].Length.ToString();
            viewModel.FileName =  File[0].FileName;
            viewModel.LuDocumentCategoryId = _fundingSourceService.getLuDocumentCategoryId(fileCategory, fileSubCategory);
            bool val  = await  _fundingSourceService.SaveDocumentForFundingSource(viewModel);
           var document= _fundingSourceService.getDocumentById(viewModel.DocumentID);
            if(document != null)
            {
                await DeletedDocument(document.Link);
            }
        }
        else
        {
           bool isSaved =  await _fundingSourceService.SaveDocumentForFundingSource(viewModel);
        }

        //var fundingsource = _fundingSourceService.GetAllFundingSourceDoc("25685");

        return Json(new { success = true, message = "Funding source saved successfully!" });
    }

    /// <summary>
    /// Save Document
    /// </summary>
   

    private async Task<UploadResponse> SubmitUploadedDocument(List<IFormFile> file,int ProjectId,  int caseId, string fileCategory, string fileSubCategory, string description, FundingSourceViewModel viewModel)
    {
        try
        {
            FileUploadResult FileUploadResult ;
            // Validate file size (10MB limit)
            if (file[0].Length > 10485760) // 10MB in bytes
            {
                FileUploadResult = new FileUploadResult { Success = false, ErrorMessage = "File size must be less than 10MB." };
            }

            var largeFileUploadPath = _appConfigService.getConfigValue("DMSLargeFileActualPath");

            // Validate file type
            var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file[0].FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                FileUploadResult =new FileUploadResult { Success = false, ErrorMessage = "File type not supported." };
            }
            
            var projReferenceId = ProjectId;
            //ProjectId= _documentService.GetActualProjectId(ProjectId);
            var projectSiteDetails = await _projectDetailService.GetProjectSiteDetails(ProjectId);
            projectSiteDetails.CaseID = caseId;
            projectSiteDetails.RefProjectID = projReferenceId;
            // RefProjectID and AAHRProjectID concern ---------------------
            // ProjectID - Assumes current projectid is RefProjectID
            // // RefProjectID and AAHRProjectID concern ------------------


            //var projReferenceId = _documentService.GetProjectReference(ProjectId);
            // Upload to DMS
            var uploadResponse = await new DMSService(_config)
                .SubmitUploadedDocument(file, projectSiteDetails, fileCategory, fileSubCategory, viewModel.CreatedBy, largeFileUploadPath);

            var response = uploadResponse;

            if (response == null || (response[0].ErrorMessages?.Length > 0))
            {
                FileUploadResult = new FileUploadResult
                {
                    Success = false,
                    ErrorMessage = "Failed to upload document.\n" +
                                  (response[0]?.ErrorMessages != null
                                      ? string.Join("; ", response[0].ErrorMessages)
                                      : "Unknown error")
                };
            }

            // Save document metadata
            return response[0];
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    [HttpGet]
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

    #region Helper Classes

    /// <summary>
    /// Result class for file upload operations
    /// </summary>
    public class FileUploadResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int? DocumentId { get; set; }
    }

    #endregion
}