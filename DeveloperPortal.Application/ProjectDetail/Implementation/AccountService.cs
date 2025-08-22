using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Models.Account;
using DeveloperPortal.Models.Common;
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using static DeveloperPortal.Domain.PropertySnapshot.Constants;
using DeveloperPortal.Models.Common;
using System.Xml.Linq;
using DeveloperPortal.DataAccess.Entity.Data;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Index.HPRtree;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;
        private IConfiguration _config;
        private readonly AAHREntities _context;

        public AccountService(IAccountRepository accountRepository, IConfiguration config, AAHREntities context)
        {
            _accountRepository = accountRepository;
            _config = config;
            _context = context;
        }
        public async Task<List<VwPropertySearch>> GetACHPDetails(String FileNumber)
        {

            var data = await _accountRepository.GetVwPropertySearchesByFileNumberAsync(FileNumber);

            if (data != null)
            {
                var result = data.GroupBy(v => v.ProjectSiteId)
                            .Select(g => g.First())
                            .ToList();

                return result;

            }

            return new List<VwPropertySearch>();

        }
        public async Task<int> ContactIdentifierSave(ApplicantSignupModel signupModel, string userName, string source = "")
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

                contact.Type = ContactTypes.Applicant; //TODO: find the type


                int contactID = 0;
                /*Property API*/
                client.BaseAddress = new Uri(_config["AreaMgmtAPIURL:PropertyApiURL"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //save contact information to PCMS
                HttpResponseMessage response = client.PostAsJsonAsync("ContactMgmt/Save", contact).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var contactResponse = JsonConvert.DeserializeObject<BaseResponse>(result);
                    contactID = Convert.ToInt32(contactResponse.Response);
                }

                response.Dispose();
                response.Headers.ConnectionClose = true;
                if (contactID > 0)
                {
                    /*save data to ContactIdentifier*/
                    var Attributes = contactAttributeList.Union(contactAddressAttributeList).ToDictionary(k => k.Key, v => v.Value);

                    var contactId = await SaveContactToContactIdentifier(signupModel, contactID, contact.Type, userName, JsonConvert.SerializeObject(Attributes), source);

                   
                }
                return contactID;
            }

        }
        public async Task<int> SaveContactToContactIdentifier(ApplicantSignupModel model, int contactId, string contactType, string userName, string attributes, string source)
        {
            string Attributes = "";
            try
            {
         
                    ContactIdentifier contactIdentifier = _context.ContactIdentifiers.FirstOrDefault(m => m.ContactId == contactId && m.IsDeleted == false);

                    if (contactIdentifier == null)
                    {
                        contactIdentifier = new ContactIdentifier();
                    }
                if (contactType == "" || contactType == null)
                {
                    Attributes = !string.IsNullOrEmpty(attributes)
                                      ? attributes
                                      : "{" + "\"In\"" + ":" + "\"Office\"" + "}";
                }
                else
                {
                    Attributes = !string.IsNullOrEmpty(attributes)
                                    ? attributes    
                                    : "{" + "\"In\"" + ":" + "\"Office\"" + "," + "\"ContractorType\"" + ":" + "\"" + attributes + "\"" + " }";
                }

                //var connectionString = _context.Database.GetConnectionString();
                //Console.WriteLine("🔌 DB Connection String: " + connectionString);
                string? preDirCd = null;
                if (!model.IsPostBox && !string.IsNullOrWhiteSpace(model.StreetDir))
                {
                    bool isValid = await _context.LutStreetPrefixes.AnyAsync(x => x.PreDirCd == model.StreetDir);
                    preDirCd = isValid ? model.StreetDir : null;
                }

                var entity = new ContactIdentifier
                {
                    ContactId = contactId,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Email = model.EmailId,
                    HouseNum = model.StreetNum?.ToString(),
                    HouseFracNum = string.Empty,
                    //PreDirCd = model.IsPostBox ? null : model.StreetDir,
                    PreDirCd = preDirCd,
                    StreetName = model.IsPostBox ? model.PostBoxNum : model.StreetName,
                    PostDirCd = string.Empty,
                    StreetTypeCd = model.StreetType,
                    City = model.City,
                    State = model.State,
                    Zip = model.Zipcode,
                    PhoneNumber = model.PhoneNumber,
                    PhoneHome = model.PhoneNumber,
                    PhoneMobile = model.PhoneNumber,
                    UnitNo = model.UnitNumber,
                    ContactType = contactType,
                    IsEmployee = false,
                    IdmuserName = model.IDMUserName,
                    BirthDay = null,
                    BirthMonth = null,
                    BirthYear = null,
                    PhoneExtension = model.PhoneExtension,
                    Title = model.Title,
                    IsMailingAddress = false,
                    BusinessName = model.CompanyName,
                    Attributes = Attributes,
                    Source = source,
                    LutPhoneTypeCd = model.LutPhoneTypeCd,
                    PreferredContactMethod = string.Empty,
                    IsclarityHmissystem = null,
                    IsVeteran = null,
                    IsCurrentlyHomeless = null,
                    IsWorriedAboutBecomingHomeless = null,
                    IsInUnsafeHousing = null,
                    NoneOfHouseholdApply = null,
                    SocialSecurityNumber = string.Empty,
                    Hmisno = string.Empty,
                    DateOfBirth = null,
                    IsDeleted = false,
                    CreatedBy = userName,
                    CreatedOn = DateTime.Now
                };
              

                    _context.ContactIdentifiers.Add(entity);
                await _context.SaveChangesAsync();

                return entity.ContactId;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine("DbUpdateException:");
                Console.WriteLine(dbEx.InnerException?.Message ?? dbEx.Message);
                throw;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error saving ContactIdentifier: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                throw; 
            }
        }

        }


        public async Task<List<Project>> GetProjectDetailByFileNumberAsync(String FileNumber)
        {

            var data = await _accountRepository.GetProjectDetailByFileNumberAsync(FileNumber);

            if (data != null)
            {
                return  data;
            }

            return new List<Project>();

        }


        public async Task<(List<int> Saved, List<int> NotSaved)> SaveAssnPropContactAsync(List<string> projects, HttpContext httpContext)
        {
            var userId =  UserSession.GetUserSession(httpContext).UserID;
            var userName =  UserSession.GetUserSession(httpContext).UserName;

             var userName1  =   UserSession.GetUserSession(httpContext).UserName;

            var lutContactType = await _accountRepository.GetLutPropContactAssnTypes("Developer");

            var savedProjects = new List<int>();
            var notSavedProjects = new List<int>();

            foreach (var item in projects)
            {
                int projectId = int.Parse(item);

                var popContact = new AssnPropContact
                {
                    IdentifierType = "Project",
                    ContactIdentifierId = userId,
                    LutContactTypeId = lutContactType.LutContactTypeId,
                    Status = "pending approval",
                    Source = "AAHRDeveloperPortal",
                    ProjectId = projectId
                };

                bool isSaved = await _accountRepository.AddPropContactIfNotExistsAsync(popContact, userName);

                if (isSaved)
                    savedProjects.Add(projectId);
                else
                    notSavedProjects.Add(projectId);
            }

            return (savedProjects, notSavedProjects);
        }


    
    }
}


