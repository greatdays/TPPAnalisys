using DeveloperPortal.Application;
using DeveloperPortal.Application.ProjectDetail.Implementation;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.Dashboard;
using Microsoft.AspNetCore.Http;
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


        public async Task<ActionResult> OnPostGetAPNProjectName(string APNNumber)
        {
            if (string.IsNullOrEmpty(APNNumber))
            {
                return new JsonResult(new List<object>()); // Return an empty list for an empty APN
            }

            // 1. Call your service to get the results
            var results = _accountService.GetAPNProjectName(APNNumber).Result;

            if (results == null || !results.Any())
            {
                return new JsonResult(new List<object>()); // Return an empty list if no results are found
            }

            // 2. Project the results into a new format for the dropdown
            var projectList = results.Select(p => new
            {
                id = p.SiteAddressID, // The 'id' property for the dropdown value
                fullAddress = p.FullAddress // The 'fullAddress' property for the dropdown text
            }).ToList();

            // 3. Return the data as a JSON response
            return new JsonResult(projectList);
        }


      
        public async Task<JsonResult> OnPostCreateProject([FromBody] ProjectModel projectModel)
        {
            bool result = await _accountService.CreateProject(projectModel, HttpContext);


            return new JsonResult(new { success = true, message = "Projects submitted successfully." });
        }

    }
}
    
    

