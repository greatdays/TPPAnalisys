using Azure.Core;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Models.IDM;
using DeveloperPortal.Pages.ProjectDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperPortal.Controllers
{
    [Authorize]
    public class FloorPlanTypeController : Controller
    {

        private readonly IFloorPlanTypeService _floorPlanTypeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FloorPlanTypeController(IFloorPlanTypeService floorPlanTypeService, IHttpContextAccessor httpContextAccessor)
        {
            _floorPlanTypeService = floorPlanTypeService;
            _httpContextAccessor = httpContextAccessor;
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
        [HttpPost]
        public JsonResult _EditFloorPlanType(FloorPlanTypeModel floorPlanTypeModel)
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
            return Json(new { success = result, isRefreshGrid = true, message = "Record Updated Successfully."});
        }
        [HttpPost]
        public ActionResult DeleteFloorPlan(int floorPlanTypeId)
        {
            var userName = UserSession.GetUserSession(_httpContextAccessor.HttpContext).UserName;
            return Json(_floorPlanTypeService.DeleteFloorPlantype(floorPlanTypeId, userName));
        }
        [HttpPost]
        public IActionResult AddFloorPlanType(FloorPlanTypeModel floorPlanTypeModel)
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
                var result = false;
                try
                {
                    var FloorPlanTypeID = _floorPlanTypeService.AddFloorPlanTypeComplianceMatrix(floorPlanTypeModel);
                    result = true;
                    return Json(new { success = result, isRefreshGrid = true, message = "Record Added Successfully.FloorPlan created with ID: " + FloorPlanTypeID.Result });
                }
                catch (Exception ex)
                {
                    return Json(new { success = result, isRefreshGrid = true, message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Exception: " + ex.Message });
            }
        }
    }
}
