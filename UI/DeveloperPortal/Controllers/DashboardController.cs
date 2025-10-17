using System.Data;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.Dashboard;
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using DeveloperPortal.Application.ProjectDetail.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace DeveloperPortal.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class DashboardController : Controller
    {
        public IConfigurationRoot Configuration { get; set; }
        public List<string?> DashboardData { get; private set; }
        readonly ILogger<DashboardController> _logger;
        public IDashboardService _dashboardService;
        public IAppConfigService appConfigService;
        public IApnpinService _apnpinService;
        private readonly IAccountService _accountService;


        // Here we are using Dependency Injection to inject the Configuration object
        public DashboardController(IConfiguration config, IHttpContextAccessor httpConfig, ILogger<DashboardController> logger, IDiagnosticContext diagnosticContext, IDashboardService dashboardService, IAppConfigService appConfigService, IApnpinService apnpinService, IAccountService accountService)
        {
            _logger = logger;
            _dashboardService = dashboardService;
            this.appConfigService = appConfigService;
            _apnpinService = apnpinService;
            _accountService = accountService;
        }

        //Ananth commented for testing
        [HttpPost]
        public async Task<List<DashboardDataModel>> GetMyProjectData()
        {

            List<DashboardDataModel> list = await _dashboardService.GetAllConstructionCasesForUserByUserID();

            return list;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Dashboard"); // this loads Views/Dashboard/Dashboard.cshtml
        }

        // GET: api/<DashboardController>
        [HttpPost]
        public async Task<JsonResult> GetProjectData()
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
                     //Ananth commented for testing
                List<DashboardDataModel> list = await _dashboardService.GetAllConstructionCases(); //Ananth commented for testing
                //List<uspRoGetAllConstructionCasesResult> list = GetAllConstructionCasesEF().Result;

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                dt = new DataTable();
                if (!string.IsNullOrEmpty(json))
                {
                    dt = JsonConvert.DeserializeObject<DataTable>(json);
                }

                HttpContext.Session.SetString("DashboardData", JsonConvert.SerializeObject(dt));
            }


            //initialize
            DataRow[] drColl = Array.Empty<DataRow>();
            ResultSet rs = new ResultSet();
            List<ResultSet> retProjects = new List<ResultSet>();
            if (objDashboardData != null)
            {
                if (!string.IsNullOrWhiteSpace(dashboardCategory))
                {
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

                    foreach (var data in drColl)
                    {
                        rs = new ResultSet();
                        rs.ProjectName = data["ProjectName"].ToString();
                        rs.CaseId = data["CaseId"].ToString();
                        retProjects.Add(rs);
                    }
                    return Json(retProjects);
                }

                drColl = dt.Select();

                foreach (var data in drColl)
                {
                    rs = new ResultSet();
                    rs.CaseId = data["CaseId"].ToString();
                    rs.AcHPFileProjectNumber = data["AcHPFileProjectNumber"].ToString();
                    rs.ProjectName = data["ProjectName"].ToString();
                    rs.ProjectAddress = data["ProjectAddress"].ToString();
                    rs.Type = data["Type"].ToString();
                    rs.OccpancyType = "";//data["OccpancyType"].ToString();
                    rs.NoofSites = 0;//data["NoofSites"].ToString();
                    rs.TotalUnits = 0;// data["Type"].ToString();
                    rs.Status = data["Status"].ToString();
                    retProjects.Add(rs);
                }
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

        public async Task<ActionResult> GetACHPDetails(string achpNumber)
        {
            var results = await _accountService.GetProjectDetailByFileNumberAsync(achpNumber);

            var project = results?.FirstOrDefault();

            if (project != null)
            {
                var streetName = project.ProjectSites?.FirstOrDefault()?.SiteAddress?.Trim() ?? "";

                return new JsonResult(new
                {
                    ResponseCode = "200",
                    StreetName = streetName,
                    AchpNumber = project.FileGroup?.Trim() ?? "",
                    projectId = project.ProjectId.ToString(),
                    Response = "OK"
                });
            }

            return new JsonResult(new
            {
                ResponseCode = "404",
                StreetName = "",
                AchpNumber = "",
                projectId = "",
                Response = "[]"
            });
        }


        public async Task<JsonResult> SubmitProjects([FromForm] List<string> projects)
        {
            var achpSet = new HashSet<string>();
            var (saved, notSaved) = await _accountService.SaveAssnPropContactAsync(projects, HttpContext);
            return new JsonResult(new { success = true, message = "Projects submitted successfully." });
        }


        public async Task<ActionResult> GetAPNProjectName(string APNNumber)
        {
            if (string.IsNullOrEmpty(APNNumber))
            {
                return new JsonResult(new List<object>()); // Return an empty list for an empty APN
            }

            // 1. Call your service to get the results
            var results = _accountService.GetAPNProjectName(APNNumber).Result;

            if (results == null)
            {
                return new JsonResult(new List<object>()); // Return an empty list if no results are found
            }


            return new JsonResult(results);
        }



        public async Task<JsonResult> CreateProject([FromBody] ProjectProvisionRequest ProjectProvisionRequestModel)
        {
            bool result = await _accountService.CreateProjectWithNewAPNandSite(ProjectProvisionRequestModel, HttpContext);


            return new JsonResult(new { success = true, message = "Projects submitted successfully." });
        }

    }

    internal class ResultSet
    {
        public string AcHPFileProjectNumber { get; internal set; }
        public string ProjectName { get; internal set; }
        public string ProjectAddress { get; internal set; }
        public string Type { get; internal set; }
        public string CaseId { get; internal set; }
        public string OccpancyType { get; internal set; }
        public int NoofSites { get; internal set; }
        public int TotalUnits { get; internal set; }
        public string Status { get; internal set; }
    }
}
