using DeveloperPortal.Domain.PropertySnapshot;
using DeveloperPortal.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IContactIdentifiersService
    {
        /// <summary>
        /// Save Contact
        /// </summary>
        /// <param name="contactIdentifierMdl"></param>
        /// <returns></returns>
        Task<int> SaveContact(ContactIdentifierModel contactRenderModel);

        /// <summary>
        /// GetServiceRequestByCaseId
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        Task<ServiceRequestModel> GetServiceRequestByCaseId(int caseId);

        /// <summary>
        /// ContactIdentifier
        /// </summary>
        /// <param name="contactIdentifierId"></param>
        /// <returns></returns>
        Task<Domain.ProjectDetail.ContactRenderModel> ContactIdentifier(int contactIdentifierId, int assnPropContactId);

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
