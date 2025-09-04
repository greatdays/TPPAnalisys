using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.ProjectDetail;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IFloorPlanTypeService
    {
        Task<FloorPlanTypeModel> GetFloorPlanTypes(int siteId, int projectId);
        Task<List<LutTotalBedrooms>> GetLutTotalBedrooms();
        Task<List<LutTotalBathrooms>> GetLutTotalBathrooms();
        Task<List<LutBathroomTypes>> GetLutBathroomType();
        Task<List<LutTotalBathroomTypeOption>> GetLutBathroomTypeOption();
        Task<int> AddFloorPlanTypeComplianceMatrix(FloorPlanTypeModel floorPanTypeModel);
        List<FloorPlanTypeModel> GetFloorPlanInformation(int ProjectID);
        Task<FloorPlanTypeModel> FetchFloorPlanById(int floorplanId);
        bool EditFloorPlanType(FloorPlanTypeModel floorPlanTypeModel);
        bool DeleteFloorPlantype(int floorPlanId, string userName);

    }
}
