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
using static System.Runtime.InteropServices.JavaScript.JSType;
using DeveloperPortal.Models.Resources;

namespace DeveloperPortal.Controllers
{
    
    [Controller]
    public class AccountController : Controller
    {
        private IConfiguration _config;
        // Here we are using Dependency Injection to inject the Configuration object
        public AccountController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Login(string ReturnUrl)
        {
            return Redirect($"{_config["IDMSettings:CentralIDMURL"]}&returnUrl={_config["ThisApplication:ApplicationURL"]}{ReturnUrl}");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(string data)
        {
            //data = "{\"Applicant\":[{\"step\":\"YourInfo\",\"Data\":{\"firstName\":\"first\",\"lastName\":\"last\",\"middleName\":\"\",\"email\":\"a@a.com\",\"companyName\":\"my company\",\"title\":\"ownwer\",\"password\":\"passw0rd\"}},{\"step\":\"ContactInfo\",\"Data\":{\"phoneNumber\":\"(654)984-6513\",\"city\":\"Los Angeles\",\"state\":\"CA\",\"zipCode\":\"65498\",\"phoneType\":\"Mobile\",\"extension\":\"2354\",\"streetNumber\":\"\",\"streetDirection\":\"\",\"streetName\":\"\",\"streetType\":\"\",\"unitNumber\":\"\",\"poBoxNumber\":\"3847\",\"poBox\":\"Yes\"}},{\"step\":\"ProjectList\",\"Data\":\"[\\\"F0200 - 6120 N.Woodman Ave.\\\"]\"}]}";
            //data = "{\"Applicant\":[{\"step\":\"YourInfo\",\"Data\":{\"firstName\":\"first\",\"lastName\":\"last\",\"middleName\":\"\",\"email\":\"a@a.com\",\"companyName\":\"My Company\",\"title\":\"ownwer\",\"password\":\"passw0rd\"}},{\"step\":\"ContactInfo\",\"Data\":{\"phoneNumber\":\"(455)454-5454\",\"city\":\"Los Angeles\",\"state\":\"CA\",\"zipCode\":\"90023\",\"phoneType\":\"Mobile\",\"extension\":\"1253\",\"streetNumber\":\"\",\"streetDirection\":\"\",\"streetName\":\"\",\"streetType\":\"\",\"unitNumber\":\"\",\"poBoxNumber\":\"2347\",\"poBox\":\"Yes\"}},{\"step\":\"ProjectList\",\"Data\":\"[\\\"F0200 - 6120 N.Woodman Ave.\\\"]\"}]}";
            Console.WriteLine("createaccount");
            ApplicantSignupModel signupModel = new ApplicantSignupModel();

            //string yourInfo = json[0];
            //object coll = Request.Form.ToList();

            JObject keyValuePairs = JObject.Parse(JsonConvert.DeserializeObject(data).ToString());
            foreach (JProperty property in keyValuePairs.Properties())
            {
                var applicantJson = property.Value.ToString();
                JArray jArray = JArray.Parse(applicantJson);

                foreach (var item in jArray)
                {
                    string step1 = item["step"].ToString();
                    var stepJson = item["Data"];
                    List<JToken> lst = stepJson.ToList();

                    switch (step1)
                    {
                        case "YourInfo":
                            string first = GetApplicantDataByKey("firstName", lst);
                            string last = GetApplicantDataByKey("lastName", lst);
                            string middle = GetApplicantDataByKey("middleName", lst);
                            string email = GetApplicantDataByKey("email", lst);
                            string companyName = GetApplicantDataByKey("companyName", lst);
                            string title = GetApplicantDataByKey("title", lst);
                            string password = GetApplicantDataByKey("password", lst);

                            signupModel.FirstName = first;
                            signupModel.LastName = last;
                            signupModel.MiddleName = middle;
                            signupModel.Password = password;
                            signupModel.EmailId = email;
                            signupModel.CompanyName = companyName;
                            signupModel.Title = title;
                            break;
                        case "ContactInfo":
                            string phoneNumber = GetApplicantDataByKey("phoneNumber", lst);
                            string city = GetApplicantDataByKey("city", lst);
                            string state = GetApplicantDataByKey("state", lst);
                            string zipCode = GetApplicantDataByKey("zipCode", lst);
                            string phoneType = GetApplicantDataByKey("phoneType", lst);
                            string extension = GetApplicantDataByKey("extension", lst);
                            string streetNumber = GetApplicantDataByKey("streetNumber", lst);
                            string streetDirection = GetApplicantDataByKey("streetDirection", lst);
                            string streetName = GetApplicantDataByKey("streetName", lst);
                            string streetType = GetApplicantDataByKey("streetType", lst);
                            string unitNumber = GetApplicantDataByKey("unitNumber", lst);
                            string poBoxNumber = GetApplicantDataByKey("poBoxNumber", lst);
                            string poBox = GetApplicantDataByKey("poBox", lst);
                            
                            signupModel.PhoneNumber = phoneNumber;
                            signupModel.City = city;
                            signupModel.State = state;
                            signupModel.Zipcode = zipCode;
                            signupModel.PhoneType = phoneType;
                            signupModel.PhoneExtension = extension;
                            
                            int result = -1;
                            int.TryParse(streetNumber, out result);
                            signupModel.StreetNum = result;

                            signupModel.StreetName = streetName;
                            signupModel.StreetDir = streetDirection;
                            signupModel.StreetType = streetType;
                            signupModel.UnitNumber = unitNumber;
                            signupModel.PostBoxNum = poBoxNumber;
                            signupModel.IsPostBox = (poBox == "Yes");
                            break;
                        case "ProjectList":
                            List<string> projList = new List<string>();
                            JArray arr  = JArray.Parse(stepJson.ToString());
                            foreach (var item1 in arr)
                            {
                                string proj =  item1.ToString();
                                projList.Add(proj);
                            }
                            
                            signupModel.Projects = projList;
                            //ModelState.SetModelValue()
                            //
                            //string poBox = GetApplicantDataByKey("poBox", lst);
                            break;
                        default:
                            break;
                    }
                }
            }

            CheckExistingUserName("aSoundararajan@lacity.org");

            return Content("Create Account called..");
        }

        [HttpPost]
        public ActionResult CreateIDMAccount(ApplicantSignupModel signupModel)
        {
            JsonData<JsonStatus> data = new JsonData<JsonStatus>(new JsonStatus());
            string username = "";

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
                    IDMApplicationUser applicationUser = new IDMApplicationUser();
                    IDMUser idmuser = new IDMUser();
                    idmuser.FirstName = signupModel.FirstName;
                    idmuser.MiddleName = signupModel.MiddleName;
                    idmuser.LastName = signupModel.LastName;
                    idmuser.Password = signupModel.Password;
                    idmuser.Email = signupModel.EmailId;
                    idmuser.UserName = username;

                    List<string> roles = new List<string>();

                    if (signupModel.IsApplicant)
                    {
                        roles.Add(UserRoles.Applicant);
                    }

                    /*assign roles to user*/
                    idmuser.AppList = new List<AppDetail>();
                    idmuser.AppList.Add(new AppDetail()
                    {
                        AppKey = GetConfigValue("ThisApplication:AppKey"),
                        AppName = GetConfigValue("ThisApplication:AppKey"),
                        Roles = roles
                    }); ;

                    // Call IDM and create an account
                    idmuser = applicationUser.ApplicantSignUp(idmuser);

                    if (idmuser.Status != null && idmuser.Status != "Not Found")
                    {
                        if (idmuser.Status.Contains("successfully"))
                        {
                            data.Result.Status = true;
                            // auto login current user
                            ApplicantUser objUser = new ApplicantUser();

                            objUser.UserName = username;
                            objUser.Password = signupModel.Password;
                            objUser.Provider = "SQL";

                            objUser = new AccountServiceClient().AuthenticateUser(objUser);

                            if (objUser.IDMUserId > 0)
                            {
                                //var userDetail = objUser.ApplicationDetail.FirstOrDefault(a => a.AppKey.Equals(_config["ThisApplication:Application"]));
                                ApplicationDetail thisapp = objUser.AppList.Find(a => a.AppName.Equals(_config["ThisApplication:Application"]));
                                var authenticateResponse = IDMServiceClient.ValidateToken(thisapp.JWTToken);
                                //// add response to session.                                
                                //FormsAuthentication.SetAuthCookie(objUser.UserName, true);
                                //objUser.
                                var identity = new ClaimsIdentity(new[] {
                                        new Claim(ClaimTypes.Name, authenticateResponse.Username),
                                        new Claim(ClaimTypes.Role,string.Join(",", thisapp.Roles))
                                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                                var principal = new ClaimsPrincipal(identity);

                                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                                //UserSession.SetUserInSession(UserSession.AssignValues(HttpContext, r, thisapp.JWTToken, Constants.Application.Name));
                                UserSession.SetUserInSession(HttpContext, UserSession.AssignValues(HttpContext, authenticateResponse, thisapp.JWTToken, Constants.Application.Name));
                            }

                            // End - auto login

                            // Save entry in contact tables
                            signupModel.IsApplicant = true;

                            /*saving contact */
                            signupModel.SaveContactInformation(signupModel, username, Constants.AppConstant.WebRegister);


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
                                //string AccountActivationUrl = ConfigurationManager.AppSettings["ApplicantAccountActivation"] + idmuser.RegistrationActivationCode + "&User=" + idmuser.Email;
                                signupModel.NotificationData.Add("firstname", idmuser.FirstName);
                                signupModel.NotificationData.Add("lastname", idmuser.LastName);
                                signupModel.NotificationData.Add("username", idmuser.UserName);
                                //signupModel.NotificationData.Add("AccountActivationLink", "<a href='" + AccountActivationUrl.ToString() + "' target='_blank' >" + "Please click here to complete the registration process and activate your account." + "</a>");
                                //convert the config value into hours.
                                //int t = int.Parse(ConfigurationManager.AppSettings["ACTIVATION-LINK-EXPIRATION"].ToString());
                                //string time = (t / 60).ToString();
                                //signupModel.NotificationData.Add("time", time);
                                /*send notification to registerd user*/
                                signupModel.SendNotificationMail(EmailTemplate.ET_EmailToApplicantSigningUp, idmuser.Email, EmailAction.EA_Signup);
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


            return Json(data);
        }

        private string GetConfigValue(string key)
        {
            return _config[key].ToString();
        }

        public bool CheckExistingUserName(string username)
        {
            JsonData<JsonStatus> data = new JsonData<JsonStatus>(new JsonStatus());
            ApplicantUser objUser = new ApplicantUser();

            objUser.UserName = username;
            objUser.Provider = "SQL";

            objUser = new AccountServiceClient().ValidateUsername(objUser);

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

            tokenValue = (tokenValue.IsNullOrEmpty()) ? string.Empty : tokenValue;

            return tokenValue;
        }

        #region Commented Json Parsing code
        /*
         * JObject json = JObject.Parse(data);
            JArray myArray = (JArray)json["param"];

            foreach (var item in myArray)
            {
                string itemString = item.ToObject<string>();
                JObject itemObject = (JObject)JsonConvert.DeserializeObject(itemString);
                var obj1 = (JsonConvert.DeserializeObject(item.ToObject<string>()));
                JObject obj2 = (JObject)obj1;
                foreach (JProperty p in obj2.Properties())
                {

                }
            }
         */
        #endregion
    }
}
