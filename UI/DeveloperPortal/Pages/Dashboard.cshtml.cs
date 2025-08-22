using DeveloperPortal.Application;
using DeveloperPortal.Application.ProjectDetail.Implementation;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace DeveloperPortal.Pages
{
    [IgnoreAntiforgeryToken]
    public class DashboardModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DashboardModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public string AchpNumber { get; set; }

        public async Task<ActionResult> OnPostGetACHPDetails(string achpNumber)
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


        [BindProperty]
        public List<string> Projects { get; set; }


        public async Task<JsonResult> OnPostSubmitProjects([FromForm] List<string> projects)
        {
            var achpSet = new HashSet<string>();
            var (saved, notSaved) = await _accountService.SaveAssnPropContactAsync(projects, HttpContext);
            return new JsonResult(new { success = true, message = "Projects submitted successfully." });
        }
    }
}
    
    

