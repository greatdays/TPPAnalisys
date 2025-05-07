using DeveloperPortal.DataAccess.Entity.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity.Models.StoredProcedureModels
{
    
    public class uspGetUnitsForComplianceMetrix
    {
        //APNId SiteAddressID   ProjectSiteId ProjectId   LevelId BuildingId  CaseId ServiceRequestId    PropSnapshotID ACHPNo  UnitID UnitNum TotalBedroom LutTotalBedroomID   FloorPlanType FloorPlanTypeID UnitType LutUnitTypeID   ManagersUnit IsCSA   IsVCA AdditionalAccecibility  IsCompliant
        public int? APNId { get; set; }
        public int? SiteAddressID { get; set; }
        public int? ProjectSiteId { get; set; }
        public int? ProjectId { get; set; }
        public int? LevelId { get; set; }
        public int? BuildingId { get; set; }
        public int CaseId { get; set; }
        public long? ServiceRequestId { get; set; }
        public int? PropSnapshotID { get; set; }
        public string? ACHPNo { get; set; }
        public int? UnitID { get; set; }
        public string? UnitNum { get; set; }
        public int? LutTotalBedroomID { get; set; }
        public string? TotalBedroom { get; set; } = string.Empty;
        public string? FloorPlanType { get; set; }
        public int? FloorPlanTypeID { get; set; }
        public string? UnitType { get; set; }
        public int? LutUnitTypeID { get; set; }
        public bool? ManagersUnit { get; set; }
        public bool? IsCSA { get; set; }
        public bool? IsVCA { get; set; }
        public string? AdditionalAccecibility { get; set; }
        public bool? IsCompliant { get; set; }
       
    }
}
