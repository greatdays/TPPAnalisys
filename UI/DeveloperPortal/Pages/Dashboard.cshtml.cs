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


            //foreach (var project in projects)
            //{
            //    if (string.IsNullOrWhiteSpace(project)) continue;

            //    var parts = project.Split('-');
            //    if (parts.Length < 1 || string.IsNullOrWhiteSpace(parts[0]))
            //    {
            //        return new JsonResult(new { success = false, message = "Invalid ACHP entry detected." });
            //    }

            //    var achp = parts[0].Trim();

            //    if (!achpSet.Add(achp))
            //    {
            //        return new JsonResult(new { success = false, message = $"Duplicate ACHP number: {achp}" });
            //    }
            //}

            //// Save to DB or continue
            return new JsonResult(new { success = true, message = "Projects submitted successfully." });
        }
    }
}
    
    

