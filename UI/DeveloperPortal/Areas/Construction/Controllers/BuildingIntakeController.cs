using ComCon.DataAccess.Models.Helpers;
using DeveloperPortal.Application.ProjectDetail;
using DeveloperPortal.Application.ProjectDetail.Implementation;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeveloperPortal.Areas.Construction.Controllers
{
    [Area("Construction")]
    public class BuildingIntakeController : Controller
    {
        #region Construtor

        private IConfiguration _config;
        private IHttpContextAccessor _contextAccessor;
        private IProjectDetailService _projectDetailService;
        private IBuildingIntakeService _buildingIntakeService;
        private readonly IWebHostEnvironment _env;
        private readonly string UserName;

        public BuildingIntakeController(IConfiguration configuration, IHttpContextAccessor contextAccessor, IProjectDetailService projectDetailService,
            IWebHostEnvironment env, IBuildingIntakeService buildingIntakeService)
        {
            _config = configuration;
            _contextAccessor = contextAccessor;
            _projectDetailService = projectDetailService;
            _env = env;
            _buildingIntakeService = buildingIntakeService;
            //Username = UserSession.GetUserSession().UserName
            UserName = "jhirpara";
        }

        /// <summary>
        /// POST - SaveBuilding
        /// </summary>
        /// <param name="buildingModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SaveBuilding(BuildingModel buildingModel)
        {
            JsonData<JsonStatus> data = new JsonData<JsonStatus>(new JsonStatus());
            buildingModel.Username = UserName;
            //Set Selected site CaseId 
            if (!string.IsNullOrWhiteSpace(buildingModel.SelectedSiteId))
            {
                buildingModel.CaseId = Convert.ToInt32(buildingModel.SelectedSiteId);
                var propSnapshotDetails = await _projectDetailService.GetPropSnapshotDetails(buildingModel.ProjectSiteId.Value);
                //Set Selected site ProjectId  and APNId
                if (propSnapshotDetails != null)
                {
                    buildingModel.ProjectId = propSnapshotDetails.ProjectId;
                    buildingModel.APNId = propSnapshotDetails.APNId;
                }
                if (true == await _buildingIntakeService.SaveAddBuilding(buildingModel))
                {
                    data.Result.Status = true;
                }
            }
            return Json(data);
        }

        // <summary>
        /// Post - AddBuildingFromNewCompliance
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddBuilding(SiteInformationParamModel paramModel, int caseId)
        {
            int projectSiteId = 0;
            BuildingModel buildingModel = new BuildingModel();
            buildingModel.SiteList = new List<SelectListItem>();
            if (paramModel.SiteInformationData != null && paramModel.SiteInformationData.Count > 0)
            {
                projectSiteId = paramModel.SiteInformationData[0].ProjectSiteID;
                buildingModel = await _buildingIntakeService.GetAddBuildingDetails(projectSiteId);
                // If show all addresses then uncomment below code
                var projectSiteIdList = paramModel.SiteInformationData.Select(x => x.ProjectSiteID).ToList();
                buildingModel.BuildingAddressList = await _buildingIntakeService.GetBuildingAddressDetails(projectSiteIdList);
                buildingModel.SiteList = paramModel.SiteInformationData.Select(x => new SelectListItem
                {
                    Text = x.FileNumber,
                    Value = x.ProjectSiteID.ToString()
                }).ToList();
                buildingModel.SiteCaseIdList = paramModel.SiteInformationData.Select(x => new SelectListItem
                {
                    Text = x.CaseID.ToString(),
                    Value = x.ProjectSiteID.ToString()
                }).ToList();

            }
            buildingModel.CaseId = caseId;
            var data = await this.RenderViewAsync("../../Areas/Construction/Views/ProjectDetail/_AddBuilding", buildingModel, true);
            return Json(data);
        }


        /// <summary>
        /// SaveBuildingSummary
        /// </summary>
        /// <param name="buildingModel"></param>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SaveBuildingSummary([FromForm] BuildingParkingInformationModal buildingModel)
        {
            var result = false;
            try
            {
                if (buildingModel != null && buildingModel.PropSnapshotID > 0)
                {
                    result = await _buildingIntakeService.SaveBuildingSummary(buildingModel, UserName);
                }
            }
            catch (Exception e)
            {
                result = false;
            }
            return Json(result);
        }


        /// <summary>
        /// GET - GetBuildingDetails
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetBuildingDetails(int projectSiteId, int caseId)
        {
            BuildingModel buildingModel =await _buildingIntakeService.GetBuildingDetailForEdit(projectSiteId);
            return Json(buildingModel);
        }
        #endregion

    }
}
