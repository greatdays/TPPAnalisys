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
        /// StructureAttribute
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
         Task<StructureAttribute?> StructureAttribute(int propSnapshotId);

        /// <summary>
        /// UpdateStructureAttributesAsync
        /// </summary>
        /// <param name="structureAttribute"></param>
        /// <returns></returns>
        Task<StructureAttribute> UpdateStructureAttributesAsync(StructureAttribute structureAttribute);

        /// <summary>
        /// UpdateUnitDetails
        /// </summary>
        /// <param name="unitModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool UpdateUnitDetails(UnitDataModel unitModel, string userName);
    }
}
