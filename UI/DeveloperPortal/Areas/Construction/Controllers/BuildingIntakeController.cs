using ComCon.DataAccess.Models.Helpers;
using DeveloperPortal.Application.ProjectDetail.Implementation;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.AspNetCore.Mvc;

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
        private IUnitImportService _unitImportService;
        private readonly IWebHostEnvironment _env;
        private readonly string UserName;

        public BuildingIntakeController(IConfiguration configuration, IHttpContextAccessor contextAccessor, IProjectDetailService projectDetailService, IUnitImportService unitImportService, IWebHostEnvironment env, IBuildingIntakeService buildingIntakeService)
        {
            _config = configuration;
            _contextAccessor = contextAccessor;
            _projectDetailService = projectDetailService;
            _unitImportService = unitImportService;
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
            //var _buildingModel = (BuildingModel)TempData["buildingModel"];
            //buildingModel.CaseId = _buildingModel.CaseId;
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

        #endregion

    }
}
