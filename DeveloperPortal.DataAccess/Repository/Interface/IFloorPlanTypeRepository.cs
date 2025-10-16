using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.ProjectDetail;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IFloorPlanTypeRepository
    {
        Task<List<LutTotalBedroom>> GetLutTotalBedrooms();
        Task<List<LutTotalBathroom>> GetLutTotalBathrooms();
        Task<List<LutBathroomType>> GetLutBathroomType();
        Task<List<LutBathroomTypeOption>> GetLutBathroomTypeOption();
        int GetPropSnapShots(int ProjectID);
        int SaveFloorPlanType(FloorPlanType floorPlans);
        int AddFloorPlanBathroomTypeAsync(FloorPlanBathroomType bathroomType);
        List<FloorPlanTypeModel> GetFloorPlanInformation(int ProjectID);
        List<LutBathroomTypeOption> GetLutBathroomTypeOptionbyFLoorPlanTypeID();
        FloorPlanType GetFloorPlanTypeByID(int floorPlanTypeID);
        List<Document> GetFloorPlanFilesByID(string floorPlanTypeID);
        
        List<FloorPlanBathroomType> GetFloorPlanBathroomTypeByFloorPlanID(int floorPlanID);
        ProjectSite GetProjectSiteIDByFloorPlanID(int ProjectSiteID);
        int UpdateFloorPlanType(FloorPlanTypeModel floorPlanTypeModel);
        int RemoveFloorPlanBathroomType(FloorPlanBathroomType floorPlanBathroomType);
        List<UnitAttribute> GetUnitAttributesbyFloorPlanID(int floorPlanTypeID);
        List<UnitBathroomType> GetUnitBathroomTypebyUnitAttributeID(int unitAttributeId);
        int RemoveUnitPlanBathroomType(UnitBathroomType unitBathroomType);
        int AddUnitPlanBathroomTypeAsync(UnitBathroomType bathroomType);
        List<LutBathroomType> GetLutBathroomTypeEdit();
        List<LutBathroomTypeOption> GetLutBathroomTypeOptionEdit();
        int UpdateUnitAttribute(UnitAttribute unit);
        List<string> DeleteFloorPlanType(FloorPlanType floorPlanType);
        bool DeleteFloorPlanFile(int docId,string username);
        List<FloorPlanInformation> GetFloorPlanInformationCompliance(int caseId);
        public int? getLuDocumentCategoryId(string category, string subCategory);
        public void SaveFloorPlanFile(List<Document> doclist, FloorPlanTypeModel floorPlan);
    }
}
