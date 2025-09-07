using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DeveloperPortal.Domain.FundingSource;
using System.ComponentModel.DataAnnotations;
using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.ServiceClient;
using HCIDLA.ServiceClient.DMS;
using DeveloperPortal.Domain.DMS;

[Authorize]
public class FundingSourceController : Controller
{
    private readonly IConfiguration _config;
    private readonly IDocumentService _documentService;
    private static readonly object _lock = new object();

    // Mock data - replace with actual data source
    private static List<FundingSourceViewModel> fundingSourceData = new List<FundingSourceViewModel>
    {
        new FundingSourceViewModel
        {
            FundingSourceId = 1,
            FundingSource = "Government Grant",
            Notes = "Federal funding",
            MU_Unit = 50,
            HV_Unit = 30,
            Description = "Primary funding source",
            FileName = "grant_document.pdf"
        },
        new FundingSourceViewModel
        {
            FundingSourceId = 2,
            FundingSource = "Private Investment",
            Notes = "Angel investor",
            MU_Unit = 25,
            HV_Unit = 45,
            Description = "Secondary funding",
            FileName = ""
        }
    };

    public FundingSourceController(IConfiguration configuration, IDocumentService documentService)
    {
        _config = configuration;
        _documentService = documentService;
    }

    // GET: /FundingSource/GetFundingSourcesById
    public IActionResult GetFundingSourcesById(int caseId, int controlViewModelId = 0)
    {
        lock (_lock)
        {
            foreach (var fs in fundingSourceData)
            {
                fs.CaseId = caseId;
            }

            var model = new FundingSourcePageViewModel
            {
                CaseId = caseId,
                ControlViewModelId = controlViewModelId,
                FundingSources = fundingSourceData
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
            var fundingSource = fundingSourceData.FirstOrDefault(fs => fs.FundingSourceId == id);
            if (fundingSource == null)
            {
                return Json(new { success = false, message = "Funding source not found." });
            }

            return Json(fundingSource);
        }
    }

    // GET: /FundingSource/Edit/5 - For modal view
    public IActionResult Edit(int id)
    {
        var fundingSource = fundingSourceData.FirstOrDefault(fs => fs.FundingSourceId == id);
        if (fundingSource == null)
        {
            return NotFound();
        }
        return PartialView("~/Pages/FundingSource/_EditFundingSourcePopup.cshtml", fundingSource);
    }

    // POST: /FundingSource/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] FundingSourceViewModel viewModel)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { Field = x.Key, Errors = x.Value.Errors.Select(e => e.ErrorMessage) })
                    .ToList();

                return Json(new
                {
                    success = false,
                    message = "Please correct the validation errors.",
                    errors = errors
                });
            }

            var caseId = Convert.ToInt32(HttpContext.Request.Form["CaseId"]);
            var emailId = GetCurrentUserEmail(); // Helper method to get current user email
            var fileCategory = "Project";
            var fileSubCategory = "FundingSource";

           
                // Generate new ID
                viewModel.FundingSourceId = fundingSourceData.Any()
                    ? fundingSourceData.Max(fs => fs.FundingSourceId) + 1
                    : 1;

                viewModel.CaseId = caseId;

                // Handle file upload if present
                if (viewModel.File != null && viewModel.File.Length > 0)
                {
                    var fileUploadResult = await HandleFileUpload(viewModel.File, emailId, caseId, fileCategory, fileSubCategory, viewModel.Description);

                    if (!fileUploadResult.Success)
                    {
                        return Json(new { success = false, message = fileUploadResult.ErrorMessage });
                    }

                    viewModel.FileName = viewModel.File.FileName;
                    viewModel.DocumentID = fileUploadResult.DocumentId;
                }

                fundingSourceData.Add(viewModel);
           

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
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { Field = x.Key, Errors = x.Value.Errors.Select(e => e.ErrorMessage) })
                    .ToList();

                return Json(new
                {
                    success = false,
                    message = "Please correct the validation errors.",
                    errors = errors
                });
            }

            var caseId = Convert.ToInt32(HttpContext.Request.Form["CaseId"]);
            var emailId = GetCurrentUserEmail();
            var fileCategory = "Project";
            var fileSubCategory = "FundingSource";

          
                var fundingSourceToUpdate = fundingSourceData
                    .FirstOrDefault(fs => fs.FundingSourceId == viewModel.FundingSourceId);

                if (fundingSourceToUpdate == null)
                {
                    return Json(new { success = false, message = "Funding source not found." });
                }

                // Update basic fields
                fundingSourceToUpdate.FundingSource = viewModel.FundingSource;
                fundingSourceToUpdate.Notes = viewModel.Notes;
                fundingSourceToUpdate.MU_Unit = viewModel.MU_Unit;
                fundingSourceToUpdate.HV_Unit = viewModel.HV_Unit;
                fundingSourceToUpdate.Description = viewModel.Description;

                // Handle file removal
                var removeFile = HttpContext.Request.Form["RemoveFile"].ToString().ToLower() == "true";
                if (removeFile)
                {
                    // TODO: Delete the actual file from storage if needed
                    fundingSourceToUpdate.FileName = "";
                    fundingSourceToUpdate.DocumentID = null;
                }

                // Handle new file upload
                if (viewModel.File != null && viewModel.File.Length > 0)
                {
                    var fileUploadResult = await HandleFileUpload(viewModel.File, emailId, caseId, fileCategory, fileSubCategory, viewModel.Description);

                    if (!fileUploadResult.Success)
                    {
                        return Json(new { success = false, message = fileUploadResult.ErrorMessage });
                    }

                    fundingSourceToUpdate.FileName = viewModel.File.FileName;
                    fundingSourceToUpdate.DocumentID = fileUploadResult.DocumentId;
                }
           

            return Json(new { success = true, message = "Funding source updated successfully." });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
        }
    }

    // POST: /FundingSource/Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        try
        {
            lock (_lock)
            {
                var fundingSourceToRemove = fundingSourceData.FirstOrDefault(fs => fs.FundingSourceId == id);
                if (fundingSourceToRemove != null)
                {
                    // TODO: Delete associated documents if needed
                    fundingSourceData.Remove(fundingSourceToRemove);
                    return Json(new { success = true, message = "Funding source deleted successfully." });
                }
                return Json(new { success = false, message = "Funding source not found." });
            }
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
        }
    }

    #region Private Helper Methods

    /// <summary>
    /// Handle file upload and document creation
    /// </summary>
    private async Task<FileUploadResult> HandleFileUpload(IFormFile file, string emailId, int caseId, string fileCategory, string fileSubCategory, string description)
    {
        try
        {
            // Validate file size (10MB limit)
            if (file.Length > 10485760) // 10MB in bytes
            {
                return new FileUploadResult { Success = false, ErrorMessage = "File size must be less than 10MB." };
            }

            // Validate file type
            var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return new FileUploadResult { Success = false, ErrorMessage = "File type not supported." };
            }

            // Upload to DMS
            var uploadResponse = new DMSService(_config)
                .SubmitUploadedDocument(file, emailId, caseId, fileCategory, fileSubCategory);

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
                Name = file.FileName,
                Link = response.UniqueId.ToString(),
                Attributes = "",
                FileSize = file.Length.ToString(),
                CaseId = caseId,
                Comment = description ?? "",
                OtherDocumentType = null,
                CreatedBy = GetCurrentUserName(), // Helper method
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            await _documentService.SaveDocument(documentModel);

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