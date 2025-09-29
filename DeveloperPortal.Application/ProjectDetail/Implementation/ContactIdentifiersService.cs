using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Application.PropertySnapshot;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Entity.ViewModels.ComCon;
using DeveloperPortal.DataAccess.Repository.Implementation;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.PropertySnapshot;
using DeveloperPortal.Models.Common;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;
using static DeveloperPortal.Domain.PropertySnapshot.Constants;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class ContactIdentifiersService : IContactIdentifiersService
    {

        //
        public readonly IContactIdentifierRepository _contactIdentifierRepository;
        public readonly ILutRepository _lutRepository;
        public ContactIdentifiersService(IContactIdentifierRepository contactIdentifierRepository, ILutRepository lutRepository)
        {
            _contactIdentifierRepository = contactIdentifierRepository;
            _lutRepository = lutRepository;
        }


        /// <summary>
        /// Save Contact
        /// </summary>
        /// <param name="contactIdentifierMdl"></param>
        /// <returns></returns>
        public async Task<int> SaveContact(ContactIdentifierModel contactRenderModel)
        {
            int ContactIdentifierID = 0;

            ContactIdentifier contact = new ContactIdentifier();
            AssnOrganizationContact contactOrganization = new AssnOrganizationContact();
            List<AssnPropContact> popContacts = new List<AssnPropContact>();
            if (contactRenderModel.ContactIdentifierID > 0)
            {
                ContactIdentifierID = contactRenderModel.ContactIdentifierID;
                contact = await _contactIdentifierRepository.ContactIdentifier(ContactIdentifierID);
                contactOrganization = await _contactIdentifierRepository.AssnOrganizationContact(ContactIdentifierID, contactRenderModel.Company);
                popContacts = await _contactIdentifierRepository.AssnPropContacts(ContactIdentifierID);
                if (contactOrganization == null)
                {
                    contactOrganization = new AssnOrganizationContact();
                }
            }
            //Set contcact Details
            contact.ContactId = contactRenderModel.ContactID;
            contact.FirstName = contactRenderModel.FirstName.Trim();
            contact.MiddleName = !string.IsNullOrEmpty(contactRenderModel.MiddleName) ? contactRenderModel.MiddleName.Trim() : null;
            contact.LastName = contactRenderModel.LastName.Trim();
            contact.Email = contactRenderModel.Email != null ? contactRenderModel.Email.Trim() : null;
            contact.Source = !string.IsNullOrEmpty(contactRenderModel.Source) ? contactRenderModel.Source : "Staff";
            contact.IdmuserName = contactRenderModel.IDMUserName;
            contact.IsEmployee = contactRenderModel.IsEmployee;
            contact.Title = contactRenderModel.Title;
            contact.PreferredContactMethod = contactRenderModel.PreferredContactMethod;
            contact.BirthDay = contactRenderModel.BirthDay;
            contact.BirthMonth = contactRenderModel.BirthMonth;
            contact.BirthYear = contactRenderModel.BirthYear;
            contact.IsPrimary = contactRenderModel.IsPrimary;

            //To add Contractor Type in Attribute column
            if (contactRenderModel.ContractorType == "" || contactRenderModel.ContractorType == null)
            {
                contact.Attributes = !string.IsNullOrEmpty(contactRenderModel.ContactAttribute)
                                      ? contactRenderModel.ContactAttribute
                                      : "{" + "\"In\"" + ":" + "\"Office\"" + "}";
            }
            else
            {
                contact.Attributes = !string.IsNullOrEmpty(contactRenderModel.ContactAttribute)
                                    ? contactRenderModel.ContactAttribute
                                    : "{" + "\"In\"" + ":" + "\"Office\"" + "," + "\"ContractorType\"" + ":" + "\"" + contactRenderModel.ContractorType + "\"" + " }";
            }

            #region add CASpNumber
            if (!string.IsNullOrEmpty(contactRenderModel.CASpNumber))
            {
                JObject result = JObject.Parse(contact.Attributes);

                if (result["CASp"] == null)// if property not present then add property to the json 
                {
                    result.Add(new JProperty("CASp", contactRenderModel.CASpNumber));
                }
                else
                {
                    result["CASp"] = contactRenderModel.CASpNumber;
                }

                contact.Attributes = result.ToString();
            }


            #endregion


            contact.LutPhoneTypeCd = contactRenderModel.LutPhoneTypeCd;
            contact.PhoneHome = contactRenderModel.HomePhoneNumber;
            contact.PhoneWork = contactRenderModel.BusinessPhoneNumber;
            contact.PhoneMobile = contactRenderModel.MobilePhoneNumber;
            contact.PhoneExtension = contactRenderModel.PhoneExtension?.Trim();
            contact.HouseNum = contactRenderModel.HouseNum;
            contact.HouseFracNum = contactRenderModel.HouseFracNum;
            contact.PreDirCd = contactRenderModel.PreDirCd;
            contact.StreetName = contactRenderModel.StreetName;
            contact.StreetTypeCd = contactRenderModel.StreetTypeCd;
            contact.PostDirCd = contactRenderModel.PostDirCd;
            contact.City = contactRenderModel.City;
            contact.State = contactRenderModel.State;
            contact.Zip = contactRenderModel.Zip;
            contact.UnitNo = contactRenderModel.Unit;
            contact.IsMailingAddress = contactRenderModel.IsMarkedForMailing;
            contact.Source = !string.IsNullOrEmpty(contactRenderModel.Source) ? contactRenderModel.Source : "Staff";
            contact.ContactType = contactRenderModel.ContactTypeName;

            /*If Company is blank/null then escape add/update for organisation*/
            if (!string.IsNullOrEmpty(contactRenderModel.Company))
            {
                if (contactOrganization == null || contactOrganization.OrganizationId == 0)
                {
                    var organization = await _contactIdentifierRepository.SetOrganization(contactRenderModel);
                    contactOrganization = new AssnOrganizationContact
                    {
                        OrganizationId = organization.OrganizationId,
                        AssociationType = "Full Time",
                        AssociatedFrom = DateOnly.FromDateTime(DateTime.Now.AddYears(-2)),
                        AssociatedTo = DateOnly.FromDateTime(DateTime.Now),
                        IsReviewRequired = false,
                        IsDeleted = false,
                        Source = contactRenderModel.Source
                    };
                    contact.AssnOrganizationContacts.Add(contactOrganization);
                }
                else
                {
                    _contactIdentifierRepository.UpdateOrganizationName(contactOrganization.OrganizationId, contactRenderModel);
                }
            }
            else if (contact.ContactIdentifierId > 0)
            {
                //To clean up old undeleted records.
                await _contactIdentifierRepository.DeleteContactOrganization(contactRenderModel, contactOrganization);

            }

            string[] contactTypes = !string.IsNullOrEmpty(contactRenderModel.ContactTypeName) ? contactRenderModel.ContactTypeName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : new string[0];
            string[] primaryAssociations = !string.IsNullOrEmpty(contactRenderModel.PrimaryTypes) ? contactRenderModel.PrimaryTypes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : new string[0];
            var lutPropContact = await _lutRepository.LutContactTypes(contactTypes);
            #region remove AssnPropContact ,ServiceRequestContact for edit
            if (contactRenderModel.ContactIdentifierID > 0)
            {
                await _contactIdentifierRepository.RemoveAssContactAndServiceReqContact(contact, popContacts, contactTypes, contactRenderModel.UserName);
            }

            #endregion remove AssnPropContact, ServiceRequestContact



            int projectId = 0;
            int projectSiteId = 0;
            var serviceRequestContacts = await _contactIdentifierRepository.ServiceRequestContacts(contact.ContactIdentifierId, contactTypes);
            foreach (var lpc in lutPropContact)
            {
                var APC = popContacts.FirstOrDefault(x => x.LutContactTypeId == lpc.LutContactTypeId);
                if (APC == null)
                {
                    APC = new AssnPropContact();
                    APC.IdentifierType = contactRenderModel.IdentifierType;
                }

                //Add Association
                APC.IsPrimaryAssnType = primaryAssociations.Contains(lpc.ContactType);
                APC.LutContactTypeId = lpc.LutContactTypeId;
                APC.Source = contactRenderModel.Source;
                _contactIdentifierRepository.AddAssociationData(contactRenderModel, ref projectId, ref projectSiteId, APC);
                APC.IsContactPublic = Convert.ToBoolean(contactRenderModel.IsContactPublic);

                contact.AssnPropContacts.Add(APC);

                #region ServiceRequestContact
                ServiceRequestContact serviceRequestContact = serviceRequestContacts.FirstOrDefault(m => m.ServiceRequestId == contactRenderModel.ServiceRequestID && m.LutContactTypeId == lpc.LutContactTypeId);

                if (serviceRequestContact == null && contactRenderModel.ServiceRequestID > 0)
                {
                    serviceRequestContact = new ServiceRequestContact
                    {
                        ServiceRequestId = contactRenderModel.ServiceRequestID,
                        LutContactTypeId = lpc.LutContactTypeId,
                        ContactIdentifierId = ContactIdentifierID
                    };

                    contact.ServiceRequestContacts.Add(serviceRequestContact);
                }
                #endregion ServiceRequestContact
            }

            // save contact
            _contactIdentifierRepository.SaveContact(contactRenderModel, contact);
            ContactIdentifierID = contact.ContactIdentifierId;
            // Update IsPrimaryAssnType false if selected contact and property other contacts have same ContactType with IsPrimaryAssnType true and IsContactPublic
            await _contactIdentifierRepository.SetPrimaryAndPublicContactDetail(contactRenderModel, ContactIdentifierID, primaryAssociations, lutPropContact, projectId, projectSiteId);

            return ContactIdentifierID;
        }

        /// <summary>
        /// ContactIdentifier
        /// </summary>
        /// <param name="contactIdentifierId"></param>
        /// <returns></returns>
        public async Task<Domain.ProjectDetail.ContactRenderModel> ContactIdentifier(int contactIdentifierId)
        {
            var contactIdentifier = await _contactIdentifierRepository.ContactIdentifier(contactIdentifierId);

            var contactRenderModel = new Domain.ProjectDetail.ContactRenderModel();
            if (contactIdentifier != null)
            {
                contactRenderModel = new Domain.ProjectDetail.ContactRenderModel
                {
                    ContactIdentifierID = contactIdentifier.ContactIdentifierId,
                    Type = contactIdentifier.ContactType,
                    AssociationTypes = string.IsNullOrWhiteSpace(contactIdentifier.ContactType) ? new List<string>() : contactIdentifier.ContactType.Split(",").ToList(),
                    FirstName = contactIdentifier.FirstName,
                    LastName = contactIdentifier.LastName,
                    MiddleName = contactIdentifier.MiddleName,
                    AddressLine1 = contactIdentifier.StreetName,
                    AddressLine2 = contactIdentifier.UnitNo,
                    HouseNum = contactIdentifier.HouseNum,
                    HouseFracNum = contactIdentifier.HouseFracNum,
                    StreetName = contactIdentifier.StreetName,
                    City = contactIdentifier.City,
                    State = contactIdentifier.State,
                    Zip = contactIdentifier.Zip,
                    APN = contactIdentifier.Apn,
                    PhoneHome = contactIdentifier.PhoneHome,
                    PhoneBusiness = contactIdentifier.PhoneWork,
                    PhoneExtension = contactIdentifier.PhoneExtension,
                    PhoneCell = contactIdentifier.PhoneMobile,
                    IsMarkedForMailing = contactIdentifier.IsMailingAddress,
                    Source = contactIdentifier.Source,
                    IsPrimary = contactIdentifier.IsPrimary,
                    Email = contactIdentifier.Email,
                    //IdentifierValue = renderModel.IdentifierValue,
                    //IdentifierType = renderModel.IdentifierType,
                    

                };

                if (!string.IsNullOrWhiteSpace(contactIdentifier.Attributes))
                {
                    JObject result = JObject.Parse(contactIdentifier.Attributes);
                    contactRenderModel.CASpNumber = Convert.ToString(result["CASp"]);
                    contactRenderModel.ContractorType = Convert.ToString(result["ContractorType"]);
                }

                var assnPropContactsv = await _contactIdentifierRepository.AssnPropContacts(contactIdentifierId);
                var lutPropContact = await _lutRepository.LutContactTypes(null);
                var PrimaryTypeIds = assnPropContactsv.Where(x => x.IsPrimaryAssnType == true).Select(x => x.LutContactTypeId).ToList();
                if (PrimaryTypeIds.Any())
                {
                    contactRenderModel.PrimaryTypes = string.Join(",", lutPropContact.Where(x => PrimaryTypeIds.Contains(x.LutContactTypeId)).Select(x => x.ContactType).ToList());
                }
                contactRenderModel.IsContactPublic = assnPropContactsv.Any(x => x.IsContactPublic == true);
            }
            return contactRenderModel;
        }

        /// <summary>
        /// DeleteContact
        /// </summary>
        /// <param name="contactIdentifierId"></param>
        /// <param name="userName"></param>
        /// <param name="refProjectId"></param>
        /// <param name="refProjectSiteId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteContact(int contactIdentifierId, string userName, int refProjectId = 0, int refProjectSiteId = 0)
        {

            return await _contactIdentifierRepository.DeleteContact(contactIdentifierId, userName, refProjectId, refProjectSiteId);
        }

        /// <summary>
        /// GetServiceRequestByCaseId
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        public async Task<ServiceRequestModel> GetServiceRequestByCaseId(int caseId)
        {
            ServiceRequestModel serviceRequestModel = new ServiceRequestModel();
            var sr = _contactIdentifierRepository.ServiceRequest(caseId);

            if (sr != null)
            {
                serviceRequestModel.ServiceRequestId = sr.ServiceRequestId;
                serviceRequestModel.CaseId = sr.CaseId;
                serviceRequestModel.ServiceRequestTypeId = sr.LutServiceRequestTypeId;
                serviceRequestModel.ServiceRequestNumber = sr.ServiceRequestNumber;
                serviceRequestModel.ServiceTrackingId = sr.ServiceTrackingId;
                serviceRequestModel.ProgramCycleId = sr.LutProgramCycleId;
                serviceRequestModel.ComplianceStatusId = sr.LutComplianceStatusId;
                serviceRequestModel.InspectionStatusId = sr.LutInspectionStatusId;
                serviceRequestModel.IsLocked = sr.IsLocked;
                serviceRequestModel.ServiceRequestAttributes = sr.Attributes;
            }

            return serviceRequestModel;
        }
    }
}
