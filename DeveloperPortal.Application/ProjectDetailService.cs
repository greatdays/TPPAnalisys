using DeveloperPortal.DataAccess.Entity.Data;

//using DeveloperPortal.Domain.Models;

namespace DeveloperPortal.Application
{
    public class ProjectDetailService
    {
        public void GetProjectParticipantsByProjectId(string ProjectId)
        {
            AAHREntities context = new AAHREntities();
            int projId = 0;
            int.TryParse(ProjectId, out projId);
           // var projectParticipants = context.GetProjectParticipantsByProjectId(projId);
            //List<DataAccess.Entity.Models.StoredProcedureModels.ProjectParticipantsModel> proj = projectParticipants.Result;
        }
       
    }
}
