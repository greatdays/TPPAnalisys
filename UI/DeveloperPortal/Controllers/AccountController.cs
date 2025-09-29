using DeveloperPortal.Constants;
using DeveloperPortal.Models;
using DeveloperPortal.Models.Helper;
using DeveloperPortal.Models.IDM;
using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Cache;
using System.Security.Claims;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
//using static System.Runtime.InteropServices.JavaScript.JSType;
//using DeveloperPortal.Models.Resources;
using System.Net.Http.Headers;
using Azure;
using Azure.Identity;
using System.Text.Json.Nodes;
using System.Text;
using DeveloperPortal.Models.Account;
using DeveloperPortal.Models.Common;
using static DeveloperPortal.ServiceClient.ServiceClient;
using ComCon.DataAccess.Models.Helpers;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.Resources;
using DeveloperPortal.Application.Notification.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using System.Web.Helpers;

namespace DeveloperPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private IConfiguration _config;
        private IHttpContextAccessor _contextAccessor;
        private IAccountService _accountService;
        private ISendNotificationEmail _sendNotificationEmail;
        // Here we are using Dependency Injection to inject the Configuration object
        public AccountController(IConfiguration config, 
            IHttpContextAccessor httpConfig, IAccountService service, ISendNotificationEmail sendNotificationEmail)
        {
            _config = config;
            _contextAccessor = httpConfig;
            _accountService = service;
            _sendNotificationEmail= sendNotificationEmail;
        }

        [Route("account/login")]
        [HttpGet]
        public IActionResult Login(string ReturnUrl = null)
            {
            return Redirect($"{_config["IDMSettings:CentralIDMURL"]}&returnUrl={_config["AppSettings:ApplicationURL"]}{ReturnUrl}");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

        #region Create Account
        [HttpPost("XDebugCreateAccount")]
        public async Task<IActionResult> XDebugCreateAccount([FromBody]JObject data)
        {
            var signupModel = new ApplicantSignupModel(_config);
            string accountType = string.Empty;

            var allStepItems = data.Properties()
                .SelectMany(prop => JArray.Parse(prop.Value.ToString()))
                .ToList();  // List<JToken>

            foreach (var item in allStepItems)
            {
                string stepName = item["step"].ToString();
                var tokens = item["Data"].ToList();

                switch (stepName)
                {
                    case "AccountType":
                        accountType = GetApplicantDataByKey("accountType", tokens);
                        break;

                    case "YourInfo":
                        signupModel.FirstName = GetApplicantDataByKey("firstName", tokens);
                        signupModel.LastName = GetApplicantDataByKey("lastName", tokens);
                        signupModel.MiddleName = GetApplicantDataByKey("middleName", tokens);
                        signupModel.EmailId = GetApplicantDataByKey("email", tokens);
                        signupModel.CompanyName = GetApplicantDataByKey("companyName", tokens);
                        signupModel.Title = GetApplicantDataByKey("title", tokens);
                        signupModel.Password = GetApplicantDataByKey("password", tokens);
                        break;

                    case "ContactInfo":
                        signupModel.PhoneNumber = GetApplicantDataByKey("phoneNumber", tokens);
                        signupModel.City = GetApplicantDataByKey("city", tokens);
                        signupModel.State = GetApplicantDataByKey("state", tokens);
                        signupModel.LutStateCD = GetApplicantDataByKey("state", tokens);
                        signupModel.Zipcode = GetApplicantDataByKey("zipCode", tokens);
                        signupModel.PhoneType = GetApplicantDataByKey("phoneType", tokens);
                        signupModel.LutPhoneTypeCd = GetApplicantDataByKey("phoneType", tokens);
                        signupModel.PhoneExtension = GetApplicantDataByKey("extension", tokens);

                        if (int.TryParse(GetApplicantDataByKey("streetNumber", tokens), out var num))
                            signupModel.StreetNum = num;

                        signupModel.StreetDir = GetApplicantDataByKey("streetDirection", tokens);
                        signupModel.LutPreDirCd = GetApplicantDataByKey("streetDirection", tokens);
                        signupModel.StreetName = GetApplicantDataByKey("streetName", tokens);
                        signupModel.StreetType = GetApplicantDataByKey("streetType", tokens);
                        signupModel.LutStreetTypeCD = GetApplicantDataByKey("streetDirection", tokens);
                        signupModel.UnitNumber = GetApplicantDataByKey("unitNumber", tokens);
                        signupModel.PostBoxNum = GetApplicantDataByKey("poBoxNumber", tokens);
                        signupModel.IsPostBox = GetApplicantDataByKey("poBox", tokens)
                                                      .Equals("Yes", StringComparison.OrdinalIgnoreCase);
                        break;

                    //case "ProjectList":
                    //    signupModel.Projects = JArray.Parse(item["Data"].ToString())
                    //                                 .Select(x => x.ToString())
                    //                                 .ToList();
                    //    break;

                    default:
                        break;
                }
            }

            return await CreateIDMAccount(signupModel, accountType);
        }

        public async Task<ActionResult> CreateIDMAccount(ApplicantSignupModel signupModel, string selectedRole)
        {
            JsonData<JsonStatus> data = new JsonData<JsonStatus>(new JsonStatus());
            string username = "";

            try
            {
                if (string.IsNullOrEmpty(signupModel.EmailId))
                {
                    username = signupModel.IDMUserName;
                }
                else
                {
                    username = signupModel.EmailId;
                    signupModel.IDMUserName = signupModel.EmailId;
                }

                var userJson = new
                {
                    UserName = username
                };

                data.Result.Data = userJson;

                // Remove model attributes that are not related to create account
                ModelState.Remove("Summary");
                ModelState.Remove("HouseNum");
                ModelState.Remove("StreetName");
                ModelState.Remove("City");
                ModelState.Remove("LutStateCD");
                ModelState.Remove("Zip");
                ModelState.Remove("PhoneNumber");
                ModelState.Remove("LutPhoneTypeCd");
                ModelState.Remove("AddressQuestion");
                ModelState.Remove("PhoneNumberQuestion");
                ModelState.Remove("PhoneNotificationOptions");
                ModelState.Remove("AdditionalPhoneNumberQuestion");
                ModelState.Remove("LutAddPhoneTypeCd");
                ModelState.Remove("AdditionalPhoneNumber");
                ModelState.Remove("AdditionalPhoneNotificationOptions");
                ModelState.Remove("AlternateContactQuestion");
                ModelState.Remove("AlternateContact_FirstName");
                ModelState.Remove("AlternateContact_LastName");
                ModelState.Remove("AlternateContact_Email");
                ModelState.Remove("AlternateContact_PhoneType");
                ModelState.Remove("AlternateContact_PhoneNumber");
                ModelState.Remove("AlternateContact_PhoneNotification");
                ModelState.Remove("AlternateContact_HouseNum");
                ModelState.Remove("AlternateContact_StreetName");
                ModelState.Remove("AlternateContact_State");
                ModelState.Remove("AlternateContact_Zipcode");
                ModelState.Remove("AlternateContact_CityName");

                if (signupModel.EmailId == null && signupModel.IDMUserName != null)
                {
                    ModelState.Remove("AdditionalEmailQuestion");
                }

                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);

                if (ModelState.IsValid && !string.IsNullOrEmpty(username))
                {
                    
                    if (CheckExistingUserName(username))
                    {

                        OrganizationContactModel organizations = new OrganizationContactModel();
                        signupModel.NotificationData = new Dictionary<string, string>();
                        IDMApplicationUser applicationUser = new IDMApplicationUser(_config);
                        IDMUser idmuser = new IDMUser();
                        idmuser.FirstName = signupModel.FirstName;
                        idmuser.MiddleName = signupModel.MiddleName ?? string.Empty;
                        idmuser.LastName = signupModel.LastName;
                        idmuser.Password = signupModel.Password;
                        idmuser.Email = signupModel.EmailId;
                        idmuser.UserName = username;

                        List<string> roles = new List<string>();
                        string selectedLookupRole = string.Empty;

                        if (selectedRole == string.Empty)
                        {
                            selectedLookupRole = UserRoles.Guest;
                        }
                        else
                        {
                            switch (selectedRole)
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

                        /* if (signupModel.IsApplicant)
                         {
                             roles.Add(UserRoles.Applicant);
                         }*/

                        /*assign roles to user*/

                        idmuser.AppList = new List<AppDetail>();
                        idmuser.AppList.Add(new AppDetail()
                        {
                            AppKey = GetConfigValue("AppSettings:AppKey"),
                            AppName = GetConfigValue("AppSettings:AppKey"),
                            Roles = roles
                        }); 

                        // Call IDM and create an account
                        idmuser = applicationUser.ApplicantSignUp(idmuser);

                        if (idmuser.Status != null && idmuser.Status != "Not Found")
                        {
                            if (idmuser.Status.Contains("successfully"))
                            {
                                data.Result.Status = true;
                                // Save entry in contact tables
                                signupModel.IsApplicant = true;

                                /*saving contact */
                                //signupModel.SaveContactInformation(signupModel, username, Constants.AppConstant.WebRegister);
                              int contactId= await  _accountService.ContactIdentifierSave(signupModel, username, Constants.AppConstant.WebRegister);

                                ///* Saving subscription data to DB */
                                ///Ananth: Commented below piece of code
                                /*if (signupModel.IsApplicant)
                                {
                                    SubscriptionModel subscriptionModel = new SubscriptionModel();
                                    subscriptionModel.ContactIdentifierID = signupModel.ContactIdentifierID;
                                    subscriptionModel.IsListingAdded = signupModel.IsListingAdded;
                                    subscriptionModel.IsOpenForApplication = signupModel.IsOpenForApplication;
                                    subscriptionModel.IsWaitlistOpen = signupModel.IsWaitlistOpen;
                                    subscriptionModel.UserName = signupModel.IDMUserName;
                                    subscriptionModel.IsOpenForAffordableApplication = signupModel.IsOpenForAffordableApplication;
                                    subscriptionModel.IsClosedForAffordableApplication = signupModel.IsClosedForAffordableApplication;
                                    int contactIdentifierId = HousingRegistryClient.SaveSubscription(subscriptionModel);
                                }*/
                                data.Result.Status = true;

                                // End - Save entry in contact tables
                                ///Ananth: Commented below piece of code
                                /*string path = System.AppDomain.CurrentDomain.BaseDirectory + @"\Models\ApplicantSignUp.db";
                                using (var liteDbFile = new LiteDatabase(@"Filename=" + path + ";connection=shared"))
                                {
                                    var col = liteDbFile.GetCollection<ApplicantSignupModel>("ApplicantSignUp");

                                    col.Insert(signupModel);

                                    col.EnsureIndex(x => x.IDMUserName);
                                }*/

                                if (idmuser.Email != "")
                                {
                                    /*send email to user for account activation*/
                                    string AccountActivationUrl = _config["AppSettings:ApplicantAccountActivation"] + idmuser.RegistrationActivationCode + "&User=" + idmuser.Email;
                                    Dictionary<string, string> NotificationData = new Dictionary<string, string>();

                                    NotificationData.Add("firstname", idmuser.FirstName);
                                    NotificationData.Add("lastname", idmuser.LastName);
                                    NotificationData.Add("username", idmuser.UserName);
                                    NotificationData.Add("AccountActivationLink", "<a href='" + AccountActivationUrl.ToString() + "' target='_blank' >" + "Please click here to complete the registration process and activate your account." + "</a>");
                                    //convert the config value into hours.
                                    int t = int.Parse(_config["AppSettings:ACTIVATION-LINK-EXPIRATION"].ToString());
                                    string time = (t / 60).ToString();
                                    NotificationData.Add("time", time);
                                   var notificationInfo=_sendNotificationEmail.GetNotificationInfo(EmailTemplate.ET_EmailToPersonSigningUp, NotificationData, idmuser.Email);
                                    var notificationCrdential = _sendNotificationEmail.GetNotificationCrdential("AAHR");
                                  await _sendNotificationEmail.SendMail(notificationInfo, notificationCrdential, EmailAction.EA_Signup);
                                }

                                ///* Saving subscription data to DB */
                                //if (signupModel.IsApplicant)
                                //{
                                //    SubscriptionModel subscriptionModel = new SubscriptionModel();
                                //    subscriptionModel.ContactIdentifierID = signupModel.ContactIdentifierID;
                                //    subscriptionModel.IsListingAdded = signupModel.IsListingAdded;
                                //    subscriptionModel.IsOpenForApplication = signupModel.IsOpenForApplication;
                                //    subscriptionModel.IsWaitlistOpen = signupModel.IsWaitlistOpen;
                                //    subscriptionModel.UserName = signupModel.IDMUserName;
                                //    int contactIdentifierId = HousingRegistryClient.SaveSubscription(subscriptionModel);
                                //}
                                //data.Result.Status = true;
                                //data.Result.Data = new { ErrorMsg = idmuser.Status };

                            }
                            else
                            {
                                data.Result.Status = false;
                                data.Result.Data = new { ErrorMsg = idmuser.Status, CurrentEmailID = idmuser.Email };
                            }
                        }
                        else if (idmuser.Status == "Not Found")
                        {
                            data.Result.Status = false;
                            data.Result.Data = new { ErrorMsg = "User account cannot be created at this time. Please try again later." };
                        }
                        else
                        {
                            data.Result.Status = false;
                            data.Result.Data = new { ErrorMsg = idmuser.Status != null ? idmuser.Status : "User account cannot be created at this time. Please try again later." };
                        }

                    }
                    else
                    {
                        data.Result.Status = false;
                        data.Result.Data = new { ErrorMsg = "User account already exists.", CurrentEmailID = signupModel.EmailId };
                    }

                }

            }
            catch (Exception ex)
            {
                data.Result.Status = false;
                data.Result.Data = new { ErrorMsg = "Error occured when creating user account. Please try again later." };
            }

            return Json(data);
        }

        [HttpGet("Activate")]
        public IActionResult ActivateAAHRUser(string activationcode, string User)
        {
            IDMAuthenticate authenticate = new IDMAuthenticate(_config);
            IDMUser idmuser = authenticate.ActivateAAHRUser(activationcode);
            // Determine status/message
            string status = "SystemError";
            string message = "Activation failed";
            if (idmuser.Status != null)
            {
                message = idmuser.Status.Substring(8); // remove code
                if (idmuser.Status.Contains("IDM110")) status = "NotActivated";
                else if (idmuser.Status.Contains("IDM119")) status = "Expired";
                else if (idmuser.Status.Contains("IDM111")) status = "AlreadyActivated";
                else status = "Success";
            }

            // Pass to view via ViewData or ViewBag
            ViewData["Status"] = status;
            ViewData["Message"] = message;
          
            return View("ActivationResult"); // new dedicated view
        }


        #endregion
        //[HttpPost]

        //public IActionResult UpdateAccount()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // your update logic
        //    return Json(new { success = true, message = "Account updated!" });
        //}




        [HttpPost]
        public ActionResult GetACHPDetails(string achpNumber)
        {
            string apiUrl = _config["AppSettings:AAHRLookupAPI"] ?? string.Empty;
            JsonResult response = new JsonResult(string.Empty);
            PropertyAdvancedSearchResultModel searchResult = new PropertyAdvancedSearchResultModel();
            PropertyAdvancedSearchModel propertyAdvancedSearchModel = new PropertyAdvancedSearchModel();
            propertyAdvancedSearchModel.AcHPFileNumber = achpNumber;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                string inputJson = "[[{\"AcHPFileNumber\":\"" + achpNumber + "\"}]]";
                //inputJson = string.Format(inputJson, achpNumber);

                var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

                string requestUrl = "http://43svc/AAHPDev.Api/api/Property/PropertyAdvancedSearchResult";

                //BaseResponse baseResponse = new ServiceClient.ServiceClient(_config).CreateRequest<BaseResponse>(propertyAdvancedSearchModel, requestUrl, ActionType.POST);

                HttpResponseMessage httpResponse = client.PostAsJsonAsync("api/Property/PropertyAdvancedSearchResult", propertyAdvancedSearchModel).Result;

                string responseCode;
                string responseString;
                string achp = string.Empty;

                if (httpResponse.IsSuccessStatusCode)
                {
                    string stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
                    var jsonResponse = JsonConvert.DeserializeObject(stringResponse);

                    JObject obj = JObject.Parse(jsonResponse.ToString());
                    responseCode = obj["ResponseCode"].ToString();
                    responseString = obj["Response"].ToString();
                    var responseArr = JsonArray.Parse(responseString);
                    string json = string.Empty;

                    if (responseArr.AsArray().Count > 0)
                    {
                        searchResult = JsonConvert.DeserializeObject<PropertyAdvancedSearchResultModel>(responseArr[0].ToString());
                        string streetName = searchResult.SiteAddress;
                        achp = searchResult.AcHPFileSiteNumber;
                        json = "{\"ResponseCode\":\"" + responseCode + "\", \"StreetName\":\"" + streetName + "\", \"AchpNumber\":\"" + achp + "\" }";
                    }
                    else
                    {
                        json = "{\"ResponseCode\":\"" + responseCode + "\", \"StreetName\":\"\", \"AchpNumber\":\"" + achp + "\", \"Response\":\"" + responseString +"\" }";
                    }
                    response = Json(json);
                }
            }
            
            //http://43svc/AAHPDev.Api/api/Property/PropertyAdvancedSearchResult

            return response;
        }

        private string GetConfigValue(string key)
        {
            return _config[key] ?? string.Empty;
        }

        public bool CheckExistingUserName(string username)
        {
            JsonData<JsonStatus> data = new JsonData<JsonStatus>(new JsonStatus());
            ApplicantUser objUser = new ApplicantUser();

            objUser.UserName = username;
            objUser.Provider = "SQL";

            objUser = new AccountServiceClient(_config, _contextAccessor).ValidateUsername(objUser);

            if (objUser.Status.Contains("IDM115"))
            {
                data.Result.Status = true;
            }
            else
            {
                data.Result.Status = false;
                data.Result.Data = new { status = objUser.Status, registrationActivationCode = objUser.RegistrationActivationCode };
            }

            return data.Result.Status;
        }

        private string GetApplicantDataByKey(string key, List<JToken> lst)
        {
            var query = from x in lst
                        where ((JProperty)x).Name == key
                        select ((JProperty)x).Value.ToString();
            string tokenValue = query.FirstOrDefault();

            tokenValue = (tokenValue==null||tokenValue=="") ? string.Empty : tokenValue;

            return tokenValue;
        }

        public async Task<List<VwAspNetRole>> getUSerRole()
        {
            var roleData = await _accountService.GetUSerRole(null);
            return roleData;
        }

        [HttpGet("GetUserRoleLookupData")]
        public async Task<JsonResult> GeUserRoleLookupData()
        {
            List<userRoleType> UserRole = new List<userRoleType>();
            var data = await getUSerRole();
            foreach (var item in data)
            {
                userRoleType userRoleType = new userRoleType();
                userRoleType.RoleID = item.RoleId;
                userRoleType.RoleName = item.Name;
                UserRole.Add(userRoleType);
            }

           string  json = JsonConvert.SerializeObject(UserRole, Formatting.Indented);
            return new JsonResult(json);

        }

        [HttpGet("GetAllLookupData")]
        public async Task<JsonResult> GetAllLookupData()
        {
            string Baseurl = GetConfigValue("AAHRApiSettings:ApiURL");
            var response = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/user/lookuplist");

                if (Res.IsSuccessStatusCode)
                {
                    response = await Res.Content.ReadAsStringAsync();
                }
            }

            JObject keyValuePairs = JObject.Parse(JsonConvert.DeserializeObject(response).ToString());

            var result = new
            {
                State = JArray.Parse(keyValuePairs["Response"]["LutStateCDList"].ToString())
                    .Select(state => new {
                        StateId = state["LutStateCd"].ToString(),
                        StateName = state["Description"].ToString()
                    }).ToList(),

                PhoneType = JArray.Parse(keyValuePairs["Response"]["LutPhoneTypeCdList"].ToString())
                    .Select(ph => new {
                        PhoneTypeValue = ph["LutPhoneTypeCd"].ToString(),
                        PhoneTypeText = ph["PhoneType"].ToString()
                    }).ToList(),

                Direction = JArray.Parse(keyValuePairs["Response"]["LutPreDirCdList"].ToString())
                    .Select(dir => new {
                        DirectionValue = dir["LutPreDirCD"].ToString(),
                        DirectionText = dir["LutPreDirCD"].ToString()
                    }).ToList(),

                StreetType = JArray.Parse(keyValuePairs["Response"]["LutStreetTypeList"].ToString())
                    .Select(st => new {
                        StreetTypeValue = st["LutStreetTypeCd"].ToString(),
                        StreetTypeText = st["LutStreetTypeCd"].ToString()
                    }).ToList(),

                //UserRole = (await getUSerRole())
                //    .Select(role => new {
                //        RoleID = role.RoleId,
                //        RoleName = role.Name
                //    }).ToList()
            };

            return new JsonResult(result);
        }

        [HttpGet("GetRoleError")]
        public IActionResult RoleError()
        {
            return View("RoleError");
        }

        private async Task<Models.IDM.SignupModel> GetData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://43svc/AAHRDev.Api/");
            Models.IDM.SignupModel result = await client.GetFromJsonAsync<Models.IDM.SignupModel>("api/user/lookuplist");
            return result;
        }
    }
    internal class userRoleType
    {
        public int RoleID { get; internal set; }
        public string RoleName { get; internal set; }
    }

    internal class StreetType
    {
        public string StreetTypeText { get; internal set; }
        public string StreetTypeValue { get; internal set; }
    }

    internal class State
    {
        public string StateId { get; set; }
        public string StateName { get; set; }
    }

    internal class PhoneType
    {
        public string PhoneTypeText { get; set; }
        public string PhoneTypeValue { get; set; }
    }

    internal class Directions
    {
        public string DirectionText { get; set; }
        public string DirectionValue { get; set; }
    }
}
