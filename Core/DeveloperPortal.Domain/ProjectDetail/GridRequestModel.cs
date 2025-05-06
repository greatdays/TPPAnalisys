//using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.Domain.ProjectDetail
{
    public class GridRequestModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int CaseId { get; set; }
        public int ProjectId { get; set; }
        public List<SortModel> Sort { get; set; }
        public List<UnitDataModel> UnitGridData { get; set; }
    }

    public class SortModel
    {
        public string Field { get; set; }
        public string Dir { get; set; }
    }
    public class UnitBuildingModel
    {
        public int BuildingId { get; set; }
        public int CaseId { get; set; }
        public string ACHPNo { get; set; }
    }
    public class TotalUnitDataModel
    {

        public int SROCount { get; set; }
        public int StudioCount { get; set; }
        public int EfficiencyCount { get; set; }
        public int Bedroom1Count { get; set; }
        public int Bedroom2Count { get; set; }
        public int Bedroom3Count { get; set; }
        public int Bedroom4Count { get; set; }
        public int Bedroom5Count { get; set; }
        public int ManagerUnitCount { get; set; }
        public int TotalCount { get; set; }

        public int UnitDesignatedCSACount { get; set; }
        public int UnitDesignatedVCACount { get; set; }
        public int TotalMobilityUntCount { get; set; }
        public int TotalCommunicationUntCount { get; set; }
        public int TotalAdaptableUntCount { get; set; }
        public double TotalMobilityUnitsPer { get; set; }
        public double TotalCommunicationsPer { get; set; }
        public double TotalCommunicationCount { get; set; }
        public double TotalMobilityUnitsVCAPer { get; set; }
        public int TotalMobilityUnitsVCACount { get; set; }
        public double TotalMobilityUnitsCSAPer { get; set; }
        public int TotalMobilityUnitsCSACount { get; set; }
    }
    
    public class UnitDataModel
    {
        //APNId SiteAddressID   ProjectSiteId ProjectId   LevelId BuildingId  CaseId ServiceRequestId    PropSnapshotID ACHPNo  UnitID UnitNum TotalBedroom LutTotalBedroomID   FloorPlanType FloorPlanTypeID UnitType LutUnitTypeID   ManagersUnit IsCSA   IsVCA AdditionalAccecibility  IsCompliant
        public int? UnitID { get; set; }
        public string UnitNum { get; set; }
        public string ACHPNo { get; set; }
        public bool? ManagersUnit { get; set; }
        public string UnitType { get; set; }
        public int? LutUnitTypeID { get; set; }
        public string FloorPlanType { get; set; }
        public int? FloorPlanTypeID { get; set; }
        public string? UnitDesignation { get; set; }
        public string AdditionalAccecibility { get; set; }
        public bool IsCompliant { get; set; }
        public bool IsCSA { get; set; }
        public bool IsVCA { get; set; }
        public int PropSnapshotID { get; set; }
        public int BuildingId { get; set; }
        public int CaseId { get; set; }
        public int? SiteAddressID { get; set; }
        public long? ServiceRequestId { get; set; }
        public int? APNId { get; set; }
        public int? ProjectSiteId { get; set; }
        public int? ProjectId { get; set; }
        public string? UnitNumber { get; set; }
        public int? LevelId { get; set; }
        public int? LutTotalBedroomID { get; set; }
        public string TotalBedroom { get; set; } = string.Empty;
    }
}
