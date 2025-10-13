using DeveloperPortal.Application.Common;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Implementation;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.Dashboard;
using DeveloperPortal.Models.Common;
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using static DeveloperPortal.Domain.PropertySnapshot.Constants;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;
        private IConfiguration _config;
        private readonly AAHREntities _context;
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        public AccountService(IStoredProcedureExecutor storedProcedureExecutor, IAccountRepository accountRepository, IConfiguration config, AAHREntities context)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
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
                contact.ContactId = signupModel.ContactID;
                contact.UserName = userName;
                contact.IDMUserName = (source == AppConstant.WebRegister) ? userName : null;
                contact.FirstName = signupModel.FirstName;
                contact.MiddleName = signupModel.MiddleName;
                contact.LastName = signupModel.LastName;
                contact.Email = signupModel.EmailId;
                contact.Title = (signupModel.Title != null ? signupModel.Title.Trim() : "");
                contact.Company = (signupModel.Company != null ? signupModel.Company : "");//Company
                contact.OrganizationId = signupModel.OrganizationID;
                contact.AdditionalEmail = signupModel.AdditionalEmail;
                contact.Source = source;
                contact.BirthDay = signupModel.BirthDay;
                contact.BirthMonth = signupModel.BirthMonth;
                contact.BirthYear = signupModel.BirthYear;

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
                else
                {
                    contactAddressAttributeList.Add("IsPOBox", "false");
                    contact.ContactAddressAttribute = JsonConvert.SerializeObject(contactAddressAttributeList);
                }
                /*Contact Address details*/
                contact.ContactAddressId = signupModel.ContactAddressID;
                contact.HouseNum = signupModel.IsPostBox ? "" : Convert.ToString(signupModel.HouseNum);
                contact.HouseFracNum = signupModel.IsPostBox ? "" : signupModel.HouseFracNum;
                contact.PreDirection = signupModel.IsPostBox ? "" : signupModel.LutPreDirCd;
                contact.StreetName = signupModel.IsPostBox ? signupModel.PostBoxNum : signupModel.StreetName;
                contact.StreetTypeCd = signupModel.IsPostBox ? "" : signupModel.LutStreetTypeCD;
                contact.PostDirection = signupModel.IsPostBox ? "" : signupModel.PostDirCd;
                contact.City = signupModel.City;
                contact.State = signupModel.LutStateCD;
                contact.Zip = signupModel.Zipcode;
                contact.Unit = signupModel.IsPostBox ? "" : signupModel.Unit;
                contact.IsMarkedForMailing = signupModel.AlternateContactMethodcd == (int)ContactMethods.USMail ? true : false;
                contact.PropContactId = signupModel.PropContactId;

                contact.Type = ContactTypes.Applicant; //TODO: find the type


                int contactID = 0;
                /*Property API*/
                client.BaseAddress = new Uri(_config["AreaMgmtAPIURL:PropertyApiURL"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (signupModel.IsClient != true)
                {
                    //Check if user already exist in PCMS
                    HttpResponseMessage httpResponseMessage = client.GetAsync(string.Format("Contact/GetContactByUserName?userName={0}", Uri.EscapeDataString(contact.IDMUserName).Replace("%20", "+"))).Result;
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        var contactResponse = JsonConvert.DeserializeObject<BaseResponse>(result);
                        ContactRenderModel contactRenderModel = JsonConvert.DeserializeObject<ContactRenderModel>(contactResponse.Response.ToString());
                        contactID = Convert.ToInt32(contactRenderModel.ContactId);

                        if (contact.ContactAddressId == 0 && contactRenderModel.ContactAddressId != 0)
                        {
                            contact.ContactAddressId = contactRenderModel.ContactAddressId;
                        }
                    }

                    contact.ContactId = contactID;

                }
                else
                {
                    contact.ContactId = signupModel.ContactID;
                }

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

                ContactIdentifier alt_contactIdentifier = _context.ContactIdentifiers.FirstOrDefault(m => m.AltContactReferenceId == contactIdentifier.ContactIdentifierId);
                bool altcontactexists = false;
                if (alt_contactIdentifier == null)
                {
                    alt_contactIdentifier = new ContactIdentifier();
                }
                else
                {
                    altcontactexists = true;
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
                    State = model.LutStateCD,
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
                var contactOrganization = contactIdentifier.AssnOrganizationContacts.FirstOrDefault(x => x.Organization.Name == model.Company && x.IsDeleted == false && x.Organization.IsDeleted == false);
                if (!string.IsNullOrEmpty(model.Company))
                {
                    if (contactOrganization == null || model.OrganizationID == 0)
                    {

                        List<AssnOrganizationContact> lstOrgContact = _context.AssnOrganizationContacts.Where(o => o.IsDeleted != true && o.ContactIdentifierId == contactIdentifier.ContactIdentifierId).ToList();
                        foreach (var orgContact in lstOrgContact)
                        {
                            orgContact.IsDeleted = true;
                            _context.Entry(orgContact).State = EntityState.Modified;
                            _context.SaveChanges(userName);
                        }


                        var organization = _context.Organizations.FirstOrDefault(x => x.Name == model.Company && x.IsDeleted == false);
                        if (organization == null)
                        {
                            organization = new Organization
                            {
                                Name = model.Company,
                                IsDeleted = false,
                                IsReviewRequired = false
                            };

                            _context.Organizations.Add(organization);
                            _context.SaveChanges(userName);
                        }
                        contactOrganization = new AssnOrganizationContact
                        {
                            OrganizationId = organization.OrganizationId,
                            AssociationType = "Full Time",
                            AssociatedFrom = DateOnly.FromDateTime(DateTime.Now.AddYears(-2)),
                            AssociatedTo = DateOnly.FromDateTime(DateTime.Now),

                            IsReviewRequired = false,
                            IsDeleted = false,
                            Source = source,

                            CreatedOn = DateTime.Now,   // ✅ set explicitly
                            CreatedBy = userName,       // if you track user
                            ModifiedOn = DateTime.Now,  // or leave null if allowed
                            ModifiedBy = userName
                        };


                        contactIdentifier.AssnOrganizationContacts.Add(contactOrganization);
                    }
                    else
                    {
                        contactOrganization.Organization.Name = model.Company;
                    }
                }
                else
                {
                    //To clean up old undeleted records.
                    List<AssnOrganizationContact> lstOrgContact = _context.AssnOrganizationContacts.Where(o => o.IsDeleted != true && o.ContactIdentifierId == contactIdentifier.ContactIdentifierId).ToList();
                    foreach (var orgContact in lstOrgContact)
                    {
                        orgContact.IsDeleted = true;
                        if (contactOrganization != null)
                        {
                            if (orgContact.AssnOrganizationContactId == contactOrganization.AssnOrganizationContactId)
                            {
                                orgContact.AssociatedTo = DateOnly.FromDateTime(DateTime.Now);
                            }

                        }
                        _context.Entry(orgContact).State = EntityState.Modified;
                        _context.SaveChanges(userName);
                    }

                }



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




        public async Task<List<Project>> GetProjectDetailByFileNumberAsync(String FileNumber)
        {
            var data = await _accountRepository.GetProjectDetailByFileNumberAsync(FileNumber);
            return data;

        }


        public async Task<APNSearch> GetAPNProjectName(String APNNumber)
        {
            try
            {
                APNSearch APNSearch = new APNSearch();


                var parameters = new[]
                {
                    new SqlParameter("APN", APNNumber)
                };

                var ds = await _storedProcedureExecutor.ExecuteStoredProcedureWithDataSetAsync(StoredProcedureNames.SP_uspGetSiteAddressByAPN,parameters);



                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        APNSearch.APNSearchSiteAddresslst = ConvertToList<APNSearchSiteAddress>(ds.Tables[0]);
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        APNSearch.APNSearchProjectInfolst = ConvertToList<APNSearchProjectInfo>(ds.Tables[1]);
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {

                        APNSearch.ApnExists = Convert.ToBoolean(ds.Tables[2].Rows[0][0]);
                    }
                }
               
             
                if (APNSearch != null)
                {
                    // Return the first list from the result.
                    return APNSearch;
                }

                // Return an empty list if no results are found.
                return new APNSearch();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Return an empty list in case of an exception.
                return new APNSearch();
            }
        }


        private static List<T> ConvertToList<T>(DataTable table) where T : new()
        {
            var list = new List<T>();

            if (table == null || table.Rows.Count == 0)
                return list;

            var properties = typeof(T).GetProperties();

            foreach (DataRow row in table.Rows)
            {
                T obj = new T();
                foreach (var prop in properties)
                {
                    if (table.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                    {
                        prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType));
                    }
                }
                list.Add(obj);
            }

            return list;
        }

        public async Task<(List<int> Saved, List<int> NotSaved)> SaveAssnPropContactAsync(List<string> projects, HttpContext httpContext)
        {
            var userName = UserSession.GetUserSession(httpContext).UserName;
            var savedProjects = new List<int>();
            var notSavedProjects = new List<int>();

            if (!string.IsNullOrEmpty(userName))
            {
                var contactIdentifierID = await _accountRepository.GetContactIdentifierByUserName(userName);
                var lutContactType = await _accountRepository.GetLutPropContactAssnTypes(ConstAssnPropContact.Role);

                if (contactIdentifierID != null)
                {
                    foreach (var item in projects)
                    {
                        int projectId = int.Parse(item);

                        var popContact = new AssnPropContact
                        {
                            IdentifierType = ConstAssnPropContact.Project,
                            ContactIdentifierId = contactIdentifierID.ContactIdentifierId,
                            LutContactTypeId = lutContactType.LutContactTypeId,
                            Status = ConstAssnPropContact.Status,
                            Source = ConstAssnPropContact.Source,
                            ProjectId = projectId
                        };

                        bool isSaved = await _accountRepository.AddPropContactIfNotExistsAsync(popContact, userName);

                        if (isSaved)
                            savedProjects.Add(projectId);
                        else
                            notSavedProjects.Add(projectId);
                    }
                }

            }
            return (savedProjects, notSavedProjects);
        }

        public async Task<List<VwAspNetRole>> GetUSerRole(int? ApplicationID)
        {
            var data = await _accountRepository.GetUSerRole(ApplicationID);
            return data;
        }


        public async Task<bool> CreateProject(ProjectModel projectModel,  HttpContext httpContext)
        {
            try
            {
                var userName = UserSession.GetUserSession(httpContext).UserName;
                var contactIdentifier = await _accountRepository.GetContactIdentifierByUserName(userName);
                var parameters = new[]
                {
                    new SqlParameter("APN", projectModel.APN),
                    new SqlParameter("ProjectAddress", projectModel.ProjectAddress),
                    new SqlParameter("SiteAddressID", projectModel.SiteAddressID),
                    new SqlParameter("UserName", userName),
                    new SqlParameter("ProjectName", projectModel.ProjectName),
                    new SqlParameter("PropertyName", projectModel.PropertyNameInput),
                };

                // Execute the stored procedure and get the result, which is a List of Lists.
                var result = await _storedProcedureExecutor.ExecuteStoredwithDatatableProcAsync<APNStoredProcedureResult>(
                    StoredProcedureNames.SP_uspCreateNewProjectandSite,
                    parameters
                );

                // Check if the result is not null and contains at least one list.
                if (result != null)
                {
                    List<string> projects = new List<string>();
                    projects.Add(result.ProjectID.ToString());
                    //var contactIdentifier = await _accountRepository.GetContactIdentifierByUserName(userName);
                    var (saved, notSaved) = await SaveAssnPropContact(projects, httpContext, contactIdentifier.ContactIdentifierId);
                    
                }

                // Return an empty list if no results are found.
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Return an empty list in case of an exception.
                return false;
            }
        }


        public async Task<bool> CreateProjectWithNewAPNandSite(ProjectProvisionRequest provisionModel, HttpContext httpContext)
        {
            try
            {
                var userName = UserSession.GetUserSession(httpContext).UserName;
                if (string.IsNullOrWhiteSpace(userName)) return false;

                var contactIdentifier = await _accountRepository.GetContactIdentifierByUserName(userName);

                // 1) PCMS first (fund 8 = TEMP/no association yet)
                provisionModel.UserName = userName;
                provisionModel.LutProjectFundId = 8;

                // Call PCMS for project provisioning
                var pcms = await ProvisionProjectAndSiteforPCMS(provisionModel);
                if (pcms == null || !pcms.Success) // Use the Success convenience property
                {
                    // Optionally log pcms.ErrorMessage or pcms.Status
                    return false;
                }

                SqlParameter[] parameters;
                try
                {
                    // Safely parse string IDs to integers
                    int? siteAddressID = TryParseInt(provisionModel.SiteAddressID);
                    int? refSiteAddressId = TryParseInt(pcms.RefSiteAddressId);

                    parameters = new[]
                    {
                        new SqlParameter("APN", provisionModel.APN ?? (object)DBNull.Value),
                        new SqlParameter("ProjectAddress", provisionModel.ProjectAddress ?? (object)DBNull.Value),
                        new SqlParameter("SiteAddressID", siteAddressID.HasValue ? siteAddressID.Value : (object)DBNull.Value),
                        new SqlParameter("UserName", userName),
                        new SqlParameter("ProjectName", provisionModel.ProjectName ?? (object)DBNull.Value),
                        new SqlParameter("PropertyName", provisionModel.PropertyName ?? (object)DBNull.Value),
                        new SqlParameter("RefProjectId", pcms.RefProjectId),
                        new SqlParameter("RefProjectSiteId", pcms.RefProjectSiteId),
                        new SqlParameter("RefSiteAddressId", refSiteAddressId.HasValue ? refSiteAddressId.Value : (object)DBNull.Value),
                        new SqlParameter("FileGroup", pcms.FileGroup ?? (object)DBNull.Value)
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating SQL parameters: " + ex.ToString());
                    return false; // Stop execution if parameter creation fails
                }

                // Execute the stored procedure and get the result
                var result = await _storedProcedureExecutor.ExecuteStoredwithDatatableProcAsync<APNStoredProcedureResult>(
                    StoredProcedureNames.SP_uspCreateNewProjectandSite,
                    parameters
                );


                // Check if the result is not null and contains at least one list. Then save link relationship
                if (result != null)
                {
                    List<string> projects = new List<string>();
                    projects.Add(result.ProjectID.ToString());
                    //var contactIdentifier = await _accountRepository.GetContactIdentifierByUserName(userName);
                    var (saved, notSaved) = await SaveAssnPropContact(projects, httpContext, contactIdentifier.ContactIdentifierId);

                }


                if (result == null || result.Success != 1)
                {
                    // Log error from the AAHR stored procedure
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<(List<int> Saved, List<int> NotSaved)> SaveAssnPropContact(List<string> projects, HttpContext httpContext, int contactIdentifierID )
        {
            var userName = UserSession.GetUserSession(httpContext).UserName;
            var savedProjects = new List<int>();
            var notSavedProjects = new List<int>();

            if (!string.IsNullOrEmpty(userName))
            {
                
                var lutContactType = await _accountRepository.GetLutPropContactAssnTypes(ConstAssnPropContact.Role);

                if (contactIdentifierID != null)
                {
                    foreach (var item in projects)
                    {
                        int projectId = int.Parse(item);

                        var popContact = new AssnPropContact
                        {
                            IdentifierType = ConstAssnPropContact.Project,
                            ContactIdentifierId = contactIdentifierID,
                            LutContactTypeId = lutContactType.LutContactTypeId,
                            Status = ConstAssnPropContact.Status,
                            Source = ConstAssnPropContact.Source,
                            ProjectId = projectId
                        };

                        bool isSaved = await _accountRepository.AddPropContactIfNotExistsAsync(popContact, userName);

                        if (isSaved)
                            savedProjects.Add(projectId);
                        else
                            notSavedProjects.Add(projectId);
                    }
                }

            }
            return (savedProjects, notSavedProjects);
        }

        public async Task<ProjectProvision> ProvisionProjectAndSiteforPCMS(ProjectProvisionRequest request, CancellationToken ct = default)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_config["AreaMgmtAPIURL:PropertyApiURL"]),
                Timeout = TimeSpan.FromSeconds(60)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Convert string IDs → int? for API
            int? refSiteAddressId = TryParseInt(request.RefSiteAddressId)
                                    ?? TryParseInt(request.SiteAddressID);

            // Build payload the PCMS API expects (AddressText/ZipCode)
            var payload = new
            {
                ProjectName = Cap(request.ProjectName, 200),
                PropertyName = Cap(request.PropertyName, 200),
                APN = Cap(request.APN, 40),
                ProjectAddress = Cap(request.ProjectAddress, 500),
                UserName = Cap(request.UserName, 100),
                LutProjectFundId = request.LutProjectFundId,
                RefSiteAddressId = refSiteAddressId,               // int? or null
                HouseNum = Cap(request.HouseNum, 10),
                HouseFracNum = Cap(request.HouseFracNum, 10),
                PreDirCd = Cap(request.PreDirCd, 2),
                StreetName = Cap(request.StreetName, 100),
                StreetTypeCd = Cap(request.StreetTypeCd, 10),
                PostDirCd = Cap(request.PostDirCd, 2),
                City = Cap(request.City, 100),
                ZipCode = Cap(request.Zip, 10)            // API uses ZipCode
            };

            var body = JsonConvert.SerializeObject(payload);
            using var content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await client.PostAsync("AcHP/ProvisionProjectAndSite", content, ct).ConfigureAwait(false);
            }
            catch (TaskCanceledException ex)
            {
                return new ProjectProvision { Status = ProvisionStatus.RetryableError, ErrorMessage = "Timed out or canceled: " + ex.Message };
            }
            catch (HttpRequestException ex)
            {
                return new ProjectProvision { Status = ProvisionStatus.UnknownError, ErrorMessage = "HTTP error: " + ex.Message };
            }

            var json = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return new ProjectProvision
                {
                    Status = ProvisionStatus.SqlError,
                    ErrorCode = ((int)httpResponse.StatusCode).ToString(),
                    ErrorMessage = string.IsNullOrWhiteSpace(json) ? "PCMS API failed." : json
                };
            }

            // Prefer strongly-typed BaseResponse<ProjectProvision>
            try
            {
                var loose = JsonConvert.DeserializeObject<BaseResponse>(json);
                if (loose == null || loose.Response == null)
                {
                    return new ProjectProvision
                    {
                        Status = ProvisionStatus.UnknownError,
                        ErrorMessage = "Empty BaseResponse."
                    };
                }

                // Response may be a JToken/JObject or a raw string
                ProjectProvision prov = null;
                var token = loose.Response as JToken;
                if (token != null)
                {
                    prov = token.ToObject<ProjectProvision>();
                }
                else
                {
                    var respString = loose.Response.ToString();
                    prov = JsonConvert.DeserializeObject<ProjectProvision>(respString);
                }

                return prov ?? new ProjectProvision
                {
                    Status = ProvisionStatus.UnknownError,
                    ErrorMessage = "Unable to parse provisioning result."
                };
            }
            catch (Exception ex2)
            {
                return new ProjectProvision
                {
                    Status = ProvisionStatus.UnknownError,
                    ErrorMessage = "Parsing error: " + ex2.Message
                };
            }
        }

        // helpers
        private static int? TryParseInt(string s) { int v; return int.TryParse(s, out v) ? (int?)v : null; }
        private static string Cap(string s, int max)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            s = s.Trim();
            return s.Length <= max ? s : s.Substring(0, max);
        }


    }
}


