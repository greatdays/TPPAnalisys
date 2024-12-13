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


        public void OnGet()
        {
            System.Console.WriteLine($"bar is {Id}");
            System.Console.WriteLine($"bar is {ProjectId}");
            ProjectSummary = new ProjectSummaryModel();
        }
    }
}
