using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Models.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using static DeveloperPortal.Domain.PropertySnapshot.Constants;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class ContactIdentifierRepository : IContactIdentifierRepository
    {

        private readonly AAHREntities _context;

        public ContactIdentifierRepository(AAHREntities context)
        {
            _context = context;
        }

        public void AddAssociationData(ContactIdentifierModel contactRenderModel, ref int projectId, ref int projectSiteId, AssnPropContact APC)
        {
            if (contactRenderModel.IdentifierType == "APN")
            {
                APC.Apn = contactRenderModel.IdentifierValue;
            }
            else if (contactRenderModel.IdentifierType == "Structure")
            {
                var StructureID = Convert.ToInt32(contactRenderModel.IdentifierValue);
                APC.StructureId = _context.Structures.FirstOrDefault(x => x.RefBuildingId == StructureID)?.StructureId;
                APC.Apn = contactRenderModel.APN;
            }
            else if (contactRenderModel.IdentifierType == "Unit")
            {
                var UnitID = Convert.ToInt32(contactRenderModel.IdentifierValue);
                APC.UnitId = _context.Units.FirstOrDefault(x => x.RefUnitId == UnitID)?.UnitId;
                APC.Apn = contactRenderModel.APN;
            }
            else if (contactRenderModel.IdentifierType == "Project")
            {
                var Project = _context.Projects.FirstOrDefault(x => x.RefProjectId == contactRenderModel.ProjectId);
                APC.ProjectId = Project?.ProjectId;
                APC.Apn = Project?.ProjectSites?.FirstOrDefault()?.PrimaryApn;
                projectId = Convert.ToInt32(Project?.ProjectId);
            }
            else if (contactRenderModel.IdentifierType == "ProjectSite")
            {
                var ProjectSite = _context.ProjectSites.FirstOrDefault(x => x.RefProjectSiteId == contactRenderModel.ProjectSiteID);
                APC.ProjectId = ProjectSite?.ProjectId;
                APC.Apn = ProjectSite?.PrimaryApn;
                APC.ProjectSiteId = ProjectSite?.ProjectSiteId;
                projectSiteId = Convert.ToInt32(ProjectSite?.ProjectSiteId);
            }

            if (contactRenderModel.IdentifierType == "Address")
            {
                int siteAddressId = Convert.ToInt32(contactRenderModel.IdentifierValue);
                SiteAddress siteAddresse = _context.SiteAddresses.FirstOrDefault(x => x.RefSiteAddressId == siteAddressId);
                if (siteAddresse != null)
                {
                    APC.IdentifierType = contactRenderModel.IdentifierType;
                    APC.Apn = siteAddresse.Apns?.FirstOrDefault()?.Apn1;
                    APC.SiteAddressId = siteAddresse.SiteAddressId;
                }
            }
        }


        /// <summary>
        /// SetOrganization
        /// </summary>
        /// <param name="contactRenderModel"></param>
        /// <returns></returns>
        public async Task<Organization> SetOrganization(ContactIdentifierModel contactRenderModel)
        {
            try
            {
                var organization = _context.Organizations.FirstOrDefault(x => x.Name == contactRenderModel.Company && x.IsDeleted == false);
                if (organization == null)
                {
                    organization = new Organization
                    {
                        Name = contactRenderModel.Company,
                        IsDeleted = false,
                        IsReviewRequired = false
                    };

                    _context.Organizations.Add(organization);
                    _context.SaveChanges(contactRenderModel.UserName);
                }

                return organization;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// SetOrganization
        /// </summary>
        /// <param name="contactRenderModel"></param>
        /// <returns></returns>
        public async Task<string> GetOrganization(int contactIdentifierId )
        {
            try
            {
                var orgName = "";
                var assOrg = _context.AssnOrganizationContacts.FirstOrDefault(x => x.ContactIdentifierId == contactIdentifierId&& x.IsDeleted == false);
                //var organization = _context.Organizations.FirstOrDefault(x => x.Name == contactRenderModel.Company && x.IsDeleted == false);
                if (assOrg != null)
                {
                 var organization =   _context.Organizations.FirstOrDefault(x => x.OrganizationId == assOrg.OrganizationId && x.IsDeleted == false);
                    if(organization != null)

                    { orgName = organization.Name; }
                    
                //    organization = new Organization
                //    {
                //        Name = contactRenderModel.Company,
                //        IsDeleted = false,
                //        IsReviewRequired = false
                //    };

                    //    _context.Organizations.Add(organization);
                    //    _context.SaveChanges(contactRenderModel.UserName);
                }

                return orgName;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// UpdateOrganizationName
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="contactRenderModel"></param>
        /// <returns></returns>
        public async Task<Organization> UpdateOrganizationName(int organizationId, ContactIdentifierModel contactRenderModel)
        {

            var organization = _context.Organizations.FirstOrDefault(x => x.OrganizationId == organizationId && x.IsDeleted == false);
            if (organization != null)
            {
                organization.Name = contactRenderModel.Company;
                _context.SaveChanges(contactRenderModel.UserName);
            }

            return organization;
        }
        /// <summary>
        /// DeleteContactOrganization
        /// </summary>
        /// <param name="contactRenderModel"></param>
        /// <param name="contactOrganization"></param>
        /// <returns></returns>
        public async Task<bool> DeleteContactOrganization(ContactIdentifierModel contactRenderModel, AssnOrganizationContact contactOrganization)
        {

            List<AssnOrganizationContact> lstOrgContact = _context.AssnOrganizationContacts.Where(o => o.IsDeleted != true && o.ContactIdentifierId == contactRenderModel.ContactIdentifierID).ToList();
            if (lstOrgContact != null)
            {
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
                }
                _context.SaveChanges(contactRenderModel.UserName);
            }
            return true;
        }

        /// <summary>
        /// SaveContact
        /// </summary>
        /// <param name="contactRenderModel"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        public bool SaveContact(ContactIdentifierModel contactRenderModel, ContactIdentifier contact)
        {
            if (contactRenderModel.ContactIdentifierID == 0)
            {
                _context.ContactIdentifiers.Add(contact);
            }
            _context.SaveChanges(contactRenderModel.UserName);
            return true;
        }
        /// <summary>
        /// ServiceRequest
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        public ServiceRequest ServiceRequest(int caseId)
        {
            return _context.ServiceRequests.FirstOrDefault(x => x.CaseId == caseId);
        }

        /// <summary>
        /// ContactIdentifier
        /// </summary>
        /// <param name="contactIdentifierId"></param>
        /// <returns></returns>
        public async Task<ContactIdentifier> ContactIdentifier(int contactIdentifierId)
        {
            return _context.ContactIdentifiers.FirstOrDefault(x => x.ContactIdentifierId == contactIdentifierId);
        }

        /// <summary>
        /// AssnPropContacts
        /// </summary>
        /// <param name="contactIdentifierId"></param>
        /// <returns></returns>
        public async Task<List<AssnPropContact>> AssnPropContacts(int contactIdentifierId)
        {
            return _context.AssnPropContacts.Where(x => x.ContactIdentifierId == contactIdentifierId).ToList();
        }


        /// <summary>
        /// AssnOrganizationContact
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>

        public async Task<AssnOrganizationContact> AssnOrganizationContact(int contactIdentifierID, string companyName)
        {
            return _context.AssnOrganizationContacts.FirstOrDefault(x => x.ContactIdentifierId == contactIdentifierID && x.IsDeleted == false);
        }

        /// <summary>
        /// RemoveAssContactAndServiceReqContact
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="popContacts"></param>
        /// <param name="contactTypes"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAssContactAndServiceReqContact(ContactIdentifier contact, List<AssnPropContact> popContacts, string[] contactTypes, string userName)
        {
            var removedPC = popContacts.Where(x => !contactTypes.Contains(x.LutContactType.ContactType)).ToList();
            var isModified = false;
            foreach (var pc in removedPC)
            {
                _context.AssnPropContacts.Remove(pc);
                popContacts.Remove(pc);
                isModified = true;
            }
            var removedSC = _context.ServiceRequestContacts.Where(x => x.ContactIdentifierId == contact.ContactIdentifierId && !contactTypes.Any(ct => ct == x.LutContactType.ContactType)).ToList();

            if (removedSC != null)
            {
                long serviceRequestID = removedSC.Count > 0 ? removedSC.FirstOrDefault().ServiceRequestId : 0;
                foreach (var sc in removedSC)
                {
                    _context.ServiceRequestContacts.Remove(sc);
                    isModified = true;
                }
            }
            if (isModified == true)
            {
                _context.SaveChanges(userName);
            }
            return true;
        }


        /// <summary>
        /// ServiceRequestContacts
        /// </summary>
        /// <param name="contactIdentifierId"></param>
        /// <param name="contactTypes"></param>
        /// <returns></returns>
        public async Task<List<ServiceRequestContact>> ServiceRequestContacts(int contactIdentifierId, string[] contactTypes)
        {
            var serviceRequestContacts = _context.ServiceRequestContacts.Where(x => x.ContactIdentifierId == contactIdentifierId && contactTypes.Any(ct => ct == x.LutContactType.ContactType)).ToList();
            return serviceRequestContacts == null ? new List<ServiceRequestContact>() : serviceRequestContacts;
        }

        /// <summary>
        /// SetPrimaryAndPublicContactDetail
        /// </summary>
        /// <param name="contactRenderModel"></param>
        /// <param name="ContactIdentifierID"></param>
        /// <param name="primaryAssociations"></param>
        /// <param name="lutPropContact"></param>
        /// <param name="projectId"></param>
        /// <param name="projectSiteId"></param>
        /// <returns></returns>
        public async Task<bool> SetPrimaryAndPublicContactDetail(ContactIdentifierModel contactRenderModel, int ContactIdentifierID, string[] primaryAssociations, List<LutContactType> lutPropContact, int projectId, int projectSiteId)
        {

            if (lutPropContact.Count() > 0 && contactRenderModel.IdentifierType == "Project")
            {
                var primaryContactAPCExcept = _context.AssnPropContacts.Where(x => x.ProjectId == projectId && primaryAssociations.Any(y => y == x.LutContactType.ContactType) && x.IsPrimaryAssnType == true && x.ContactIdentifierId != ContactIdentifierID).ToList();
                foreach (var item in primaryContactAPCExcept)
                {
                    item.IsPrimaryAssnType = false;
                }
                _context.SaveChanges(contactRenderModel.UserName);

            }
            else if (lutPropContact.Count() > 0 && contactRenderModel.IdentifierType == "ProjectSite")
            {
                var primaryContactAPCExcept = _context.AssnPropContacts.Where(x => x.ProjectSiteId == projectSiteId && primaryAssociations.Any(y => y == x.LutContactType.ContactType) && x.IsPrimaryAssnType == true && x.ContactIdentifierId != ContactIdentifierID).ToList();
                foreach (var item in primaryContactAPCExcept)
                {
                    item.IsPrimaryAssnType = false;
                }
                _context.SaveChanges(contactRenderModel.UserName);
            }

            if (contactRenderModel.IsContactPublic == true)
            {
                var contactToPublicList = _context.AssnPropContacts.Where(x => x.Apn == contactRenderModel.APN && x.IsDeleted == false && x.IsContactPublic == true && x.ContactIdentifierId != ContactIdentifierID).ToList();
                if (contactToPublicList != null)
                {
                    foreach (var item in contactToPublicList)
                    {
                        item.IsContactPublic = false;
                    }
                    _context.SaveChanges(contactRenderModel.UserName);
                }
            }
            return true;
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
            bool isDeleted = false;
            var contact = _context.ContactIdentifiers.FirstOrDefault(x => x.ContactIdentifierId == contactIdentifierId && x.IsDeleted == false);
            if (contact != null)
            {
                contact.IsDeleted = true;
                contact.IsPrimary = false;
                var project = _context.Projects.FirstOrDefault(x => x.RefProjectId == refProjectId && x.IsDeleted == false);
                var projectsite = _context.ProjectSites.FirstOrDefault(x => x.RefProjectSiteId == refProjectSiteId && x.IsDeleted == false);
                if (refProjectId != 0 && refProjectSiteId != 0)
                {
                    _context.AssnPropContacts.Where(x => x.ContactIdentifierId == contactIdentifierId && x.ProjectId == project.ProjectId && x.ProjectSiteId == projectsite.ProjectSiteId && x.IsDeleted == false).ToList().ForEach(x => { x.IsDeleted = true; x.IsPrimaryAssnType = false; x.IsPrimaryContact = false; x.IsContactPublic = false; });
                }
                else if (refProjectId != 0)
                {
                    _context.AssnPropContacts.Where(x => x.ContactIdentifierId == contactIdentifierId && x.ProjectId == project.ProjectId && x.IsDeleted == false).ToList().ForEach(x => { x.IsDeleted = true; x.IsPrimaryAssnType = false; x.IsPrimaryContact = false; x.IsContactPublic = false; });

                }
                else if (refProjectSiteId != 0)
                {
                    _context.AssnPropContacts.Where(x => x.ContactIdentifierId == contactIdentifierId && x.ProjectSiteId == projectsite.ProjectSiteId && x.IsDeleted == false && x.IdentifierType == "ProjectSite").ToList().ForEach(x => { x.IsDeleted = true; x.IsPrimaryAssnType = false; x.IsPrimaryContact = false; x.IsContactPublic = false; });
                }
                else
                {
                    _context.AssnPropContacts.Where(x => x.ContactIdentifierId == contactIdentifierId).ToList().ForEach(x => { x.IsDeleted = true; x.IsPrimaryAssnType = false; x.IsPrimaryContact = false; x.IsContactPublic = false; });
                }

                isDeleted = _context.SaveChanges(userName) > 0;
            }
            return isDeleted;
        }
    }
}
