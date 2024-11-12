using DeveloperPortal.Application;
using DeveloperPortal.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeveloperPortal.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class DashboardController : Controller
    {
        public IConfigurationRoot Configuration { get; set; }
        public List<string?> DashboardData { get; private set; }

        // GET: api/<DashboardController>
        [HttpPost]
        public JsonResult GetProjectData()
        {
            string? dashboardCategory = Request.Form["name"].FirstOrDefault();
            object objDashboardData = HttpContext.Session.GetString("DashboardData");
            DataTable dt = new DataTable();

            if (objDashboardData != null)
            {
                dt = JsonConvert.DeserializeObject<DataTable>(HttpContext.Session.GetString("DashboardData"));
            }
            else
            {
                //dt = GetAllConstructionCases();
                Dashboard dashboard = new Dashboard();
                List<uspRoGetAllConstructionCasesResult> list = dashboard.GetAllConstructionCases();
                //List<uspRoGetAllConstructionCasesResult> list = GetAllConstructionCasesEF().Result;
                
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                 dt = new DataTable();
                if (!string.IsNullOrEmpty(json))
                {
                    dt = JsonConvert.DeserializeObject<DataTable>(json);
                }

                HttpContext.Session.SetString("DashboardData", JsonConvert.SerializeObject(dt));
            }

            /*DataRow[] drNewProjColl = dt.Select("Status='Under Document Review'"); //Type='New Construction Project' AND
            DataRow[] drPlanReviewColl = dt.Select("Status='Ready for Design Review'");
            DataRow[] drSiteInspectionColl = dt.Select("Status='Site Case In Progress'");
            DataRow[] drNACColl = dt.Select("Status='NAC Inspection IN Progress'");
            DataRow[] drCompletedCertColl = dt.Select("Status='City Compliance Certificate Issued'");*/

            //initialize
            DataRow[] drColl = Array.Empty<DataRow>();
            switch (dashboardCategory)
            {
                case "NewProjects":
                    drColl = dt.Select("Status='Under Document Review'"); //Type='New Construction Project' AND
                    break;
                case "PlanReview":
                    drColl = dt.Select("Status='Ready for Design Review'");
                    break;
                case "SiteInspection":
                    drColl = dt.Select("Status='Site Case In Progress'");
                    break;
                case "NACInspection":
                    drColl = dt.Select("Status='NAC Inspection IN Progress'");
                    break;
                case "CompletedCert":
                    drColl = dt.Select("Status='City Compliance Certificate Issued'");
                    break;
                default:
                    break;
            }

            //DashboardData = drColl.Select(x => new ResultSet { ProjectName=x["ProjectName"].ToString()}).ToList();
            //DashboardData.Sort();

            ResultSet rs = new ResultSet();
            List<ResultSet> retProjects = new List<ResultSet>();

            foreach (var data in drColl)
            {
                rs = new ResultSet();
                rs.ProjectName = data["ProjectName"].ToString();
                rs.CaseId = data["CaseId"].ToString();
                retProjects.Add(rs); 
            }

            return Json(retProjects);
        }

        // GET api/<DashboardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DashboardController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DashboardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DashboardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        /*private DataTable GetAllConstructionCases()
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = configBuilder.Build();

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
        private async Task<List<uspRoGetAllConstructionCasesResult>> GetAllConstructionCasesEF()
        {
            AahrdevContext context = new AahrdevContext();
            List<uspRoGetAllConstructionCasesResult> result = await context.uspRoGetAllConstructionCases();
            
            return result;
        }*/
    }

    internal class ResultSet
    {
        public string ProjectName { get; internal set; }
        public string CaseId { get; internal set; }
    }
}
