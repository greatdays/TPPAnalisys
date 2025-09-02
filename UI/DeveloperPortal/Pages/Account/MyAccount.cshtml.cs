using System.ComponentModel.DataAnnotations;
using DeveloperPortal.Constants;
using DeveloperPortal.Models.IDM;
using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortal.Pages.Account
{
    [IgnoreAntiforgeryToken]
    public class MyAccountModel : PageModel
    {
        private IConfiguration _config;
        [BindProperty]
        public ApplicantSignupModel Account { get; set; }

        public MyAccountModel(IConfiguration config)
        {
            _config = config;   
        }
        public async Task OnGetAsync(string accountType = "")
        {
            var roles = UserSession.GetUserSession(HttpContext).Roles;
            string[] appRoleList = new string[] { UserRoles.Applicant, UserRoles.CityEmployee, UserRoles.HousingAdvocate, UserRoles.Owner };
            var userRole = roles?.Where(x => appRoleList.Contains(x))?.FirstOrDefault();

            //SignupModel = new SignupModel { IsLocked = false };
            //ApplicantSignupModel = new ApplicantSignupModel(_config);

            bool isAccTypeSelected = false;
            ApplicantSignupModel applicantsignupModel = new ApplicantSignupModel(_config);
            SignupModel signupModel = new SignupModel();


         
            //if (userRole == UserRoles.Applicant && userRole != null)
            //if (userRole != null)
            //{
                
                applicantsignupModel = await UserServiceClient.GetMyAccountDetail_P2(UserSession.GetUserSession(HttpContext).UserName, _config);
                applicantsignupModel.FirstName = !string.IsNullOrEmpty(applicantsignupModel.FirstName) ? applicantsignupModel.FirstName : UserSession.GetUserSession(HttpContext).FirstName;
                applicantsignupModel.MiddleName = !string.IsNullOrEmpty(applicantsignupModel.MiddleName) ? applicantsignupModel.MiddleName : UserSession.GetUserSession(HttpContext).MiddleName;
                applicantsignupModel.LastName = !string.IsNullOrEmpty(applicantsignupModel.LastName) ? applicantsignupModel.LastName : UserSession.GetUserSession(HttpContext).LastName;
                applicantsignupModel.EmailId = !string.IsNullOrEmpty(applicantsignupModel.EmailId) ? applicantsignupModel.EmailId : UserSession.GetUserSession(HttpContext).Email;
                applicantsignupModel.CurrentFirstName = applicantsignupModel.FirstName;
                applicantsignupModel.CurrentLastName = applicantsignupModel.LastName;

                Account = applicantsignupModel;
            //}
        }
        public IActionResult OnPostUpdate([FromBody] int num)
        {
            return new JsonResult(new { success = true, received = num });
        }


        //public IActionResult OnPostUpdate([FromBody] ApplicantSignupModel account)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    // Save/update logic
        //    return new JsonResult(new { success = true, message = "Account updated!" });
        //}
        //public async Task<IActionResult> OnPostSaveAsync()
        //{
        //    return new JsonResult(new { success = true, message = "Got here!" });
        //}


    }



}
