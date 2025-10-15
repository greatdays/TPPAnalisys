using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.ProjectDetail;
using HCIDLA.ServiceClient.DMS;

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
        Task<FloorPlanTypeModel> FetchFloorPlanById(int floorplanId , int caseID);
        bool EditFloorPlanType(FloorPlanTypeModel floorPlanTypeModel);
        bool DeleteFloorPlantype(int floorPlanId, string userName);
        public bool DeleteFloorPlanFile(int docId);
        List<FloorPlanInformation> GetFloorPlanInformationCompliance(int CaseID);
        public int? getLuDocumentCategoryId(string category, string subCategory);
        public void SaveFloorPlanFile(FloorPlanTypeModel floorPlan,List<UploadResponse> list, int LuDocumentCategoryId,string FloorPlanTypeID,string username);

    }
}
