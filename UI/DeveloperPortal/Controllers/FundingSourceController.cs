using System.Net.Mime;
using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Domain.FundingSource;
using DeveloperPortal.ServiceClient;
using HCIDLA.ServiceClient.DMS;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

//[Authorize]
public class FundingSourceController : Controller
{
    private readonly IConfiguration _config;
    private readonly IDocumentService _documentService;
    private readonly IFundingSourceService _fundingSourceService;
    private static readonly object _lock = new object();
    private readonly IWebHostEnvironment _webHostEnvironment;
    // Mock data - replace with actual data source


    public FundingSourceController(IConfiguration configuration, IDocumentService documentService, IFundingSourceService fundingSourceService
        , IWebHostEnvironment webHostEnvironment)
    {
        _config = configuration;
        _documentService = documentService;
        _fundingSourceService = fundingSourceService;
        this._webHostEnvironment = webHostEnvironment;
    }

    // GET: /FundingSource/GetFundingSourcesById
    public IActionResult GetFundingSourcesById(string caseId, int controlViewModelId = 0)
    {
        lock (_lock)
        {
            //foreach (var fs in fundingSourceData)
            //{
            //    fs.CaseId = caseId;
            //}
            var fundingsource = _fundingSourceService.GetAllFundingSourceDoc(caseId);
            var model = new FundingSourcePageViewModel
            {
                CaseId = caseId,
                ControlViewModelId = controlViewModelId,
                FundingSources = fundingsource.Result
            };

            return PartialView("~/Pages/FundingSource/FundingSource.cshtml", model);
        }
    }

    // GET: /FundingSource/GetById - For AJAX calls from JavaScript
    [HttpGet]
    public IActionResult GetById(int id)
    {
        lock (_lock)
        {
            var fundingSource = _fundingSourceService.GetFundingSourceById(id).Result;
            if (fundingSource == null)
            {
                return Json(new { success = false, message = "Funding source not found." });
            }

            return Json(fundingSource);
        }
    }

    // GET: /FundingSource/Edit/5 - For modal view
    //public IActionResult Edit(int id)
    //{
    //    var fundingSource = fundingSourceData.FirstOrDefault(fs => fs.FundingSourceId == id);
    //    if (fundingSource == null)
    //    {
    //        return NotFound();
    //    }
    //    return PartialView("~/Pages/FundingSource/_EditFundingSourcePopup.cshtml", fundingSource);
    //}

    // POST: /FundingSource/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] FundingSourceViewModel viewModel)
    {
        try
        {
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState
            //        .Where(x => x.Value.Errors.Count > 0)
            //        .Select(x => new { Field = x.Key, Errors = x.Value.Errors.Select(e => e.ErrorMessage) })
            //        .ToList();

            //    return Json(new
            //    {
            //        success = false,
            //        message = "Please correct the validation errors.",
            //        errors = errors
            //    });
            //}

            var caseId = HttpContext.Request.Form["CaseId"];
            var emailId = GetCurrentUserEmail(); // Helper method to get current user email
            var fileCategory = "Project";
            var fileSubCategory = "FundingSource";


            // Generate new ID
            //viewModel.FundingSourceId = fundingSourceData.Any()
            //    ? fundingSourceData.Max(fs => fs.FundingSourceId) + 1
            //    : 1;

            viewModel.CaseId = caseId;

            // Handle file upload if present
            if (viewModel.File != null && viewModel.File.Count == 1)
            {
                //FundingSourcePageViewModel pg = viewModel?.FundingSource?.FirstOrDefault();
                var fileUploadResult = await HandleFileUpload(viewModel.File, emailId, Convert.ToInt32(caseId), fileCategory, fileSubCategory, viewModel.Notes, viewModel);

                if (!fileUploadResult.Success)
                {
                    return Json(new { success = false, message = fileUploadResult.ErrorMessage });
                }

                viewModel.FileName = viewModel.File[0].FileName;
                viewModel.DocumentID = fileUploadResult.DocumentId;
            }

            //fundingSourceData.Add(viewModel);


            return Json(new { success = true, message = "Funding source created successfully." });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
        }
    }

