using System.Web.Mvc;
using DeveloperPortal.Application;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace DeveloperPortal.Pages.ProjectDetails
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public int ProjectSiteID { get; set; }
        public int ProjectDetailId { get; set; }
        [FromQuery(Name = "Id")]
        public string Id { get; set; }
        [FromQuery(Name = "projectId")]
        public string ProjectId { get; set; }
        [FromQuery(Name = "tabName")]
        public string TabName { get; set; }
        public ProjectSummaryModel ProjectSummary { get; set; }
        public SiteDataModel SiteData { get; set; }

        private IConfiguration _config;
        private IProjectDetailService _projectDetailService;
        private readonly IFloorPlanTypeService _floorPlanService;

        public IndexModel(IConfiguration configuration, IProjectDetailService projectDetailService, IFloorPlanTypeService floorPlanService)
        {
            _config = configuration;
            _projectDetailService = projectDetailService;
            _floorPlanService = floorPlanService;
        }

        public FloorPlanTypeModel FloorPlanTypes { get; set; }
        public async Task OnGet()
        {
            ProjectSummary = new ProjectSummaryModel();
            FloorPlanTypes = new FloorPlanTypeModel();
            if (!string.IsNullOrWhiteSpace(Id))
            {
                ProjectSummary = _projectDetailService.GetProjectSummary(Convert.ToInt32(Id));
                List<string> reviewNote = new List<string>();
                reviewNote= _projectDetailService.GetReviewNote(Convert.ToInt32(Id));
                ProjectSummary.ReviewNote = reviewNote;
                TempData["commentCategory"] = ProjectSummary.ProblemCase;
                ProjectSummary.ProjectAssessors = _projectDetailService.GetProjectAssessors(Convert.ToInt32(ProjectSummary.ProjectId));
                SiteData = new SiteDataModel();
                SiteData.ProjectSiteID = ProjectSummary.ProjectSiteId;
                SiteData.ProjectId = ProjectSummary.ProjectId;
                FloorPlanTypes = await _floorPlanService.GetFloorPlanTypes(SiteData.ProjectSiteID, SiteData.ProjectId);
                //ProjectSummary.ProjectDetailModel  = ProjectDetailServiceClient.GetProjectDetailByCaseId(Id); ;
                //if (null != projectSummary.ProjectDetailModel)
                //{
                //    projectSummary.ProjectDetailModel.HIMS_RECRecordDocs_URL = "";// AppConfiguration.GetConfigValue("HIMS_RECRecordDocs_URL");
                //}

            }
        }
    }
}
