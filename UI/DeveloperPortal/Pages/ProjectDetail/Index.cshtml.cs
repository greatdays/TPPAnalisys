using DeveloperPortal.Application;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortal.Pages.ProjectDetails
{
    public class IndexModel : PageModel
    {

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


        public IndexModel(IConfiguration configuration, IProjectDetailService projectDetailService)
        {
            _config = configuration;
            _projectDetailService = projectDetailService;
        }


        public void OnGet()
        {
            ProjectSummary = new ProjectSummaryModel();
            if (!string.IsNullOrWhiteSpace(Id))
            {
                ProjectSummary = _projectDetailService.GetProjectSummary(Convert.ToInt32(Id));
                TempData["commentCategory"] = ProjectSummary.ProblemCase;
                ProjectSummary.ProjectAssessors = _projectDetailService.GetProjectAssessors(Convert.ToInt32(ProjectSummary.ProjectId));
                SiteData = new SiteDataModel();
                SiteData.ProjectSiteID = ProjectSummary.ProjectSiteId;
                SiteData.ProjectId = ProjectSummary.ProjectId;
                
                //ProjectSummary.ProjectDetailModel  = ProjectDetailServiceClient.GetProjectDetailByCaseId(Id); ;
                //if (null != projectSummary.ProjectDetailModel)
                //{
                //    projectSummary.ProjectDetailModel.HIMS_RECRecordDocs_URL = "";// AppConfiguration.GetConfigValue("HIMS_RECRecordDocs_URL");
                //}

            }
        }
    }
}