    // POST: /FundingSource/Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] FundingSourceViewModel viewModel)
    {
        try
        {
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState
            //        .Where(x => x.Value.Errors.Count > 0)
            //        .Select(x => new { Field = x.Key, Errors = x.Value.Errors.Select(e => e.ErrorMessage) })
            //        .ToList();

            //    return Json(new
            //    {
            //        success = false,
            //        message = "Please correct the validation errors.",
            //        errors = errors
            //    });
            //}
            bool isFileRemoved = false;
            var caseId = Convert.ToInt32(HttpContext.Request.Form["CaseId"]);
            var emailId = GetCurrentUserEmail();
            var fileCategory = "Project";
            var fileSubCategory = "FundingSource";

            var fundingSourceToUpdate = _fundingSourceService.GetFundingSourceById(viewModel.FundingSourceId).Result;

            if (fundingSourceToUpdate == null)
            {
                return Json(new { success = false, message = "Funding source not found." });
            }

            // Update basic fields
            fundingSourceToUpdate.FundingSource = viewModel.FundingSource;
            fundingSourceToUpdate.Notes = viewModel.Notes;
            fundingSourceToUpdate.MU_Unit = viewModel.MU_Unit;
            fundingSourceToUpdate.HV_Unit = viewModel.HV_Unit;
            fundingSourceToUpdate.DocumentID = fundingSourceToUpdate.DocumentID;
            viewModel.DocumentID = fundingSourceToUpdate.DocumentID; ;
            //fundingSourceToUpdate.Description = viewModel.Description;

            // Handle file removal
            var removeFile = HttpContext.Request.Form["RemoveFile"].ToString().ToLower() == "true";
            if (removeFile)
            {
                fundingSourceToUpdate.FileName = "";
                isFileRemoved = true;
            }


            // Handle new file upload
            if (viewModel.File != null && viewModel.File[0].Length > 0)
            {
                var fileUploadResult = await HandleFileUpload(viewModel.File, emailId, Convert.ToInt32(caseId), fileCategory, fileSubCategory, viewModel.Notes, viewModel);

                if (!fileUploadResult.Success)
                {
                    return Json(new { success = false, message = fileUploadResult.ErrorMessage });
                }
            }
            else
            {
                var documentModel = new DocumentModel
                {
                    Comment = viewModel.Notes ?? "",
                    OtherDocumentType = "FundingSource",
                    ModifiedBy = GetCurrentUserName(), // Helper method
                    ModifiedOn = DateTime.Now,
                    Link = fundingSourceToUpdate.Link,
                    FileSize = fundingSourceToUpdate.FileSize,
                    CreatedBy = fundingSourceToUpdate.CreatedBy, // Helper method
                    CreatedOn = fundingSourceToUpdate.CreatedDate ?? DateTime.Now,
                    Name = fundingSourceToUpdate.FileName,
                    IsDeleted = isFileRemoved
                };

                SaveDocument(documentModel, viewModel);
            }


                return Json(new { success = true, message = "Funding source updated successfully." });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
        }
    }

    // POST: /FundingSource/Delete
    [HttpGet]
    public bool Delete(int id)
    {
        try
        {
            lock (_lock)
            {

               return _fundingSourceService.DeleteFundingSource(id).Result;
               
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }


     

    #region Private Helper Methods

    /// <summary>
    /// Handle file upload and document creation
    /// </summary>
    private async Task<FileUploadResult> HandleFileUpload(IFormFileCollection file, string emailId, int caseId, string fileCategory, string fileSubCategory, string description, FundingSourceViewModel viewModel)
    {
        try
        {
            // Validate file size (10MB limit)
            if (file[0].Length > 10485760) // 10MB in bytes
            {
                return new FileUploadResult { Success = false, ErrorMessage = "File size must be less than 10MB." };
            }

            // Validate file type
            var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file[0].FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return new FileUploadResult { Success = false, ErrorMessage = "File type not supported." };
            }

            // Upload to DMS
            var uploadResponse = new DMSService(_config)
                .SubmitUploadedDocument(file,  caseId, fileCategory, fileSubCategory, viewModel.CreatedBy);

            var response = uploadResponse.Value as UploadResponse;

            if (response == null || (response.ErrorMessages?.Length > 0))
            {
                return new FileUploadResult
                {
                    Success = false,
                    ErrorMessage = "Failed to upload document.\n" +
                                  (response?.ErrorMessages != null
                                      ? string.Join("; ", response.ErrorMessages)
                                      : "Unknown error")
                };
            }

            // Save document metadata
            var documentModel = new DocumentModel
            {

                Name = file[0].FileName,
                Link = response.UniqueId.ToString(),
                Attributes = "",
                FileSize = file[0].Length.ToString(),
                CaseId = caseId,
                Comment = viewModel.Notes ?? "",
                OtherDocumentType = "FundingSource",
                CreatedBy = GetCurrentUserName(), // Helper method
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            await _fundingSourceService.SaveDocumentForFundingSource(documentModel, viewModel);

            return new FileUploadResult
            {
                Success = true,
                DocumentId = 0
            };
        }
        catch (Exception ex)
        {
            return new FileUploadResult { Success = false, ErrorMessage = $"File upload failed: {ex.Message}" };
        }
    }


    public async Task SaveDocument(DocumentModel documentModel, FundingSourceViewModel viewModel)
    {
        // Make sure your service returns a list of objects that can be serialized to JSON
        await _fundingSourceService.SaveDocumentForFundingSource(documentModel, viewModel);
    }



    [HttpGet]
    public IActionResult GetFundingSourcesByCaseIdJson(string caseId)
    {
        var fundingSources = _fundingSourceService.GetAllFundingSourceDoc(caseId).Result;
        return Json(fundingSources);
    }

    /// <summary>
    /// Get current user's email
    /// </summary>
    private string GetCurrentUserEmail()
    {
        // TODO: Replace with actual user email retrieval logic
        // Example: return User.FindFirst(ClaimTypes.Email)?.Value ?? "unknown@email.com";
        return "testQ@yopmail.com";
    }

    /// <summary>
    /// Get current user's name
    /// </summary>
    private string GetCurrentUserName()
    {
        // TODO: Replace with actual user name retrieval logic
        // Example: return User.FindFirst(ClaimTypes.Name)?.Value ?? "Unknown User";
        return "testQ";
    }

    #endregion

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