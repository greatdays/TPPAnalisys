using DeveloperPortal.Domain.ProjectDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public interface IBuildingIntakeService
    {
        /// <summary>
        /// SaveAddBuilding
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> SaveAddBuilding(BuildingModel model);
    }
}
