using ComCon.DataAccess.Entity;
using ComCon.DataAccess.ViewModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeveloperPortal.Models.IDM
{
    public class ApplicantSignupModel
    {
        private IConfiguration _config;

        #region YourInformation
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool SignupTermCondition { get; set; }
        #endregion

        #region ContactInformation
        public string PhoneNumber { get; set; }
        public string PhoneExtension { get; set; }
        public string PhoneType { get; set; }
        public bool IsPostBox { get; set; }
        public string PostBoxNum { get; set; }
        public int? StreetNum { get; set; }
        public string StreetDir { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string StreetAddress { get; set; }
        public string UnitNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        #endregion

        public string IDMUserName { get; set; }

        public Dictionary<string, string> NotificationData = new Dictionary<string, string>();

        public List<NotificationInfoModel> notificationInfoList { get; set; }

        public Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public bool IsApplicant { get; set; }
        #region ProjectRegistration
        public List<string> Projects { get; set; }
        public string LutPhoneTypeCd { get; set; }
        public int ContactIdentifierID { get; private set; }
        #endregion

        #region Send Notification Mail
        /// <summary>
        /// Send Notification Mail
        /// </summary>
        /// <param name="TemplateId"></param>
        /// <param name="MailId"></param>
        public void SendNotificationMail(string templateName, string MailId, string emailAction, string MailCC = null, string MailBCC = null)
        {
            GetNotificatioInfo(templateName, this.NotificationData, MailId, MailCC, MailBCC);

            Task.Factory.StartNew(() =>
            {
                SendNotification sendNotification = new SendNotification();
                sendNotification.SendMail(this.notificationInfoList, new NotificationCredential(), emailAction);
            });
        }

        #endregion

        #region Get Notification Info
        /// <summary>
        /// Function to get Notification Details
        /// </summary>
        public void GetNotificatioInfo(string TemplateName, Dictionary<string, string> notificationData, string MailId, string MailCC = null, string MailBCC = null)
        {
            notificationInfoList = new List<NotificationInfoModel>();
            dictionary = notificationData;

            using (ComConEntities db = new ComConEntities())
            {
                var NotificationDetails = db.NotificationTemplates.Where(s => s.Name == TemplateName).ToList();

                foreach (var notificationDetail in NotificationDetails)
                {
                    NotificationInfoModel notificationModel = new NotificationInfoModel();
                    notificationModel.MailId = MailId;
                    notificationModel.MailBCC = MailBCC;
                    notificationModel.MailCC = MailCC;
                    notificationModel.Subject = PrepareSubject(notificationDetail.EmailSubject);
                    notificationModel.Body = PrepareBody(notificationDetail.EmailBody);
                    notificationModel.Body = PrepareFooterAndCommonText(notificationModel.Body);
                    notificationInfoList.Add(notificationModel);
                }
            }
        }

        #region Prepare Dynamic Subject
        /// <summary>
        ///Function to Prepare Dynamic Subject For Notification
        /// </summary>
        public string PrepareSubject(string emailSubject)
        {
            if (dictionary != null)
            {
                foreach (var item in dictionary)
                {
                    emailSubject = emailSubject.Replace("[" + item.Key + "]", item.Value);
                }
            }

            return emailSubject;
        }
        #endregion

        #region Prepare Dynamic Body
        /// <summary>
        ///Function to Prepare Dynamic Body For Notification
        /// </summary>
        public string PrepareBody(string emailBody)
        {
            if (dictionary != null)
            {
                foreach (var item in dictionary)
                {
                    emailBody = emailBody.Replace("[" + item.Key + "]", item.Value);
                }
            }

            return emailBody;
        }
        #endregion

        #region Prepare Standard Footer

        /// <summary>
        /// Prepare standard footer
        /// </summary>
        /// <returns></returns>
        public string PrepareFooterAndCommonText(string body)
        {
            using (ComConEntities db = new ComConEntities())
            {
                //  string emailFooter = db.NotificationTemplates.Where(m => m.Name == "Common Email Footer").SingleOrDefault().EmailBody;

                //   body = body.Replace("[Footer]", emailFooter);

                string emailFooter = string.Empty;

                if (body.Contains("[Program Footer]"))
                {
                    emailFooter = db.NotificationTemplates.Where(m => m.Name == EmailTemplateConstant.ProgramFooterTemplate).SingleOrDefault().EmailBody;
                    body = body.Replace("[Program Footer]", emailFooter);

                }
                if (body.Contains("[System Footer]"))
                {
                    emailFooter = db.NotificationTemplates.Where(m => m.Name == EmailTemplateConstant.SystemFooterTemplate).SingleOrDefault().EmailBody;
                    body = body.Replace("[System Footer]", emailFooter);

                }

                foreach (var item in EmailTemplateConstant.EmailConstants)
                {
                    body = body.Replace("[" + item.Key + "]", item.Value);
                }

                return body;
            }

        }
        #endregion

        #endregion

        public int SaveContactInformation(ApplicantSignupModel signupModel, string userName, string source = "")
        {

            using (HttpClient client = new HttpClient())
            {
                Dictionary<string, string> contactAttributeList = new Dictionary<string, string>();
                Dictionary<string, string> contactAddressAttributeList = new Dictionary<string, string>();

                // ContactRenderModel (contact) is for PCMS. signupModel will sent to save information to ContactIdentifire
                ContactRenderModel contact = new ContactRenderModel();

                /*Contact details*/
                //contact.ContactId = signupModel.ContactID;
                contact.UserName = userName;
                contact.IDMUserName = (source == AppConstant.WebRegister) ? userName : null;
                contact.FirstName = signupModel.FirstName;
                contact.MiddleName = signupModel.MiddleName;
                contact.LastName = signupModel.LastName;
                contact.Email = signupModel.EmailId;
                contact.Title = (signupModel.Title != null ? signupModel.Title.Trim() : "");
                contact.Company = (signupModel.CompanyName != null ? signupModel.CompanyName : "");//Company
                //contact.OrganizationId = signupModel.OrganizationID;
                //contact.AdditionalEmail = signupModel.AdditionalEmail;
                contact.Source = source;
                //commented for 3PP - properties for which data is not collected
                /*contact.BirthDay = signupModel.BirthDay;
                contact.BirthMonth = signupModel.BirthMonth;
                contact.BirthYear = signupModel.BirthYear;

                //Self declaration question
                contact.IsVeteran = signupModel.IsVeteran;
                contact.IsCurrentlyHomeless = signupModel.IsCurrentlyHomeless;
                contact.IsWorriedAboutBecomingHomeless = signupModel.IsWorriedAboutBecomingHomeless;
                contact.IsInUnsafeHousing = signupModel.IsInUnsafeHousing;
                contact.NoneOfHouseholdApply = signupModel.NoneOfHouseholdApply;
                contact.SocialSecurityNumber = signupModel.SocialSecurityNumber;
                contact.DateOfBirth = signupModel.DateOfBirth;
                contact.HMISNumber = signupModel.HMISNumber;
                //Alternate contact questions
                contact.AlternateContactQuestion = signupModel.AlternateContactQuestion;
                contact.AlternateContact_FirstName = signupModel.AlternateContact_FirstName;
                contact.AlternateContact_MiddleName = signupModel.AlternateContact_MiddleName;
                contact.AlternateContact_LastName = signupModel.AlternateContact_LastName;
                contact.AlternateContact_Method_Email = signupModel.AlternateContact_Method_Email;
                contact.AlternateContact_Method_MailingAddress = signupModel.AlternateContact_Method_MailingAddress;
                contact.AlternateContact_Method_Phone = signupModel.AlternateContact_Method_Phone;
                contact.AlternateContact_Email = signupModel.AlternateContact_Email;
                contact.AlternateContact_PhoneType = signupModel.AlternateContact_PhoneType;
                contact.AlternateContact_PhoneNumber = signupModel.AlternateContact_PhoneNumber;
                contact.AlternateContact_PhoneNotification = signupModel.AlternateContact_PhoneNotification;
                contact.AlternateContact_StreetAddress = signupModel.AlternateContact_StreetAddress;
                contact.AlternateContact_HouseNum = signupModel.AlternateContact_HouseNum;
                contact.AlternateContact_HouseFracNum = signupModel.AlternateContact_HouseFracNum;
                contact.AlternateContact_LutPreDirCd = signupModel.AlternateContact_LutPreDirCd;
                contact.AlternateContact_StreetName = signupModel.AlternateContact_StreetName;
                contact.AlternateContact_LutStreetTypeCD = signupModel.AlternateContact_LutStreetTypeCD;
                contact.AlternateContact_ApartmentUnit = signupModel.AlternateContact_ApartmentUnit;
                contact.AlternateContact_State = signupModel.AlternateContact_State;
                contact.AlternateContact_Zipcode = signupModel.AlternateContact_Zipcode;
                contact.AlternateContact_CityName = signupModel.AlternateContact_CityName;
                contact.AlternateContact_Unit = signupModel.AlternateContact_Unit;*/


                //Original Phone Type
                switch (signupModel.LutPhoneTypeCd)
                {
                    case "H":
                        contact.PhoneHome = signupModel.PhoneNumber;
                        break;
                    case "M":
                        contact.PhoneCell = signupModel.PhoneNumber;
                        break;
                    case "W":
                        contact.PhoneBusiness = signupModel.PhoneNumber;
                        break;
                    default:
                        break;
                }

                contact.PhoneExtension = signupModel.PhoneExtension; //Extn

                /*POBox attribute to save in ContactAddress */
                if (signupModel.IsPostBox)
                {
                    contactAddressAttributeList.Add("IsPOBox", "true");
                    contact.ContactAddressAttribute = JsonConvert.SerializeObject(contactAddressAttributeList);
                }

                /*Contact Address details*/
                //contact.ContactAddressId = signupModel.ContactAddressID;
                //if (!(string.IsNullOrEmpty(signupModel.AddressQuestion)) && signupModel.AddressQuestion.ToString() == "no")
                /*{
                    signupModel.StreetNum = null;
                    signupModel.HouseFracNum = "";
                    signupModel.LutPreDirCd = "";
                    signupModel.StreetName = "";
                    signupModel.LutStreetTypeCD = "";
                    signupModel.PostDirCd = "";
                    signupModel.City = "";
                    signupModel.LutStateCD = "";
                    signupModel.Zip = "";
                    signupModel.Unit = "";
                }*/
                contact.HouseNum = Convert.ToString(signupModel.StreetNum); //HouseNum
                //contact.HouseFracNum = signupModel.HouseFracNum;
                contact.PreDirection = signupModel.StreetDir;// LutPreDirCd;
                contact.StreetName = signupModel.IsPostBox ? signupModel.PostBoxNum : signupModel.StreetName;
                contact.StreetTypeCd = signupModel.StreetType;// LutStreetTypeCD;
                contact.PostDirection = signupModel.StreetDir;// PostDirCd;
                contact.City = signupModel.City;
                contact.State = signupModel.State;// LutStateCD;
                contact.Zip = signupModel.Zipcode; //zip
                contact.Unit = signupModel.UnitNumber;//Unit
                //contact.IsMarkedForMailing = signupModel.AlternateContactMethodcd == (int)ContactMethods.USMail ? true : false;
                //contact.PropContactId = signupModel.PropContactId;

                //contact.Type = ContactTypes.Applicant; //TODO: find the type

                //Commented below for 3PP
                /*if (signupModel.AddressQuestion == "yes")
                {
                    contact.IsContactAddress = true;
                }
                else
                {
                    contact.IsContactAddress = false;
                }


                // Attributes JSON. Atrribute is used for both Contact and ContactIdentifire

                if (signupModel.PhoneNotificationOptions != null)
                {
                    contactAttributeList.Add("PhoneNotificationOptions", signupModel.PhoneNotificationOptions.ToString());
                }
                if (signupModel.AdditionalPhoneNotificationOptions != null)
                {
                    contactAttributeList.Add("AdditionalPhoneNotificationOptions", signupModel.AdditionalPhoneNotificationOptions.ToString());
                }
                if (signupModel.AlternateContact_PhoneNotification != null)
                {
                    contactAttributeList.Add("AlternateContact_PhoneNotification", signupModel.AlternateContact_PhoneNotification.ToString());
                }
                if (signupModel.PhoneNumberQuestion != null)
                {
                    contactAttributeList.Add("PhoneNumberQuestion", signupModel.PhoneNumberQuestion.ToString());
                }
                if (signupModel.AdditionalPhoneNumberQuestion != null)
                {
                    contactAttributeList.Add("AdditionalPhoneNumberQuestion", signupModel.AdditionalPhoneNumberQuestion.ToString());
                }
                if (signupModel.AddressQuestion != null)
                {
                    contactAttributeList.Add("AddressQuestion", signupModel.AddressQuestion.ToString());
                }
                if (signupModel.AlternateContactQuestion != null)
                {
                    contactAttributeList.Add("AlternateContactQuestion", signupModel.AlternateContactQuestion.ToString());
                }
                if (signupModel.AdditionalEmailQuestion != null)
                {
                    contactAttributeList.Add("AdditionalEmailQuestion", signupModel.AdditionalEmailQuestion.ToString());
                }
                if (signupModel.LutPhoneTypeCd != null)
                {
                    contactAttributeList.Add("LutPhoneTypeCd", signupModel.LutPhoneTypeCd.ToString());
                }
                if (signupModel.LutAddPhoneTypeCd != null)
                {
                    contactAttributeList.Add("LutAddPhoneTypeCd", signupModel.LutAddPhoneTypeCd.ToString());
                }
                if (signupModel.AlternateContact_PhoneType != null)
                {
                    contactAttributeList.Add("AlternateContact_PhoneType", signupModel.AlternateContact_PhoneType.ToString());
                }
                if (signupModel.AdditionalPhoneNumber != null)
                {
                    contactAttributeList.Add("AdditionalPhoneNumber", signupModel.AdditionalPhoneNumber.ToString());
                }

                contactAttributeList.Add("AlternateContact_Method_Email", signupModel.AlternateContact_Method_Email.ToString());
                contactAttributeList.Add("AlternateContact_Method_MailingAddress", signupModel.AlternateContact_Method_MailingAddress.ToString());
                contactAttributeList.Add("AlternateContact_Method_Phone", signupModel.AlternateContact_Method_Phone.ToString());
                /*For Applicant user depends on selected contact method allowing to add or skip contact address*/
                //if (contact.PreferredContactMethod != PreferredContactMethods.USMail)
                //{
                //    contact.IsContactAddress = true;
                //}

                /*if (!string.IsNullOrEmpty(signupModel.NameChangeReason))
                {
                    contactAttributeList.Add("NameChangeReason", signupModel.NameChangeReason);
                }

                /*Alternte phone number to save in Contact
                if (!string.IsNullOrEmpty(signupModel.AlternateContact_PhoneType) && signupModel.AlternateContact_PhoneType != "- Select -")
                {
                    contactAttributeList.Add("PhoneType", signupModel.AlternateContact_PhoneType);
                    contactAttributeList.Add("PhoneNo", signupModel.AlternateContact_PhoneNumber);
                    contactAttributeList.Add("PhoneExtn", signupModel.AltExtn);
                    contact.ContactAttribute = JsonConvert.SerializeObject(contactAttributeList);
                }
                else
                {
                    if (contactAttributeList != null && contactAttributeList.Count() > 0)
                    {
                        contact.ContactAttribute = JsonConvert.SerializeObject(contactAttributeList);
                    }
                }

                contact.IsRemovePropContactAssnType = false;*/
                int contactID = 0;
                /*Property API*/
                client.BaseAddress = new Uri(_config["AAHRApiSettings:PropertyApiURL"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //if (signupModel.IsClient != true)
                {
                    //Check if user already exist in PCMS
                    HttpResponseMessage httpResponseMessage = client.GetAsync(string.Format("Contact/GetContactByUserName?userName={0}", contact.IDMUserName)).Result;
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        var contactResponse = JsonConvert.DeserializeObject<Common.BaseResponse>(result);
                        ContactRenderModel contactRenderModel = JsonConvert.DeserializeObject<ContactRenderModel>(contactResponse.Response.ToString());
                        contactID = Convert.ToInt32(contactRenderModel.ContactId);

                        if (contact.ContactAddressId == 0 && contactRenderModel.ContactAddressId != 0)
                        {
                            contact.ContactAddressId = contactRenderModel.ContactAddressId;
                        }
                    }

                    contact.ContactId = contactID;

                }
                /*else
                {
                   // contact.ContactId = signupModel.ContactID;
                }*/

                //save contact information to PCMS
                HttpResponseMessage response = client.PostAsJsonAsync("ContactMgmt/Save", contact).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var contactResponse = JsonConvert.DeserializeObject<Common.BaseResponse>(result);
                    contactID = Convert.ToInt32(contactResponse.Response);
                }

                response.Dispose();
                response.Headers.ConnectionClose = true;

                /*save data to ContactIdentifier*/
                var Attributes = contactAttributeList.Union(contactAddressAttributeList).ToDictionary(k => k.Key, v => v.Value);

                signupModel.ContactIdentifierID = SaveContactToContactIdentifier(signupModel, contactID, contact.Type, userName, JsonConvert.SerializeObject(Attributes), source);

                return contactID;
            }

        }

        /// <summary>
        /// save contact to contactIdentifier
        /// </summary>
        /// <param name="model"></param>
        /// <param name="ContactId"></param>
        /// <param name="contactType"></param>
        /// <param name="userName"></param>
        /// <param name="contactAttributes"></param>
        /// <param name="contactAddressAttributes"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public int SaveContactToContactIdentifier(ApplicantSignupModel model, int ContactId, string contactType, string userName, string Attributes, string source)
        {
            /*save contact details to ContactIdentifier*/
            return
            new ComCon.PropertySnapshot.ContactIdentifiersService().SaveRegisterOrClientContact(new ComCon.PropertySnapshot.Models.ContactIdentifierModel
            {
                ContactID = ContactId,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.EmailId,
                //AdditionalEmail = model.AdditionalEmail,
                AdditionalEmail = string.Empty,
                HouseNum = Convert.ToString(model.StreetNum),//Convert.ToString(model.HouseNum),
                HouseFracNum = string.Empty, //model.HouseFracNum,
                PreDirCd = model.IsPostBox ? null : model.StreetDir,//model.LutPreDirCd,
                StreetName = model.IsPostBox ? model.PostBoxNum : model.StreetName,
                PostDirCd = string.Empty, //model.PostDirCd,
                StreetTypeCd = model.StreetType, //model.LutStreetTypeCD,
                City = model.City,
                State = model.State, //model.LutStateCD,
                Zip = model.Zipcode, //model.Zip,
                BusinessPhoneNumber = model.PhoneNumber,
                HomePhoneNumber = model.PhoneNumber,
                MobilePhoneNumber = model.PhoneNumber,
                Unit = model.UnitNumber, //model.Unit,
                ContactTypeName = contactType,
                UserName = userName,
                ContractorType = "",
                IsEmployee = false,//assigning default false //model.IsCityEmployee ? true : false,
                IDMUserName = model.IDMUserName,
                BirthDay = null, //model.BirthDay,
                BirthMonth = null, //model.BirthMonth,
                BirthYear = null, //model.BirthYear,
                PhoneExtension = model.PhoneExtension, //model.Extn,
                Title = model.Title,
                IsMarkedForMailing = false, //default false //model.AlternateContactMethodcd == (int)ContactMethods.USMail ? true : false,
                Company = model.CompanyName, //model.Company,
                ContactAttribute = Attributes,
                Source = source,
                OrganizationId = 0, //default 0 model.OrganizationID,
                IsAssnContactContactAdd = false, //default false model.IsClient ? true : false,
                LutPhoneTypeCd = model.LutPhoneTypeCd,
                PreferredContactMethod = string.Empty, //model.AlternateContactMethodcd == (int)ContactMethods.None
                                                 /*? null
                                                 : (model.AlternateContactMethodcd == (int)ContactMethods.USMail
                                                    ? PreferredContactMethods.USMail
                                                    : PreferredContactMethods.Phone),*/
                IsRemovePropContactAssnType = false,
                ISClarityHMISSystem = null, //model.ISClarityHMISSystem,
                AlternateContactQuestion = string.Empty, //model.AlternateContactQuestion,
                AlternateContact_FirstName = string.Empty, //model.AlternateContact_FirstName,
                AlternateContact_MiddleName = string.Empty, //model.AlternateContact_MiddleName,
                AlternateContact_LastName = string.Empty, //model.AlternateContact_LastName,
                AlternateContact_Method_Email = false, //model.AlternateContact_Method_Email,
                AlternateContact_Method_MailingAddress = false, //model.AlternateContact_Method_MailingAddress,
                AlternateContact_Method_Phone = false, //model.AlternateContact_Method_Phone,
                AlternateContact_Email = string.Empty, //model.AlternateContact_Email,
                AlternateContact_PhoneType = string.Empty, //model.AlternateContact_PhoneType,
                AlternateContact_PhoneNumber = string.Empty, //model.AlternateContact_PhoneNumber,
                AlternateContact_PhoneNotification = string.Empty, //model.AlternateContact_PhoneNotification,
                AlternateContact_StreetAddress = string.Empty, //model.AlternateContact_StreetAddress,
                AlternateContact_HouseNum = string.Empty, //model.AlternateContact_HouseNum,
                AlternateContact_HouseFracNum = string.Empty, //model.AlternateContact_HouseFracNum,
                AlternateContact_LutPreDirCd = string.Empty, //model.AlternateContact_LutPreDirCd,
                AlternateContact_StreetName = string.Empty, //model.AlternateContact_StreetName,
                AlternateContact_LutStreetTypeCD = string.Empty, //model.AlternateContact_LutStreetTypeCD,
                AlternateContact_ApartmentUnit = string.Empty, //model.AlternateContact_ApartmentUnit,
                AlternateContact_State = string.Empty, //model.AlternateContact_State,
                AlternateContact_Zipcode = string.Empty, //model.AlternateContact_Zipcode,
                AlternateContact_CityName = string.Empty, //model.AlternateContact_CityName,
                AlternateContact_Unit = string.Empty, //model.AlternateContact_Unit,
                IsVeteran = null, //model.IsVeteran,
                IsCurrentlyHomeless = null, //model.IsCurrentlyHomeless,
                IsWorriedAboutBecomingHomeless = null, //model.IsWorriedAboutBecomingHomeless,
                IsInUnsafeHousing = null, //model.IsInUnsafeHousing,
                NoneOfHouseholdApply = null, //model.NoneOfHouseholdApply,
                SocialSecurityNumber = string.Empty, //model.SocialSecurityNumber,
                HMISNo = string.Empty, //model.HMISNumber,
                DateOfBirth = null //model.DateOfBirth

            });



        }
    }
}
