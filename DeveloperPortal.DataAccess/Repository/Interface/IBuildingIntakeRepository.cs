using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.ProjectDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IBuildingIntakeRepository
    {
        /// <summary>
        /// ServiceRequest
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        Task<ServiceRequest?> ServiceRequest(int caseId);

        /// <summary>
        /// SaveStructureAsync
        /// </summary>
        /// <returns></returns>
                   
        Task<int> SaveStructureAsync(Structure structure);

        /// <summary>
        /// SaveSiteAddressAsync
        /// </summary>
        /// <param name="siteAddress"></param>
        /// <returns></returns>
        Task<int> SaveSiteAddressAsync(SiteAddress siteAddress);

        /// <summary>
        /// SaveChangesAsync
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// SaveBuildingSummary
        /// </summary>
        /// <param name="buildingModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> SaveBuildingSummary(BuildingParkingInformationModal buildingModel, string userName);

        /// <summary>
        /// SetBuildingModelData
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task SetBuildingModelData(BuildingModel model);


        /// <summary>
        /// PropSnapshots
        /// </summary>
        /// <param name="projectSiteId"></param>
        /// <returns></returns>
        Task<PropSnapshot?> PropSnapshots(int projectSiteId);


        /// <summary>
        /// StructureAttribute
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
        Task<StructureAttribute?> StructureAttribute(int propSnapshotId);

        Task<StructureAttribute> UpdateStructureAttributesAsync(StructureAttribute structureAttribute);
    }
}
