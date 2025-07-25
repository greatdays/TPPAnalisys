using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        /// <summary>
        /// GetAddBuildingDetails
        /// </summary>
        /// <param name="projectSiteId"></param>
        /// <returns></returns>
        Task<BuildingModel> GetAddBuildingDetails(int projectSiteId);

        /// <summary>
        /// Save Building Summary
        /// </summary>
        /// <param name="buildingModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> SaveBuildingSummary(BuildingParkingInformationModal buildingModel, string userName);

        /// <summary>
        /// GetBuildingAddressDetails
        /// </summary>
        /// <param name="projectSiteIds"></param>
        /// <returns></returns>
        Task<List<SelectListItem>> GetBuildingAddressDetails(List<int> projectSiteIds);

        /// <summary>
        /// GetBuildingDetailForEdit
        /// </summary>
        /// <param name="projectSiteId"></param>
        /// <returns></returns>
        Task<BuildingModel> GetBuildingDetailForEdit(int projectSiteId);

    }
}
