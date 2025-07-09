using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.ProjectDetail;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IProjectDetailRepository
    {

        /// <summary>
        /// UpdateStructureAttributesAsync
        /// </summary>
        /// <param name="structureAttribute"></param>
        /// <returns></returns>
        Task<StructureAttribute> UpdateStructureAttributesAsync(StructureAttribute structureAttribute);


        /// <summary>
        /// SaveBuildingSummary
        /// </summary>
        /// <param name="buildingModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> SaveBuildingSummary(BuildingParkingInformationModal buildingModel, string userName);

        bool UpdateUnitDetails(UnitDataModel unitModel, string userName);
    }
}
