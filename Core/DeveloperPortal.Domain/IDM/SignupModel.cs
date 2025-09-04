using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAHR.Models.Resource;
using ComCon.PropertySnapshot.Entity;

namespace DeveloperPortal.Models.IDM
{
    public class SignupModel
    {
        //#region "Property Declaration"

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_ReasonForSignup")]
        //public string AccountReason { get; set; }

        ////public dynamic AccountReasonList { get; set; }
        //[Required(ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Req_FirstName")]
        //[RegularExpression(@"^[a-zA-Z '.-]*$", ErrorMessage = null, ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Regx_Alphabates")]
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_FirstName")]
        //public string FirstName { get; set; }


        //[RegularExpression(@"^[a-zA-Z '.-]*$", ErrorMessage = null, ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Regx_Alphabates")]
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_MiddleName")]
        //public string MiddleName { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Req_LastName")]
        //[RegularExpression(@"^[a-zA-Z '.-]*$", ErrorMessage = null, ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Regx_Alphabates")]
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_LastName")]
        //public string LastName { get; set; }

        ////Reason for My Account first/last name updates
        ////True: account was transferred to a new person
        ////False: original account holder is updating their name
        ////null: no updates made to name fields
        //public bool? IsNameUpdateForNewAccountHolder { get; set; }

        //public string CurrentFirstName { get; set; }

        //public string CurrentLastName { get; set; }

