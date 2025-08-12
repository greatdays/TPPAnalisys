
using DeveloperPortal.Domain.ProjectDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
   public interface IProjectParticipantService
    {

        /// <summary>
        /// Project Participants
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="caseId"></param>
        /// <param name="apn"></param>
        /// <returns></returns>
        Task<List<ProjectParticipantsModel>> ProjectParticipants(int projectId, int caseId, string apn);
    }
}
