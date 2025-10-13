using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IContactIdentifierRepository
    {
        /// <summary>
        /// AddAssociationData
        /// </summary>
        /// <param name="contactRenderModel"></param>
        /// <param name="projectId"></param>
        /// <param name="projectSiteId"></param>
        /// <param name="APC"></param>
        void AddAssociationData(ContactIdentifierModel contactRenderModel, ref int projectId, ref int projectSiteId, AssnPropContact APC);

        /// <summary>
        /// SetOrganization
        /// </summary>
        /// <param name="contactRenderModel"></param>
        /// <returns></returns>
        Task<Organization> SetOrganization(ContactIdentifierModel contactRenderModel);

        /// <summary>
        /// SetOrganization
        /// </summary>
        /// <param name="contactIdentifierId"></param>
        /// <returns></returns>
        Task<string> GetOrganization(int contactIdentifierId);

        /// <summary>
        /// UpdateOrganizationName
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="contactRenderModel"></param>
        /// <returns></returns>
        Task<Organization> UpdateOrganizationName(int organizationId, ContactIdentifierModel contactRenderModel);

        /// <summary>
        /// DeleteContactOrganization
        /// </summary>
        /// <param name="contactRenderModel"></param>
        /// <param name="contactOrganization"></param>
        /// <returns></returns>
        Task<bool> DeleteContactOrganization(ContactIdentifierModel contactRenderModel, AssnOrganizationContact contactOrganization);


        /// <summary>
        /// SaveContact
        /// </summary>
        /// <param name="contactRenderModel"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        bool SaveContact(ContactIdentifierModel contactRenderModel, ContactIdentifier contact);

        /// <summary>
        /// ServiceRequest
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        ServiceRequest ServiceRequest(int caseId);

        /// <summary>
        /// ContactIdentifier
        /// </summary>
        /// <param name="contactIdentifierId"></param>
        /// <returns></returns>
        public Task<ContactIdentifier> ContactIdentifier(int contactIdentifierId);

        /// <summary>
        /// AssnPropContacts
        /// </summary>
        /// <param name="contactIdentifierId"></param>
        /// <returns></returns>
        Task<List<AssnPropContact>> AssnPropContacts(int contactIdentifierId);

        /// <summary>
        /// AssnOrganizationContact
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>

        Task<AssnOrganizationContact> AssnOrganizationContact(int contactIdentifierID, string companyName);


        /// <summary>
        /// RemoveAssContactAndServiceReqContact
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="popContacts"></param>
        /// <param name="contactTypes"></param>
        /// <returns></returns>
        Task<bool> RemoveAssContactAndServiceReqContact(ContactIdentifier contact, List<AssnPropContact> popContacts, List<LutContactType> contactTypes, string userName);

        /// <summary>
        /// ServiceRequestContacts
        /// </summary>
        /// <param name="contactIdentifierId"></param>
        /// <param name="contactTypes"></param>
        /// <returns></returns>
        Task<List<ServiceRequestContact>> ServiceRequestContacts(int contactIdentifierId, string[] contactTypes);

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
        Task<bool> SetPrimaryAndPublicContactDetail(ContactIdentifierModel contactRenderModel, int ContactIdentifierID, string[] primaryAssociations, List<LutContactType> lutPropContact, int projectId, int projectSiteId);

        /// <summary>
        /// DeleteContact
        /// </summary>
        /// <param name="contactIdentifierId"></param>
        /// <param name="userName"></param>
        /// <param name="refProjectId"></param>
        /// <param name="refProjectSiteId"></param>
        /// <returns></returns>
        Task<bool> DeleteContact(int contactIdentifierId, string userName, int refProjectId = 0, int refProjectSiteId = 0);
    }

}
