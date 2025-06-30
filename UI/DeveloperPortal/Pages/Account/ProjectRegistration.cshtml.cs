using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Serilog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortal.Pages.Account
{
    public class ProjectRegistrationModel : PageModel
    {
       
        private readonly IAccountService _accountService;

        public ProjectRegistrationModel( IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<ActionResult> OnPostGetACHPDetails(string achpNumber)
        {
            var results = await _accountService.GetACHPDetails(achpNumber);
            var searchResult = results.FirstOrDefault();

            if (searchResult != null)
            {
                return new JsonResult(new
                {
                    ResponseCode = "200",
                    StreetName = searchResult.PropertyAddress?.Trim() ?? "",
                    AchpNumber = searchResult.FileNumber?.Trim() ?? "",
                    Response = "OK"
                });
            }
            else
            {
                return new JsonResult(new
                {
                    ResponseCode = "404",
                    StreetName = "",
                    AchpNumber = "",
                    Response = "[]"
                });
            }
        }
    }
}
