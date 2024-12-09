using DeveloperPortal.Application;
using DeveloperPortal.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace DeveloperPortal.Pages
{
    public class DashboardModel : PageModel
    {
        public IConfigurationRoot Configuration { get; set; }
        public int NewProjRecordCount { get; set; }
        public List<string?> PlanReviewList { get; private set; }
        public int PlanReviewRecordCount { get; set; }
        public List<string?> SiteInspectionList { get; private set; }
        public int SiteInspectionRecordCount { get; set; }
        public List<string?> NACInspectionList { get; private set; }
        public int NACRecordCount { get; set; }
        public List<string?> CompletedCertList { get; private set; }
        public int CompletedCertRecordCount { get; set; }
        

        public List<string?> NewProjectsList { get; set; } = new List<string?>();
        //public Startup(IConfigurationRoot configuration) { }
        public void OnGet()
        {
        }
    }
}
