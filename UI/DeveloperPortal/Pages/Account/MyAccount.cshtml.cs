using System.ComponentModel.DataAnnotations;
using DeveloperPortal.Application.ProjectDetail.Implementation;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Constants;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.IDM;
using DeveloperPortal.Models.IDM;
using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IDMAuthenticate = DeveloperPortal.DataAccess.Entity.Models.IDM.IDMAuthenticate;

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
            Account = new MyAccountInput();
            var roles = UserSession.GetUserSession(HttpContext).Roles;

            string[] appRoleList = new string[] { UserRoles.NAC, UserRoles.GeneralContractor, UserRoles.Architect, UserRoles.PropertyDeveloper, UserRoles.CASp,UserRoles.Guest };
            var userRole = roles?.Where(x => appRoleList.Contains(x))?.FirstOrDefault();
 
           if (userRole != null) {
                    applicantsignupModel = UserServiceClient.GetMyAccountDetail_P2(sessionUser.UserName , _config).Result;
                    Account.SelectedRole = userRole;
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
                    Account.StreetNum = applicantsignupModel.HouseNum;
                    Account.StreetName = applicantsignupModel.StreetName;
                    Account.UnitNumber = applicantsignupModel.Unit;
                    Account.City = applicantsignupModel.City;
                    Account.Zipcode = applicantsignupModel.Zipcode;
                    Account.ContactID= applicantsignupModel.ContactID;
                    Account.ContactIdentifierID= applicantsignupModel.ContactIdentifierID;
                    Account.IDMUserID= applicantsignupModel.IDMUserID;
                    Account.IsAccountTypeSelected =applicantsignupModel.IsAccountTypeSelected;
                    Account.IsPostBox = applicantsignupModel.IsPostBox;

           }
        }

        public IActionResult OnPostUpdate([FromForm] MyAccountInput signupModel)
        {
            
            var userSession = UserSession.GetUserSession(HttpContext);
            if (userSession == null)
            {
                return new JsonResult(new { success = false, error = "User session not found." });
            }

            List<string> roles = new List<string>();
            string selectedLookupRole = string.Empty;
            if (signupModel.SelectedRole == string.Empty)
            {
                selectedLookupRole = UserRoles.Guest;
            }
            else
            {
                switch (signupModel.SelectedRole)
                {
                    case "Property Developer":
                        selectedLookupRole = UserRoles.PropertyDeveloper;
                        break;
                    case "Architect":
                        selectedLookupRole = UserRoles.Architect;
                        break;
                    case "CASp":
                        selectedLookupRole = UserRoles.CASp;
                        break;
                    case "General Contractor":
                        selectedLookupRole = UserRoles.GeneralContractor;
                        break;
                    case "NAC":
                        selectedLookupRole = UserRoles.NAC;
                        break;
                    default:
                        break;
                }
            }
            roles.Add(selectedLookupRole);
           

            // reload the latest model from DB/service
            applicantsignupModel = UserServiceClient.GetMyAccountDetail_P2(userSession.UserName, _config).Result;

            // Update only if provided, otherwise keep existing
            applicantsignupModel.FirstName = !string.IsNullOrWhiteSpace(signupModel.FirstName)
                ? signupModel.FirstName
                : applicantsignupModel.FirstName;

            applicantsignupModel.MiddleName = !string.IsNullOrWhiteSpace(signupModel.MiddleName)
                ? signupModel.MiddleName
                : applicantsignupModel.MiddleName;

            applicantsignupModel.LastName = !string.IsNullOrWhiteSpace(signupModel.LastName)
                ? signupModel.LastName
                : applicantsignupModel.LastName;

            applicantsignupModel.EmailId = !string.IsNullOrWhiteSpace(signupModel.EmailId)
                ? signupModel.EmailId
                : applicantsignupModel.EmailId;

            applicantsignupModel.PhoneNumber = !string.IsNullOrWhiteSpace(signupModel.PhoneNumber)
                ? signupModel.PhoneNumber
                : applicantsignupModel.PhoneNumber;

            applicantsignupModel.PhoneExtension = !string.IsNullOrWhiteSpace(signupModel.PhoneExtension)
                ? signupModel.PhoneExtension
                : applicantsignupModel.PhoneExtension;

            applicantsignupModel.Company = !string.IsNullOrWhiteSpace(signupModel.Company)
                ? signupModel.Company
                : applicantsignupModel.Company;

            applicantsignupModel.Title = !string.IsNullOrWhiteSpace(signupModel.Title)
                ? signupModel.Title
                : applicantsignupModel.Title;

            applicantsignupModel.HouseNum = signupModel.StreetNum ?? applicantsignupModel.StreetNum;
            applicantsignupModel.StreetName = signupModel.StreetName ?? applicantsignupModel.StreetName;

            applicantsignupModel.Unit = !string.IsNullOrWhiteSpace(signupModel.UnitNumber)
                ? signupModel.UnitNumber
                : applicantsignupModel.UnitNumber;

            applicantsignupModel.City = !string.IsNullOrWhiteSpace(signupModel.City)
                ? signupModel.City
                : applicantsignupModel.City;

            applicantsignupModel.Zipcode = !string.IsNullOrWhiteSpace(signupModel.Zipcode)
                ? signupModel.Zipcode
                : applicantsignupModel.Zipcode;

            applicantsignupModel.IsPostBox = signupModel.IsPostBox;

            applicantsignupModel.PostBoxNum = !string.IsNullOrWhiteSpace(signupModel.PostBoxNum)
                ? signupModel.PostBoxNum
                : applicantsignupModel.PostBoxNum;

            applicantsignupModel.LutPhoneTypeCd = !string.IsNullOrWhiteSpace(signupModel.LutPhoneTypeCd)
                ? signupModel.LutPhoneTypeCd
                : applicantsignupModel.LutPhoneTypeCd;

            applicantsignupModel.LutPreDirCd = !string.IsNullOrWhiteSpace(signupModel.LutPreDirCd)
                ? signupModel.LutPreDirCd
                : applicantsignupModel.LutPreDirCd;

            applicantsignupModel.LutStreetTypeCD = !string.IsNullOrWhiteSpace(signupModel.LutStreetTypeCd)
                ? signupModel.LutStreetTypeCd
                : applicantsignupModel.LutStreetTypeCD;

            applicantsignupModel.LutStateCD = !string.IsNullOrWhiteSpace(signupModel.LutStateCD)
                ? signupModel.LutStateCD
                : applicantsignupModel.LutStateCD;

            // Required for contact update
            applicantsignupModel.CurrentFirstName = applicantsignupModel.FirstName;
            applicantsignupModel.CurrentLastName = applicantsignupModel.LastName;

            // Update IDM user profile
            IDMUser idmuser = new IDMUser
            {
                FirstName = applicantsignupModel.FirstName.Trim(),
                MiddleName = !string.IsNullOrEmpty(applicantsignupModel.MiddleName) ? applicantsignupModel.MiddleName.Trim() : "",
                LastName = applicantsignupModel.LastName.Trim(),
                UserName =userSession.UserName.Trim(),
                Email = applicantsignupModel.EmailId.Trim(),
                ContactPhone = applicantsignupModel.PhoneNumber,
                Provider = userSession.Provider.Trim()
            };
            idmuser.AppList = new List<Models.IDM.AppDetail>();
            idmuser.AppList.Add(new Models.IDM.AppDetail()
            {
                AppKey = _config["AppSettings:AppKey"],
                AppName = _config["AppSettings:AppKey"],
                Roles = roles
            });

            IDMAuthenticate authenticate = new IDMAuthenticate(_config);
            idmuser = authenticate.UpdateIDMUserProfile(idmuser);

            // Save changes back to DB
            int contactId = _accountService
                .ContactIdentifierSave(applicantsignupModel, userSession.UserName, Constants.AppConstant.WebRegister)
                .Result;

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
        public string Extn { get; set; }
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
        public string Unit { get; set; }

        public string PostBoxNum { get; set; }
        public int ContactID { get; set; }
        public int ContactIdentifierID { get; set; }
        public int? IDMUserID { get; set; }
        public bool IsAccountTypeSelected { get; set; }
        public bool IsLocked { get; set; }
        public string SelectedRole { get; set; }
        public List<LutPhoneType> LutPhoneTypeCdList { get; set; } = new();
        public List<LutPreDir> LutPreDirCdList { get; set; } = new();
        public List<LutStreetType> LutStreetTypeList { get; set; } = new();
        public List<LutState> LutStateCDList { get; set; } = new();
    }
}