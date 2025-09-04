using DeveloperPortal.Models.Common;
using DeveloperPortal.Models.IDM;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeveloperPortal.ServiceClient
{
    public static class PreferredContactMethods
    {
        public const string None = "None";
        public const string USMail = "US Mail";
        public const string Phone = "Phone";
    }
    public class UserServiceClient : ServiceClient
    {
        private readonly IConfiguration _config;
  

        public UserServiceClient(IConfiguration config) : base(config)
        {
            _config = config;
           
        }

        private string baseUrl;
        //private  string propertyBaseUrl = _config["AreaMgmtAPIURL:URL"].ToString();
        public static async Task<ApplicantSignupModel> GetLookupLists_P2(IConfiguration config)
        {
            string propertyBaseUrl = config["AAHRApiSettings:AAHRApiURL"];

            //propertyBaseUrl = string.Format("{0}", new WebApiConstant(config).GetConfigData("AAHRApiSettings:AAHRApiURL"));
            string requestUrl = propertyBaseUrl + WebApiConstant.GetLookupLists;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var signupModel = JsonConvert.DeserializeObject<BaseResponse1<ApplicantSignupModel>>(json);
                    return signupModel.Response;

                }
                else
                {
                    // Optionally handle error/log
                    return new ApplicantSignupModel(config); // return empty model if failed
                }
            }
            //BaseResponse baseResponse = CreateRequest<BaseResponse>(new { }, requestUrl, ActionType.GET);
            //  ApplicantSignupModel signupModel = new ApplicantSignupModel(_config);
            //GetLookupLists_P2();

            //if (HttpStatusCode.OK == baseResponse.ResponseCode)
            //    signupModel = JsonConvert.DeserializeObject<ApplicantSignupModel>(Convert.ToString(baseResponse.Response));
           
        }
        public static async Task<ApplicantSignupModel> GetMyAccountDetail_P2(string userName,IConfiguration config)
        {
            string propertyBaseUrl = config["AreaMgmtAPIURL:PropertyApiURL"].TrimEnd('/') + "/";
            ApplicantSignupModel signupModel = new ApplicantSignupModel(config);
            //userName = "yopmail.com";
            ContactRenderModel model = new ContactRenderModel();

            /*get client data from PCMS*/
            using (HttpClient client = new HttpClient())
            {
                /*Property API*/
                client.BaseAddress = new Uri(propertyBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("Contact/GetContactByUserName?userName=" + Uri.EscapeDataString(userName).Replace("%20", "+")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var contactResponse = JsonConvert.DeserializeObject<BaseResponse>(result);
                    model = JsonConvert.DeserializeObject<ContactRenderModel>(Convert.ToString(contactResponse.Response));
                }

                response.Dispose();
                response.Headers.ConnectionClose = true;
            }

            try
            {
                signupModel.ContactID = model.ContactId;
                signupModel.FirstName = model.FirstName;
                signupModel.MiddleName = model.MiddleName;
                signupModel.LastName = model.LastName;
                signupModel.CurrentFirstName = model.FirstName;
                signupModel.CurrentLastName = model.LastName;
                signupModel.EmailId = model.Email;
                signupModel.AdditionalEmail = model.AdditionalEmail;
                signupModel.Company = model.Company;
                signupModel.Title = model.Title;
                signupModel.HousingAdvocateAgencyId = model.OrganizationId;
                signupModel.OrganizationID = model.OrganizationId;
                signupModel.PropContactId = model.PropContactId;

                if (model.PreferredContactMethod == ContactMethods.USMail.ToString())
                {
                    model.PreferredContactMethod = PreferredContactMethods.USMail;
                }
                else if (model.PreferredContactMethod == null || model.PreferredContactMethod == "")
                {
                    model.PreferredContactMethod = PreferredContactMethods.None;
                }

                //signupModel.AlternateContactMethodcd = _dbContext.LutAltContactTypes.FirstOrDefault(x => x.PreferContactType == model.PreferredContactMethod).LutAltContactTypeID;
                signupModel.ContactAddressID = model.ContactAddressId;
                signupModel.HouseNum = !string.IsNullOrEmpty(model.HouseNum) ? Convert.ToInt32(model.HouseNum) : (int?)null;
                signupModel.HouseFracNum = model.HouseFracNum;
                signupModel.LutPreDirCd = model.IsPoBox ? null : model.PreDirection;
                signupModel.LutStreetTypeCD = model.StreetTypeCd;
                signupModel.PostDirCd = model.PostDirection;
                signupModel.Unit = model.Unit;
                signupModel.City = model.City;
                signupModel.LutStateCD = model.State;
                signupModel.Zipcode = !string.IsNullOrEmpty(model.Zip) ? model.Zip.ToString().PadLeft(5, '0') : "";
                signupModel.BirthDay = model.BirthDay;
                signupModel.BirthMonth = model.BirthMonth;
                signupModel.BirthYear = model.BirthYear;
                signupModel.IsPostBox = model.IsPoBox;
                signupModel.IsLocked = model.IsLocked ?? false;
                signupModel.EmployeeID = model.EmployeeID;
                signupModel.Department = model.Department;
                signupModel.Designation = model.Classification;

                if (signupModel.IsPostBox)
                {
                    signupModel.PostBoxNum = model.StreetName;
                }
                else
                {
                    signupModel.StreetName = model.StreetName;
                }

                if (!string.IsNullOrEmpty(model.PhoneType))
                {
                    signupModel.PhoneNumber = model.PhoneHome;
                    signupModel.LutPhoneTypeCd = "H";
                }

                if (!string.IsNullOrEmpty(model.PhoneHome))
                {
                    signupModel.PhoneNumber = model.PhoneHome;
                    signupModel.LutPhoneTypeCd = "H";
                }
                else if (!string.IsNullOrEmpty(model.PhoneCell))
                {
                    signupModel.PhoneNumber = model.PhoneCell;
                    signupModel.LutPhoneTypeCd = "M";
                }
                else if (!string.IsNullOrEmpty(model.PhoneBusiness))
                {
                    signupModel.PhoneNumber = model.PhoneBusiness;
                    signupModel.LutPhoneTypeCd = "W";
                }



                //signupModel.Extn = model.PhoneExtension;

                //signupModel.AltPhoneNumber = model.AltPhoneNo;
                //signupModel.LutAltPhoneTypeCd = model.AltPhoneType;
                //signupModel.AltExtn = model.AltPhoneExtn;



                ApplicantSignupModel signupModel1 = new ApplicantSignupModel(config);

                /*Initinalize necessary lookup values*/

                signupModel1 =  await UserServiceClient.GetLookupLists_P2(config);

                //signupModel.LutAltPhoneTypeCd = signupModel1.LutAltPhoneTypeCd;
                signupModel.LutPhoneTypeCd = signupModel1.LutPhoneTypeCd;
                signupModel.LutPhoneTypeCdList = signupModel1.LutPhoneTypeCdList;
                //signupModel.LutPreDirCd = signupModel1.LutPreDirCd;
                //signupModel.AlternateContact_LutPreDirCd = signupModel1.LutPreDirCd;
                signupModel.LutPreDirCdList = signupModel1.LutPreDirCdList;
                //signupModel.LutStateCD = signupModel1.LutStateCD;
                signupModel.LutStateCDList = signupModel1.LutStateCDList;
                //signupModel.LutStreetTypeCD = signupModel1.LutStreetTypeCD;
                //signupModel.AlternateContact_LutStreetTypeCD = signupModel1.LutStreetTypeCD;
                signupModel.LutStreetTypeList = signupModel1.LutStreetTypeList;
                //signupModel.AltContactTypeList = signupModel1.AltContactTypeList;
                //signupModel.DepartmentList = signupModel1.DepartmentList;

                if (signupModel.IDMUserName == null)
                {
                    signupModel.IDMUserName = userName;
                }

                //Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");


                //if (signupModel.IDMUserName != null && regex.IsMatch(signupModel.IDMUserName))
                //{
                //    signupModel.no_email = false;
                //}
                //else
                //{
                //    if (signupModel.EmailId != null && regex.IsMatch(signupModel.EmailId))
                //    {
                //        signupModel.no_email = false;
                //    }
                //    else
                //    {
                //        signupModel.no_email = true;
                //    }
                //}

            }
            catch (Exception ex)
            {
            }
            
            return signupModel;
            
            }


    }
}
