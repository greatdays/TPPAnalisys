using Azure.Core;
using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.Application.ProjectDetail.Implementation;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.FundingSource;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Models.IDM;
using DeveloperPortal.Models.PlanReview;
using DeveloperPortal.Pages.FloorPlanType;
using DeveloperPortal.Pages.ProjectDetail;
using DeveloperPortal.ServiceClient;
using HCIDLA.ServiceClient.DMS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DeveloperPortal.Domain.DMS;

namespace DeveloperPortal.Controllers
{
    [Authorize]
    public class FloorPlanTypeController : Controller
    {

        private readonly IFloorPlanTypeService _floorPlanTypeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly IDocumentService _documentService;
        public FloorPlanTypeController(IConfiguration config, IFloorPlanTypeService floorPlanTypeService, IHttpContextAccessor httpContextAccessor, IDocumentService documentService)
        {
            _floorPlanTypeService = floorPlanTypeService;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _documentService = documentService;
        }
        [HttpGet]
        public async Task<ActionResult> _EditFloorPlanType(int id)
        {
            var floorPlan = await _floorPlanTypeService.FetchFloorPlanById(id);
            return PartialView(@"~/Pages/FloorPlanType/_EditFloorPlanType.cshtml", floorPlan);
        }

        [HttpGet]
        public IActionResult GetFloorPlanTypes(int projectId)
        {
            var result = _floorPlanTypeService.GetFloorPlanInformation(projectId); // Assuming service call
            return Json(result); // return as JSON for JS to consume
        }
        [RequestSizeLimit(524288000)]
        [HttpPost]
        public async Task<JsonResult> _EditFloorPlanType(FloorPlanTypeModel floorPlanTypeModel)
        {
            try
            {
                var userName = UserSession.GetUserSession(_httpContextAccessor.HttpContext).UserName;
                var LutBathroomTypeID = Convert.ToString(Request.Form["bathroomTypes"]);
                var LutBathroomTypeOptionID = Convert.ToString(Request.Form["bathroomOption"]);
                var bathroomType = new List<FloorPlanBathroomTypeModel>();
                if (LutBathroomTypeID != null && !LutBathroomTypeID.Contains(","))
                {
                    bathroomType.Add(new FloorPlanBathroomTypeModel
                    {
                        LutBathroomTypeID = Convert.ToInt32(LutBathroomTypeID),
                        LutBathroomTypeOptionID = Convert.ToInt32(LutBathroomTypeOptionID),
                    });
                }
                else if (!string.IsNullOrEmpty(LutBathroomTypeID) && LutBathroomTypeID.Contains(","))
                {
                    for (int i = 0; i < LutBathroomTypeID.Split(',').Length; i++)
                    {
                        bathroomType.Add(new FloorPlanBathroomTypeModel
                        {
                            LutBathroomTypeID = Convert.ToInt32(LutBathroomTypeID.Split(',')[i]),
                            LutBathroomTypeOptionID = Convert.ToInt32(LutBathroomTypeOptionID.Split(',')[i]),
                        });
                    }
                }
                floorPlanTypeModel.FloorPlanBathroomType = bathroomType;
                var result = _floorPlanTypeService.EditFloorPlanType(floorPlanTypeModel);
                //adding the document here 
                if (floorPlanTypeModel.Files != null && floorPlanTypeModel.Files.Count() > 0)
                {
                    List<UploadResponse> uploadResponses = await SubmitFloorPlanDocument(floorPlanTypeModel.Files, Convert.ToInt32(floorPlanTypeModel.ProjectID), floorPlanTypeModel.CaseId, DocumentCategoryName.Project, DocumentCategoryName.DocumentSubCategoryName.FloorPlan, floorPlanTypeModel);

                    var LuDocumentCategoryId = _floorPlanTypeService.getLuDocumentCategoryId(DocumentCategoryName.Project, DocumentCategoryName.DocumentSubCategoryName.FloorPlan);

                    _floorPlanTypeService.SaveFloorPlanFile(floorPlanTypeModel, uploadResponses,
                        Convert.ToInt32(LuDocumentCategoryId), Convert.ToString(floorPlanTypeModel.FloorPlanTypeID), userName);
                }
                return Json(new { success = result, isRefreshGrid = true, message = "Record Updated Successfully." });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = "Exception: " + ex.Message });
            }
        }
        [HttpPost]
        public ActionResult DeleteFloorPlan(int floorPlanTypeId)
        {
            var userName = UserSession.GetUserSession(_httpContextAccessor.HttpContext).UserName;
            return Json(_floorPlanTypeService.DeleteFloorPlantype(floorPlanTypeId, userName));
        }
        [RequestSizeLimit(524288000)] 
        [HttpPost]
        public async Task<IActionResult> AddFloorPlanType(FloorPlanTypeModel floorPlanTypeModel)
        {
            try
            {
                var userName = UserSession.GetUserSession(_httpContextAccessor.HttpContext).UserName;
                var LutBathroomTypeID = Request.Form["bathroomTypes"];
                var LutBathroomTypeOptionID = Request.Form["bathroomOption"];
                var bathroomType = new List<FloorPlanBathroomTypeModel>();
                if (!LutBathroomTypeID.ToString().Contains(","))
                {
                    bathroomType.Add(new FloorPlanBathroomTypeModel
                    {
                        LutBathroomTypeID = Convert.ToInt32(LutBathroomTypeID),
                        LutBathroomTypeOptionID = Convert.ToInt32(LutBathroomTypeOptionID),
                    });
                }
                else
                {
                    var bathroomTypeStrings = LutBathroomTypeID.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var bathroomOptionStrings = LutBathroomTypeOptionID.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < bathroomTypeStrings.Length; i++)
                    {
                        bathroomType.Add(new FloorPlanBathroomTypeModel
                        {
                            LutBathroomTypeID = Convert.ToInt32(bathroomTypeStrings[i]),
                            LutBathroomTypeOptionID = Convert.ToInt32(bathroomOptionStrings[i]),
                        });
                    }
                }
                floorPlanTypeModel.FloorPlanBathroomType = bathroomType;
                // Save your floor plan (service call)
                var FloorPlanTypeID = await _floorPlanTypeService.AddFloorPlanTypeComplianceMatrix(floorPlanTypeModel);
                if (floorPlanTypeModel.Files != null && floorPlanTypeModel.Files.Count() > 0)
                {
                    List<UploadResponse> uploadResponses = await SubmitFloorPlanDocument(floorPlanTypeModel.Files, Convert.ToInt32(floorPlanTypeModel.ProjectID), floorPlanTypeModel.CaseId, DocumentCategoryName.Project, DocumentCategoryName.DocumentSubCategoryName.FloorPlan, floorPlanTypeModel);

                    var LuDocumentCategoryId = _floorPlanTypeService.getLuDocumentCategoryId(DocumentCategoryName.Project, DocumentCategoryName.DocumentSubCategoryName.FloorPlan);

                    _floorPlanTypeService.SaveFloorPlanFile(floorPlanTypeModel, uploadResponses,
                        Convert.ToInt32(LuDocumentCategoryId), Convert.ToString(FloorPlanTypeID), userName);
                }
                return Json(new
                {
                    success = true,
                    isRefreshGrid = true,
                    message = $"Record Added Successfully. FloorPlan created with ID: {FloorPlanTypeID}"
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Exception: " + ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteFile(int docId)
        {
            try
            {
                var result = _floorPlanTypeService.DeleteFloorPlanFile(docId);
                if (result)
                    return Json(new { success = true });
                else
                    return Json(new { success = false, message = "File could not be deleted." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        private async Task<List<UploadResponse>> SubmitFloorPlanDocument(
            List<IFormFile> files,
            int ProjectId,
            int caseId,
            string fileCategory,
            string fileSubCategory,
            FloorPlanTypeModel viewModel)
        {
            var uploadResponses = new List<UploadResponse>();
            try
            {
                var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".jpg", ".jpeg", ".png", ".gif" };
                var projReferenceId = _documentService.GetProjectReference(ProjectId);

                foreach (var file in files)
                {
                    // Validate file size (10MB limit)
                    if (file.Length > 10 * 1024 * 1024)
                    {
                        uploadResponses.Add(new UploadResponse
                        {
                            ErrorMessages = new[] { $"File '{file.FileName}' exceeds 10MB limit." }
                        });
                        continue;
                    }

                    // Validate file type
                    var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        uploadResponses.Add(new UploadResponse
                        {
                            ErrorMessages = new[] { $"File '{file.FileName}' type '{fileExtension}' is not supported." }
                        });
                        continue;
                    }

                    // Upload single file
                    var uploadResponse = await new DMSService(_config)
                        .SubmitUploadedDocument(new List<IFormFile> { file }, projReferenceId, caseId, fileCategory, fileSubCategory, viewModel.CreatedBy);

                    if (uploadResponse == null || uploadResponse[0].ErrorMessages?.Length > 0)
                    {
                        uploadResponses.Add(new UploadResponse
                        {
                            ErrorMessages = uploadResponse?[0]?.ErrorMessages ?? new[] { $"Failed to upload '{file.FileName}'." }
                        });
                    }
                    else
                    {
                        uploadResponses.Add(uploadResponse[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                uploadResponses.Add(new UploadResponse
                {
                    ErrorMessages = new[] { "Exception: " + ex.Message }
                });
            }

            return uploadResponses;
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
