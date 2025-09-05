using System.ComponentModel.DataAnnotations;
using DeveloperPortal.Application.ProjectDetail.Implementation;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Constants;
using DeveloperPortal.DataAccess.Entity.Models.IDM;
using DeveloperPortal.Models.IDM;
using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortal.Pages.Account
{
    public class MyAccountModel : PageModel
    {
        private IConfiguration _config;
        private ApplicantSignupModel applicantsignupModel;
        private IAccountService _accountService;
        public MyAccountModel(IConfiguration config, IAccountService service)
        {
            _config = config;
            _accountService= service;
            applicantsignupModel = new ApplicantSignupModel(_config);       
        }

        [BindProperty]
        public MyAccountInput Account { get; set; }

        public void OnGet()
        {
            var sessionUser = HttpContext.Session.GetObjectFromJson<UserSession>("AppUser");

            string AccountType = "";
            Account = new MyAccountInput();
            var roles = UserSession.GetUserSession(HttpContext).Roles;

            string[] appRoleList = new string[] { UserRoles.NAC, UserRoles.GeneralContractor, UserRoles.Architect, UserRoles.PropertyDeveloper, UserRoles.CASp,UserRoles.Guest };
            var userRole = roles?.Where(x => appRoleList.Contains(x))?.FirstOrDefault();
            bool isAccTypeSelected = false;
            
            if (userRole != null) { 
 
                    applicantsignupModel = UserServiceClient.GetMyAccountDetail_P2(sessionUser.UserName , _config).Result;
                    Account.FirstName = !string.IsNullOrEmpty(applicantsignupModel.FirstName) ? applicantsignupModel.FirstName : sessionUser.FirstName;
                    Account.MiddleName = !string.IsNullOrEmpty(applicantsignupModel.MiddleName) ? applicantsignupModel.MiddleName : UserSession.GetUserSession(HttpContext).MiddleName;
                    Account.LastName = !string.IsNullOrEmpty(applicantsignupModel.LastName) ? applicantsignupModel.LastName : sessionUser.LastName;
                    Account.EmailId = !string.IsNullOrEmpty(applicantsignupModel.EmailId) ? applicantsignupModel.EmailId : sessionUser.Email;
                    applicantsignupModel.CurrentFirstName = applicantsignupModel.FirstName;
                    applicantsignupModel.CurrentLastName = applicantsignupModel.LastName;
                    Account.LutPhoneTypeCdList = applicantsignupModel.LutPhoneTypeCdList;
                    Account.LutPhoneTypeCd = applicantsignupModel.LutPhoneTypeCd;

                    Account.LutPreDirCdList = applicantsignupModel.LutPreDirCdList;
                    Account.LutPreDirCd = applicantsignupModel.LutPreDirCd;

                    Account.LutStreetTypeList = applicantsignupModel.LutStreetTypeList;
                    Account.LutStreetTypeCd = applicantsignupModel.LutStreetTypeCD;
                    Account.LutStateCDList = applicantsignupModel.LutStateCDList;
                    Account.LutStateCD = applicantsignupModel.LutStateCD;

                    Account.PhoneNumber = applicantsignupModel.PhoneNumber;
                    Account.PhoneExtension = applicantsignupModel.PhoneExtension;
                    Account.Company = applicantsignupModel.Company;
                    Account.Title = applicantsignupModel.Title;
                    Account.StreetNum = applicantsignupModel.StreetNum;
                    Account.UnitNumber = applicantsignupModel.UnitNumber;
                    Account.City = applicantsignupModel.City;
                    Account.Zipcode = applicantsignupModel.Zipcode;
                    Account.ContactID= applicantsignupModel.ContactID;
                    Account.ContactIdentifierID= applicantsignupModel.ContactIdentifierID;
                    Account.IDMUserID= applicantsignupModel.IDMUserID;
                    Account.IsAccountTypeSelected =applicantsignupModel.IsAccountTypeSelected;

           }
        }

        public IActionResult OnPostUpdate([FromForm] MyAccountInput signupModel)
        {
            var userSession = UserSession.GetUserSession(HttpContext);
            if (userSession == null)
            {
                return new JsonResult(new { success = false, error = "User session not found." });
            }
            applicantsignupModel.FirstName = signupModel.FirstName;
            applicantsignupModel.MiddleName = signupModel.MiddleName;
            applicantsignupModel.LastName = signupModel.LastName;
            applicantsignupModel.EmailId = signupModel.EmailId;

            applicantsignupModel.PhoneNumber = signupModel.PhoneNumber;
            applicantsignupModel.PhoneExtension = signupModel.PhoneExtension;

            applicantsignupModel.Company = signupModel.Company;
            applicantsignupModel.Title = signupModel.Title;

            applicantsignupModel.StreetNum = signupModel.StreetNum;
            applicantsignupModel.UnitNumber = signupModel.UnitNumber;
            applicantsignupModel.City = signupModel.City;
            applicantsignupModel.Zipcode = signupModel.Zipcode;

            applicantsignupModel.LutPhoneTypeCd = signupModel.LutPhoneTypeCd;
            applicantsignupModel.LutPreDirCd = signupModel.LutPreDirCd;
            applicantsignupModel.LutStreetTypeCD = signupModel.LutStreetTypeCd;
            applicantsignupModel.LutStateCD = signupModel.LutStateCD;

            // Required for contact update
            applicantsignupModel.CurrentFirstName = signupModel.FirstName;
            applicantsignupModel.CurrentLastName = signupModel.LastName;
            OrganizationContactModel organizations = new OrganizationContactModel();
            IDMUser idmuser = new IDMUser();
           
            idmuser.FirstName = signupModel.FirstName.Trim();
            idmuser.MiddleName = !string.IsNullOrEmpty(signupModel.MiddleName) ? signupModel.MiddleName.Trim() : "";
            idmuser.LastName = signupModel.LastName.Trim();
            idmuser.UserName =UserSession.GetUserSession(HttpContext).UserName.Trim();
            idmuser.Email = signupModel.EmailId.Trim();
            idmuser.ContactPhone = signupModel.PhoneNumber;
            idmuser.Provider = UserSession.GetUserSession(HttpContext).Provider.Trim();

            // Authenticate and update IDM profile
            IDMAuthenticate authenticate = new IDMAuthenticate(_config);
            idmuser = authenticate.UpdateIDMUserProfile(idmuser);
           
             /*Update User account details*/
            //int ContactID = applicantsignupModel.SaveContactInformation(applicantsignupModel, UserSession.GetUserSession(HttpContext).UserName, DeveloperPortal.Constants.AppConstant.WebRegister);
            int contactId =  _accountService.ContactIdentifierSave(applicantsignupModel, UserSession.GetUserSession(HttpContext).UserName, Constants.AppConstant.TPPSource).Result;


            return new JsonResult(new { success = true, received = signupModel });
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
        public int? StreetNum { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string LutStateCD { get; set; }
     
        public string Zipcode { get; set; }
        public string LutPreDirCd { get; set; }
        public string LutStreetTypeCd { get; set; }
        public string UnitNumber { get; set; }

        public string PostBoxNum { get; set; }
        public int ContactID { get; set; }
        public int ContactIdentifierID { get; set; }
        public int? IDMUserID { get; set; }
        public bool IsAccountTypeSelected { get; set; }
        public bool IsLocked { get; set; }
        public List<LutPhoneType> LutPhoneTypeCdList { get; set; } = new();
        public List<LutPreDir> LutPreDirCdList { get; set; } = new();
        public List<LutStreetType> LutStreetTypeList { get; set; } = new();
        public List<LutState> LutStateCDList { get; set; } = new();
    }
}