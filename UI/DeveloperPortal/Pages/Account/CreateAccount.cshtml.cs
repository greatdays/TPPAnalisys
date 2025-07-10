using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortal.Pages.Account
{
    public class CreateAccountModel : PageModel
    {
        IConfiguration _config;
        public CreateAccountModel(IConfiguration config)
        {
            _config = config;
            string url = _config["AAHRApiSettings:ApiURL"];
        }

        public void OnGet()
        {
            //Models.IDM.ApplicantSignupModel model = new UserServiceClient(_config).GetLookupLists_P2();
        }

        
    }
}
