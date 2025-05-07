using DeveloperPortal.DataAccess;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Entity.Models.StoredProcedureModels;
using DeveloperPortal.DataAccess.Entity.ViewModel;

//using DeveloperPortal.Domain.Models;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application
{
    public class ProjectDetailService
    {
        public void GetProjectParticipantsByProjectId(string projectId)
        {
            AAHREntities context = new AAHREntities();
            int projId = 0;
            int.TryParse(projectId, out projId);
            var projectParticipants = context.GetProjectParticipantsByProjectId(projId);
            List<DataAccess.Entity.Models.StoredProcedureModels.ProjectParticipantsModel> proj = projectParticipants.Result;
        }
       
    }
}
