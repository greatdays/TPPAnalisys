using DeveloperPortal.Domain.ProjectDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IDevelopmentTeamService
    {
        /// <summary>
        /// Project Participants
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="caseId"></param>
        /// <param name="apn"></param>
        /// <returns></returns>
        Task<List<DevelopmentTeamModel>> DevelopmentTeamList(int projectId, int caseId, string apn);


        /// <summary>
        /// GetContactDetail
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        Task<ContactRenderModel> GetContactDetail(int contactId);


        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>

        Task<bool> DeleteContact(int contactId, int contactIdentifierId, string userName, int refProjectId = 0, int refProjectSiteId = 0);

        /// <summary>
        /// SaveContact
        /// </summary>
        /// <param name="renderModel"></param>
        /// <returns></returns>
        Task<bool> SaveContact(ContactRenderModel renderModel);
    }

}
