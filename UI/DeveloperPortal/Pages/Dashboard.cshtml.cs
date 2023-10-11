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
            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = configBuilder.Build();

            DataTable dt = GetAllConstructionCases();

            object objDashboardData = HttpContext.Session.GetString("DashboardData");

            if (objDashboardData != null)
            {
                dt = JsonConvert.DeserializeObject<DataTable>(HttpContext.Session.GetString("DashboardData"));
            }
            else
            {//store the data in a Session
                dt = GetAllConstructionCases();
                HttpContext.Session.SetString("DashboardData", JsonConvert.SerializeObject(dt));
            }

            //TODO: Filter conditions to be revised
            DataRow[] drNewProjColl = dt.Select("Status='Under Document Review'"); //Type='New Construction Project' AND
            DataRow[] drPlanReviewColl = dt.Select("Status='Ready for Design Review'");
            DataRow[] drSiteInspectionColl = dt.Select("Status='Site Case In Progress'");
            DataRow[] drNACColl = dt.Select("Status='NAC Inspection IN Progress'");
            DataRow[] drCompletedCertColl = dt.Select("Status='City Compliance Certificate Issued'");

            //New Projects
            NewProjectsList = drNewProjColl.Select(x => x["ProjectName"].ToString()).ToList();
            NewProjectsList.Sort();
            NewProjRecordCount = NewProjectsList.Count;

            //Plan Review
            PlanReviewList = drPlanReviewColl.Select(x => x["ProjectName"].ToString()).ToList();
            PlanReviewList.Sort();
            PlanReviewRecordCount = PlanReviewList.Count;

            //Site Inspection
            SiteInspectionList = drSiteInspectionColl.Select(x => x["ProjectName"].ToString()).ToList();
            SiteInspectionList.Sort();
            SiteInspectionRecordCount = SiteInspectionList.Count;

            //NAC
            NACInspectionList = drNACColl.Select(x => x["ProjectName"].ToString()).ToList();
            NACInspectionList.Sort();
            NACRecordCount = NACInspectionList.Count;

            //Completed Cert
            CompletedCertList = drCompletedCertColl.Select(x => x["ProjectName"].ToString()).ToList();
            CompletedCertList.Sort();
            CompletedCertRecordCount = CompletedCertList.Count;
        }

        private DataTable GetAllConstructionCases()
        {
            string? connString = Configuration.GetConnectionString("AAHR");
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "[AAHPCC].[uspRoGetAllConstructionCases]";
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = comm.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            conn.Close();
            return dt;
        }
    }
}