        //public string ContactNo { get; set; }

        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}", ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Err_InvalidEmail1")]
        //[Required(ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Req_Email")]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Err_InvalidEmail1", ErrorMessage = null)]
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_Email")]
        //public string EmailId { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Err_ReEnterEmail")]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Err_InvalidEmail1", ErrorMessage = null)]
        ////[CaseInsensitiveCompare("EmailId", ErrorMessageResourceType = typeof(Validations), ErrorMessageResourceName = "EmailCompareMsg")]
        //[System.ComponentModel.DataAnnotations.CompareAttribute("EmailId", ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Err_EmailDoesNot")]
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_ConfirmEmail")]
        //public string ConfirmEmailId { get; set; }

       
        //[Required(ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Req_Password")]
        //[DataType(DataType.Password)]
        //[StringLength(20, ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Txt_MaximumCharactersAllowed")]
        //[RegularExpression(@"^.{6,}$", ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Txt_PasswordNotLong")]
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_Password")]
        //public string Password { get; set; }

  
        //[Required(ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Err_ReEnterPassword")]
        //[DataType(DataType.Password)]
        //[StringLength(20, ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Txt_MaximumCharactersAllowed")]
        //[System.ComponentModel.DataAnnotations.CompareAttribute("Password", ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Err_PasswordDoesNot")]
        //[RegularExpression(@"^.{6,}$", ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Err_PasswordNotLong")]
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_ConfirmPassword")]
        //public string ConfirmPassword { get; set; }

        ////[Required(ErrorMessageResourceType = typeof(Validations), ErrorMessageResourceName = "SecurityQuestionReqMsg")]
        ////[Display(ResourceType = typeof(Validations), Name = "SecurityQuestionLbl")]
        ////public string SecurityQuestion { get; set; }
        ////
        ////[RegularExpression(@"^(?![\W_]+$)[a-zA-Z0-9 .&'@_-]+$", ErrorMessage = "Please enter valid input.")]
        ////[Required(ErrorMessageResourceType = typeof(Validations), ErrorMessageResourceName = "SecurityAnsReqMsg")]
        ////[Display(ResourceType = typeof(Validations), Name = "SecurityAnswerLbl")]
        ////[StringLength(20)]
        ////public string SecurityAnswer { get; set; }

        ////public dynamic SecurityQuesList { get; set; }

        //public bool SignupTermCondition { get; set; }

        //public Dictionary<string, string> dictionary = new Dictionary<string, string>();

        //public List<NotificationInfoModel> notificationInfoList { get; set; }

        ////public UserValidationResponse userValidationResponse { get; set; }

        //public Dictionary<string, string> NotificationData = new Dictionary<string, string>();
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_IsClarityHMISSystem")]
        //public bool? ISClarityHMISSystem { get; set; } = false;

       
        //[MaxLength(9, ErrorMessage = "Please input a valid HMIS number. This number is 9 characters long and contains only numbers and letters.")]
        //[MinLength(9, ErrorMessage = "Please input a valid HMIS number. This number is 9 characters long and contains only numbers and letters.")]
        //[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Err_InvalidHMISNumber")]
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_HMISNo")]
        //public string HMISNo { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_NameChangeReason")]
        //public string NameChangeReason { get; set; }

        //#region Property for Account and contact

        //public string ContactName { get; set; }
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_Company")]
        //public string Company { get; set; }
        //public string Title { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_AdditionalContactMethod")]
        ////[RequiredIf("IsApplicant == true", ErrorMessage = "Select Yes or No")]
        //public int AlternateContactMethodcd { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_ProvideAnAddress")]
        ////[RequiredIf("IsApplicant == true", ErrorMessage = "Select Yes or No")]
        //public bool IsAddressProvided { get; set; } = true;
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_PoBoxQuestion")]
        //public bool IsPostBox { get; set; }



        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_PoBox")]
        ////[RequiredIf("!IsClient && (IsApplicant || AlternateContactMethodcd == 2) && IsPostBox", ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Req_POBox")]
     
        //public string PostBoxNum { get; set; }


        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_HouseNumber")]
  
        ////[RequiredIfNot("IsPostBox", true, ErrorMessage = "House number is required")]
        //public int? HouseNum { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_HouseFractionNumber")]
        //public string HouseFracNum { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_StreetDirection")]
        //public string LutPreDirCd { get; set; }

        //public List<LutPreDir> LutPreDirCdList { get; set; }

        
        ////[RequiredIfNot("IsPostBox", true, ErrorMessage = "Street name is required")]
        //public string StreetName { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_StreetType")]
        //public string LutStreetTypeCD { get; set; }

        //public List<LutStreetType> LutStreetTypeList { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_StreetPostDirection")]
        //public string PostDirCd { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_UnitNumber")]
        //public string Unit { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_City")]
      
        //public string City { get; set; }

        
        //public string LutStateCD { get; set; }

        //public List<LutState> LutStateCDList { get; set; }

     
        //// [RegularExpression(@"\d{5}$", ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Err_ZipCode")]
        //[RegularExpression(@"\d{5}$", ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Txt_ZipCodeMust")]
        //[StringLength(5, ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Txt_ZipCodeMust")]
        //public string Zip { get; set; }
        //public string ZipSuffix { get; set; }
        //public bool? IsProfileContact { get; set; }

        
        //public string PhoneNumber { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_PhoneNumberExtn")]
        //public string Extn { get; set; }

        
        //public string LutPhoneTypeCd { get; set; }

    
        //public string AltPhoneNumber { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_AdditionalPhoneNumberExtn")]
        //public string AltExtn { get; set; }

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_AdditionalPhoneNumberType")]
        //public string LutAltPhoneTypeCd { get; set; }

        //// public List<Phone> Phone { get; set; }

        //public int? IDMUserID { get; set; }
        //public string IDMUserName { get; set; }
        //public int OrganizationID { get; set; }
        //public bool IsLocked { get; set; }
        //public bool IsDeleted { get; set; }
        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_IsCityEmployee")]
        //public bool IsCityEmployee { get; set; }
        //public bool IsApplicant { get; set; }
        //public DateTime StartDate { get; set; }

        
        //public string EmployeeID { get; set; }

        //public string Department { get; set; }
  
        //public string Designation { get; set; }
        //public string CommunicationMethod { get; set; }

        //public List<LutAltContactType> AltContactTypeList { get; set; }

        //public List<OrganizationContactModel> HousingAdvocateAgencyList { get; set; }

        //public bool IsHousingAdvocate { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SignupResource), ErrorMessageResourceName = "Req_SelectAgency")]
        //public int? HousingAdvocateAgencyId { get; set; }


        ////For Client
        //public bool IsClient { get; set; }

        //public int? BirthMonth { get; set; }

      
        //public int? BirthDay { get; set; }

        //public int? BirthYear { get; set; }

        //public int ContactID { get; set; }

        //public List<DropDownValue> BirthMonthList { get; set; }

        //public List<DropDownValue> BirthDayList { get; set; }

        //public string ClientBirthDate { get; set; }
        //public bool IsClientAddedEdited { get; set; }
        //public bool ClientWithOtherDetailsExist { get; set; }
        //public bool IsOwnerPM { get; set; }
        //public int ContactAddressID { get; set; }
        //public int PropContactId { get; set; }
        //public bool IsAccountTypeSelected { get; set; }
        //public int ContactIdentifierID { get; set; }
        //#endregion

        //#region Notification property
        //public Guid UserRowId { get; set; }

        //#endregion //Notification property  

        //#region Subscription

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_IsListingAdded")]
        //public bool IsListingAdded { get; set; } = true;

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_IsOpenForApplication")]
        //public bool IsOpenForApplication { get; set; } = true;

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_IsWaitlistOpen")]
        //public bool IsWaitlistOpen { get; set; } = true;

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_IsOpenForApplicationForAffordable")]
        //public bool IsOpenForAffordableApplication { get; set; } = true;

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_IsClosedForApplicationForAffordable")]
        //public bool IsClosedForAffordableApplication { get; set; } = true;

        //[Display(ResourceType = typeof(SignupResource), Name = "Lbl_IsAccessibleUnit")]
        //public bool IsAccessibleUnit { get; set; } = true;

        //#endregion Subscription

        //#endregion // Property Declaration

        //#region Send Notification Mail
        ///// <summary>
        ///// Send Notification Mail
        ///// </summary>
        ///// <param name="TemplateId"></param>
        ///// <param name="MailId"></param>
        //public void SendNotificationMail(string templateName, string MailId, string emailAction, string MailCC = null, string MailBCC = null)
        //{
        //    GetNotificatioInfo(templateName, this.NotificationData, MailId, MailCC, MailBCC);

        //    Task.Factory.StartNew(() =>
        //    {
        //        SendNotification sendNotification = new SendNotification();
        //        sendNotification.SendMail(this.notificationInfoList, new NotificationCredential(), emailAction);
        //    });
        //}

        //#endregion


        //#region Prepare Dynamic Subject
        ///// <summary>
        /////Function to Prepare Dynamic Subject For Notification
        ///// </summary>
        //public string PrepareSubject(string emailSubject)
        //{
        //    if (dictionary != null)
        //    {
        //        foreach (var item in dictionary)
        //        {
        //            emailSubject = emailSubject.Replace("[" + item.Key + "]", item.Value);
        //        }
        //    }

        //    return emailSubject;
        //}
        //#endregion

        //#region Prepare Dynamic Body
        ///// <summary>
        /////Function to Prepare Dynamic Body For Notification
        ///// </summary>
        //public string PrepareBody(string emailBody)
        //{
        //    if (dictionary != null)
        //    {
        //        foreach (var item in dictionary)
        //        {
        //            emailBody = emailBody.Replace("[" + item.Key + "]", item.Value);
        //        }
        //    }

        //    return emailBody;
        //}
        //#endregion

        //#region Prepare Standard Footer

        ///// <summary>
        ///// Prepare standard footer
        ///// </summary>
        ///// <returns></returns>
        //public string PrepareFooterAndCommonText(string body)
        //{
        //    using (ComConEntities db = new ComConEntities())
        //    {
        //        //  string emailFooter = db.NotificationTemplates.Where(m => m.Name == "Common Email Footer").SingleOrDefault().EmailBody;

        //        //   body = body.Replace("[Footer]", emailFooter);

        //        string emailFooter = string.Empty;

        //        if (body.Contains("[Program Footer]"))
        //        {
        //            emailFooter = db.NotificationTemplates.Where(m => m.Name == EmailTemplateConstant.ProgramFooterTemplate).SingleOrDefault().EmailBody;
        //            body = body.Replace("[Program Footer]", emailFooter);

        //        }
        //        if (body.Contains("[System Footer]"))
        //        {
        //            emailFooter = db.NotificationTemplates.Where(m => m.Name == EmailTemplateConstant.SystemFooterTemplate).SingleOrDefault().EmailBody;
        //            body = body.Replace("[System Footer]", emailFooter);

        //        }

        //        foreach (var item in EmailTemplateConstant.EmailConstants)
        //        {
        //            body = body.Replace("[" + item.Key + "]", item.Value);
        //        }

        //        return body;
        //    }

        //}
        //#endregion

        //#region Get Notification Info
        ///// <summary>
        ///// Function to get Notification Details
        ///// </summary>
        //public void GetNotificatioInfo(string TemplateName, Dictionary<string, string> notificationData, string MailId, string MailCC = null, string MailBCC = null)
        //{
        //    notificationInfoList = new List<NotificationInfoModel>();
        //    dictionary = notificationData;

        //    using (ComConEntities db = new ComConEntities())
        //    {
        //        var NotificationDetails = db.NotificationTemplates.Where(s => s.Name == TemplateName).ToList();

        //        foreach (var notificationDetail in NotificationDetails)
        //        {
        //            NotificationInfoModel notificationModel = new NotificationInfoModel();
        //            notificationModel.MailId = MailId;
        //            notificationModel.MailBCC = MailBCC;
        //            notificationModel.MailCC = MailCC;
        //            notificationModel.Subject = PrepareSubject(notificationDetail.EmailSubject);
        //            notificationModel.Body = PrepareBody(notificationDetail.EmailBody);
        //            notificationModel.Body = PrepareFooterAndCommonText(notificationModel.Body);
        //            notificationInfoList.Add(notificationModel);
        //        }
        //    }
        //}
        //#endregion

        ///// <summary>
        ///// Save contact information
        ///// </summary>
        ///// <param name="signupModel"></param>
        ///// <param name="userName"></param>
        ///// <returns></returns>
        //public int SaveContactInformation(SignupModel signupModel, string userName, string source = "")
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        Dictionary<string, string> contactAttributeList = new Dictionary<string, string>();
        //        Dictionary<string, string> contactAddressAttributeList = new Dictionary<string, string>();

        //        ContactRenderModel contact = new ContactRenderModel();

        //        /*Contact details*/
        //        contact.ContactId = signupModel.ContactID;
        //        contact.UserName = userName;
        //        contact.IDMUserName = (source == AppConstant.WebRegister) ? userName : null;
        //        contact.FirstName = signupModel.FirstName;
        //        contact.MiddleName = signupModel.MiddleName;
        //        contact.LastName = signupModel.LastName;
        //        contact.Email = signupModel.EmailId;
        //        contact.Title = (signupModel.Title != null ? signupModel.Title.Trim() : "");
        //        contact.Company = (signupModel.Company != null ? signupModel.Company : "");
        //        contact.OrganizationId = signupModel.OrganizationID;
        //        contact.PreferredContactMethod = signupModel.AlternateContactMethodcd == (int)ContactMethods.None
        //                                         ? null
        //                                         : (signupModel.AlternateContactMethodcd == (int)ContactMethods.USMail
        //                                            ? PreferredContactMethods.USMail
        //                                            : PreferredContactMethods.Phone);
        //        contact.Source = source;
        //        contact.BirthDay = signupModel.BirthDay;
        //        contact.BirthMonth = signupModel.BirthMonth;
        //        contact.BirthYear = signupModel.BirthYear;

        //        switch (signupModel.LutPhoneTypeCd)
        //        {
        //            case "H":
        //                contact.PhoneHome = signupModel.PhoneNumber;
        //                break;
        //            case "M":
        //                contact.PhoneCell = signupModel.PhoneNumber;
        //                break;
        //            case "W":
        //                contact.PhoneBusiness = signupModel.PhoneNumber;
        //                break;
        //            default:
        //                break;
        //        }
        //        contact.PhoneExtension = signupModel.Extn;

        //        /*POBox attribute to save in ContactAddress */
        //        if (signupModel.IsPostBox)
        //        {
        //            contactAddressAttributeList.Add("IsPOBox", "true");
        //            contact.ContactAddressAttribute = JsonConvert.SerializeObject(contactAddressAttributeList);
        //        }

        //        /*Contact Address details*/
        //        contact.ContactAddressId = signupModel.ContactAddressID;
        //        contact.HouseNum = Convert.ToString(signupModel.HouseNum);
        //        contact.HouseFracNum = signupModel.HouseFracNum;
        //        contact.PreDirection = signupModel.LutPreDirCd;
        //        contact.StreetName = signupModel.IsPostBox ? signupModel.PostBoxNum : signupModel.StreetName;
        //        contact.StreetTypeCd = signupModel.LutStreetTypeCD;
        //        contact.PostDirection = signupModel.PostDirCd;
        //        contact.City = signupModel.City;
        //        contact.State = signupModel.LutStateCD;
        //        contact.Zip = signupModel.Zip;
        //        contact.Unit = signupModel.Unit;
        //        contact.IsMarkedForMailing = signupModel.AlternateContactMethodcd == (int)ContactMethods.USMail ? true : false;
        //        contact.PropContactId = signupModel.PropContactId;

        //        if (signupModel.IsOwnerPM)
        //        {
        //            contact.Type = ContactTypes.Owner;
        //            contact.PreferredContactMethod = PreferredContactMethods.USMail;
        //        }
        //        else if (signupModel.IsCityEmployee)
        //        {
        //            contact.Type = ContactTypes.CityEmployee;
        //            contact.IsEmployee = true;
        //            contact.IsContactAddress = false;// City Employee dont required Contact Address 
        //            /*Employee details to save in Contact attribute*/
        //            contactAttributeList.Add("EmployeeID", signupModel.EmployeeID);
        //            contactAttributeList.Add("Department", signupModel.Department);
        //            contactAttributeList.Add("Classification", signupModel.Designation);
        //            contact.ContactAttribute = JsonConvert.SerializeObject(contactAttributeList);
        //        }
        //        else if (signupModel.IsClient)
        //        {
        //            contact.Type = ContactTypes.Client;
        //            contact.IsAssnContactContactAdd = true;
        //            /*For Client user depends on selected contact method allowing to add or skip contact address*/
        //            if (contact.PreferredContactMethod != PreferredContactMethods.USMail)
        //            {
        //                contact.IsContactAddress = false;
        //            }
        //            /*Added attribute IsClient: true If client data added by Advocate on behalf of client*/
        //            contactAttributeList.Add("IsClient", signupModel.IsClient.ToString());
        //            contactAttributeList.Add("IsActive", "true");
        //            if (!string.IsNullOrEmpty(signupModel.NameChangeReason))
        //            {
        //                contactAttributeList.Add("NameChangeReason", signupModel.NameChangeReason);
        //            }
        //            contact.ContactAttribute = JsonConvert.SerializeObject(contactAttributeList);
        //        }
        //        else if (signupModel.IsApplicant)
        //        {
        //            contact.Type = ContactTypes.Applicant;
        //            /*For Applicant user depends on selected contact method allowing to add or skip contact address*/
        //            if (contact.PreferredContactMethod != PreferredContactMethods.USMail)
        //            {
        //                contact.IsContactAddress = false;
        //            }
        //            if (!string.IsNullOrEmpty(signupModel.NameChangeReason))
        //            {
        //                contactAttributeList.Add("NameChangeReason", signupModel.NameChangeReason);
        //            }
        //        }
        //        else if (signupModel.IsHousingAdvocate)
        //        {
        //            contact.PreferredContactMethod = PreferredContactMethods.USMail;
        //            contact.Type = ContactTypes.Advocate;
        //            if (signupModel.IsLocked)
        //            {
        //                contactAttributeList.Add("IsLocked", signupModel.IsLocked.ToString());
        //                contact.ContactAttribute = JsonConvert.SerializeObject(contactAttributeList);
        //            }

        //        }

        //        /*Alternte phone number to save in Contact*/
        //        if (!string.IsNullOrEmpty(signupModel.LutAltPhoneTypeCd) && signupModel.LutAltPhoneTypeCd != "- Select -")
        //        {
        //            contactAttributeList.Add("PhoneType", signupModel.LutAltPhoneTypeCd);
        //            contactAttributeList.Add("PhoneNo", signupModel.AltPhoneNumber);
        //            contactAttributeList.Add("PhoneExtn", signupModel.AltExtn);
        //            contact.ContactAttribute = JsonConvert.SerializeObject(contactAttributeList);
        //        }
        //        else
        //        {
        //            if (contactAttributeList != null && contactAttributeList.Count() > 0)
        //            {
        //                contact.ContactAttribute = JsonConvert.SerializeObject(contactAttributeList);
        //            }
        //        }

        //        contact.IsRemovePropContactAssnType = false;
        //        int contactID = 0;
        //        /*Property API*/
        //        client.BaseAddress = new Uri(AppConfig.GetConfigValue("PropertyApiURL"));
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        if (signupModel.IsClient != true)
        //        {
        //            //Check if user already exist in PCMS
        //            HttpResponseMessage httpResponseMessage = client.GetAsync(string.Format("Contact/GetContactByUserName?userName={0}", Uri.EscapeDataString(contact.IDMUserName).Replace("%20", "+"))).Result;
        //            if (httpResponseMessage.IsSuccessStatusCode)
        //            {
        //                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
        //                var contactResponse = JsonConvert.DeserializeObject<BaseResponse>(result);
        //                ContactRenderModel contactRenderModel = JsonConvert.DeserializeObject<ContactRenderModel>(contactResponse.Response.ToString());
        //                contactID = Convert.ToInt32(contactRenderModel.ContactId);
        //            }

        //            contact.ContactId = contactID;
        //        }
        //        else
        //        {
        //            contact.ContactId = signupModel.ContactID;
        //        }
        //        HttpResponseMessage response = client.PostAsJsonAsync("ContactMgmt/Save", contact).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            var contactResponse = JsonConvert.DeserializeObject<BaseResponse>(result);
        //            contactID = Convert.ToInt32(contactResponse.Response);
        //        }

        //        response.Dispose();
        //        response.Headers.ConnectionClose = true;

        //        if (contactID > 0)
        //        {
        //            /*save data to ContactIdentifier*/
        //            signupModel.IDMUserName = signupModel.IsClient == true ? null : signupModel.EmailId;
        //            var Attributes = contactAttributeList.Union(contactAddressAttributeList).ToDictionary(k => k.Key, v => v.Value);

        //            signupModel.ContactIdentifierID = SaveContactToContactIdentifier(signupModel, contactID, contact.Type, userName, JsonConvert.SerializeObject(Attributes), source);
        //        }

        //        return contactID;
        //    }

        //}

        ///// <summary>
        ///// save contact to contactIdentifier
        ///// </summary>
        ///// <param name="model"></param>
        ///// <param name="ContactId"></param>
        ///// <param name="contactType"></param>
        ///// <param name="userName"></param>
        ///// <param name="contactAttributes"></param>
        ///// <param name="contactAddressAttributes"></param>
        ///// <param name="source"></param>
        ///// <returns></returns>
        //public int SaveContactToContactIdentifier(SignupModel model, int ContactId, string contactType, string userName, string Attributes, string source)
        //{
        //    /*save contact details to ContactIdentifier*/
        //    return
        //    new ContactIdentifiersService().SaveRegisterOrClientContact(new ComCon.PropertySnapshot.Models.ContactIdentifierModel
        //    {
        //        ContactID = ContactId,
        //        FirstName = model.FirstName,
        //        MiddleName = model.MiddleName,
        //        LastName = model.LastName,
        //        Email = model.EmailId,
        //        HouseNum = Convert.ToString(model.HouseNum),
        //        HouseFracNum = model.HouseFracNum,
        //        PreDirCd = model.IsPostBox ? null : model.LutPreDirCd,
        //        StreetName = model.IsPostBox ? model.PostBoxNum : model.StreetName,
        //        PostDirCd = model.PostDirCd,
        //        StreetTypeCd = model.LutStreetTypeCD,
        //        City = model.City,
        //        State = model.LutStateCD,
        //        Zip = model.Zip,
        //        BusinessPhoneNumber = model.PhoneNumber,
        //        HomePhoneNumber = model.PhoneNumber,
        //        MobilePhoneNumber = model.PhoneNumber,
        //        Unit = model.Unit,
        //        ContactTypeName = contactType,
        //        UserName = userName,
        //        ContractorType = "",
        //        IsEmployee = model.IsCityEmployee ? true : false,
        //        IDMUserName = model.IDMUserName,
        //        BirthDay = model.BirthDay,
        //        BirthMonth = model.BirthMonth,
        //        BirthYear = model.BirthYear,
        //        PhoneExtension = model.Extn,
        //        Title = model.Title,
        //        IsMarkedForMailing = model.AlternateContactMethodcd == (int)ContactMethods.USMail ? true : false,
        //        Company = model.Company,
        //        ContactAttribute = Attributes,
        //        Source = source,
        //        OrganizationId = model.OrganizationID,
        //        IsAssnContactContactAdd = model.IsClient ? true : false,
        //        LutPhoneTypeCd = model.LutPhoneTypeCd,
        //        PreferredContactMethod = model.AlternateContactMethodcd == (int)ContactMethods.None
        //                                         ? null
        //                                         : (model.AlternateContactMethodcd == (int)ContactMethods.USMail
        //                                            ? PreferredContactMethods.USMail
        //                                            : PreferredContactMethods.Phone),
        //        IsRemovePropContactAssnType = false,
        //        ISClarityHMISSystem = model.ISClarityHMISSystem,
        //        HMISNo = (model.ISClarityHMISSystem == true) ? model.HMISNo : null

        //    });



        //}


        //#region Housing Advocate Client
        ///// <summary>
        ///// get agency list with contact
        ///// </summary>
        ///// <returns></returns>
        //public List<OrganizationContactModel> GetAgencyList()
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        List<OrganizationContactModel> list = new List<OrganizationContactModel>();
        //        /*Property API*/
        //        client.BaseAddress = new Uri(AppConfig.GetConfigValue("PropertyApiURL"));
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = client.PostAsJsonAsync("ContactMgmt/GetAgencies", AppConstant.AppSource).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            var apiResponse = JsonConvert.DeserializeObject<BaseResponse>(result);
        //            list = (List<OrganizationContactModel>)apiResponse.Response;
        //        }

        //        response.Dispose();
        //        response.Headers.ConnectionClose = true;

        //        return list;
        //    }
        //}

        ///// <summary>
        ///// Agency address 
        ///// </summary>
        ///// <param name="agency"></param>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //public SignupModel GetHousingAdvocateAddress(int agency, List<OrganizationContactModel> list)
        //{
        //    SignupModel model = new SignupModel();
        //    var advocate = list.FirstOrDefault(x => x.OrganizationID == agency);
        //    model.HouseNum = Convert.ToInt32(advocate?.HouseNum);
        //    model.HouseFracNum = advocate?.HouseFracNum;
        //    model.LutPreDirCd = advocate?.PreDirection;
        //    model.StreetName = advocate?.StreetName;
        //    model.LutStreetTypeCD = advocate?.StreetTypeCd;
        //    model.City = advocate?.City;
        //    model.LutStateCD = advocate?.State;
        //    model.Zip = advocate?.Zip;
        //    return model;
        //}

        ///// <summary>
        ///// months
        ///// </summary>
        ///// <returns></returns>
        //public List<DropDownValue> FillBirthMonthList()
        //{
        //    List<DropDownValue> monthList = new List<DropDownValue>();

        //    monthList.Add(new DropDownValue() { text = "January", value = 1 });
        //    monthList.Add(new DropDownValue() { text = "February", value = 2 });
        //    monthList.Add(new DropDownValue() { text = "March", value = 3 });
        //    monthList.Add(new DropDownValue() { text = "April", value = 4 });
        //    monthList.Add(new DropDownValue() { text = "May", value = 5 });
        //    monthList.Add(new DropDownValue() { text = "June", value = 6 });
        //    monthList.Add(new DropDownValue() { text = "July", value = 7 });
        //    monthList.Add(new DropDownValue() { text = "August", value = 8 });
        //    monthList.Add(new DropDownValue() { text = "September", value = 9 });
        //    monthList.Add(new DropDownValue() { text = "October", value = 10 });
        //    monthList.Add(new DropDownValue() { text = "November", value = 11 });
        //    monthList.Add(new DropDownValue() { text = "December", value = 12 });

        //    return monthList;
        //}

        ///// <summary>
        ///// days
        ///// </summary>
        ///// <returns></returns>
        //public List<DropDownValue> FillBirthDayList()
        //{
        //    List<DropDownValue> DayList = new List<DropDownValue>();

        //    for (int i = 1; i <= 31; i++)
        //    {
        //        DayList.Add(new DropDownValue() { text = i.ToString(), value = i });
        //    }

        //    return DayList;
        //}
        //#endregion

    }
    public class LutPhoneType
    {
        public string LutPhoneTypeCd { get; set; }

        public string PhoneType { get; set; }

        public string Description { get; set; }

        public bool IsObsolete { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<ContactIdentifier> ContactIdentifiers { get; set; }

        public LutPhoneType()
        {
            ContactIdentifiers = new HashSet<ContactIdentifier>();
        }
    }

    public partial class LutState
    {
        public string LutStateCd { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
    public partial class LutPreDir
    {
        public string LutPreDirCD { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
    public partial class LutStreetType
    {
        public string LutStreetTypeCd { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class OrganizationContactModel
    {
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public string EmailDomain { get; set; }

        public string HouseNum { get; set; }
        public string HouseFracNum { get; set; }
        public string PreDirection { get; set; }
        public string StreetName { get; set; }
        public string StreetTypeCd { get; set; }
        public string PostDirection { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ContactAttribute { get; set; }
        public string ContactAddressAttribute { get; set; }
        public string IDMUserName { get; set; }

    }
}
