using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace DeveloperPortal.Pages.Applicant
{
    public class SummaryModel : PageModel
    {
        IConfiguration _config;
        Models.IDM.ApplicantSignupModel model;

        public SummaryModel(IConfiguration config)
        {
            _config = config;
            //model = new UserServiceClient(_config).GetLookupLists_P2();
            //GetLookupLists();
        }
        public void OnGet()
        {
            
        }
    }
}
