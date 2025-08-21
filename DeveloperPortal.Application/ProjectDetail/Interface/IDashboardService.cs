using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Models;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.Dashboard;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IDashboardService
    {
        

        Task<List<DashboardDataModel>> GetAllConstructionCases();

         Task<List<DashboardDataModel>> GetAllConstructionCasesForUser();

        Task<List<AllConstructionData>> GetAllConstructionCasesData();

        Task<List<DashboardDataModel>> GetAllConstructionCasesForUserByUserID(String UserID);
 



    }
}
