using System.ComponentModel.DataAnnotations;
using DeveloperPortal.Constants;
using DeveloperPortal.Models.IDM;
using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortal.Pages.Account
{
    public class MyAccountModel : PageModel
    {
        private IConfiguration _config;
        public MyAccountModel(IConfiguration config)
        {
            _config = config;
        }

        [BindProperty]
        public MyAccountInput Account { get; set; }

        public void OnGet()
        {

            Account = new MyAccountInput();
            var roles = UserSession.GetUserSession(HttpContext).Roles;
            string[] appRoleList = new string[] { UserRoles.CASp, UserRoles.CASp, UserRoles.CASp, UserRoles.CASp };
            var userRole = roles?.Where(x => appRoleList.Contains(x))?.FirstOrDefault();

            //SignupModel = new SignupModel { IsLocked = false };
            //ApplicantSignupModel = new ApplicantSignupModel(_config);

            bool isAccTypeSelected = false;
            ApplicantSignupModel applicantsignupModel = new ApplicantSignupModel(_config);
            SignupModel signupModel = new SignupModel();



            //if (userRole == UserRoles.Applicant && userRole != null)
            //if (userRole != null)
            //{

            applicantsignupModel =  UserServiceClient.GetMyAccountDetail_P2(UserSession.GetUserSession(HttpContext).UserName, _config).Result;
            Account.FirstName = !string.IsNullOrEmpty(applicantsignupModel.FirstName) ? applicantsignupModel.FirstName : UserSession.GetUserSession(HttpContext).FirstName;
            Account.MiddleName = !string.IsNullOrEmpty(applicantsignupModel.MiddleName) ? applicantsignupModel.MiddleName : UserSession.GetUserSession(HttpContext).MiddleName;
            Account.LastName = !string.IsNullOrEmpty(applicantsignupModel.LastName) ? applicantsignupModel.LastName : UserSession.GetUserSession(HttpContext).LastName;
            Account.EmailId = !string.IsNullOrEmpty(applicantsignupModel.EmailId) ? applicantsignupModel.EmailId : UserSession.GetUserSession(HttpContext).Email;
            applicantsignupModel.CurrentFirstName = applicantsignupModel.FirstName;
            applicantsignupModel.CurrentLastName = applicantsignupModel.LastName;
            Account.LutPhoneTypeCdList = applicantsignupModel.LutPhoneTypeCdList;
            Account.LutPreDirCdList = applicantsignupModel.LutPreDirCdList;
                
            Account.LutStreetTypeList = applicantsignupModel.LutStreetTypeList;
            Account.LutStateCDList = applicantsignupModel.LutStateCDList;



           
           // Account = applicantsignupModel;


            // Load existing account data here
            //Account = new MyAccountInput
            //{
            //    FirstName = "BLANCA",
            //    MiddleName = "ANDREA",
            //    LastName = "RAMIREZ",
            //    EmailId = "mayur@yopmail.com",
            //    LutPhoneTypeCd = "H",
            //    PhoneNumber = "(213) 247-0014",
            //    Company = "TAX CREDIT",
            //    Title = "RESIDENT MANAGER",
            //    IsPostBox = false,
            //    StreetNumber = "",
            //    StreetName = "CARLTON WAY",
            //    City = "LOS ANGELES",
            //    LutStateCD = "CA",
            //    ZipCode = "90028"
            //};
        }

        public IActionResult OnPostUpdate([FromForm] MyAccountInput input)
        {

            // Here you can save/update your database

            return new JsonResult(new { success = true, received = input });
        }
    }

    public class MyAccountInput
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string LutPhoneTypeCd { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneExtension { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public bool IsPostBox { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string LutStateCD { get; set; }
        public string ZipCode { get; set; }
        public string LutPreDirCd { get; set; }
        public string LutStreetTypeCd { get; set; }
        public string UnitNumber { get; set; }

        public string PostBoxNum { get; set; }
        public List<LutPhoneType> LutPhoneTypeCdList { get; set; } = new();
        public List<LutPreDir> LutPreDirCdList { get; set; } = new();
        public List<LutStreetType> LutStreetTypeList { get; set; } = new();
        public List<LutState> LutStateCDList { get; set; } = new();
    }
}
