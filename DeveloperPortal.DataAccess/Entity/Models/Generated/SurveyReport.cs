using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SurveyReport
{
    public int SurveyReportID { get; set; }

    public long? ServiceRequestID { get; set; }

    public DateTime? ReportDate { get; set; }

    public string? ResidentialBuildingType { get; set; }

    public int? TotalDwellingUnits { get; set; }

    public DateTime? ReformedAndFinalDate { get; set; }

    public string? ParkingRequired { get; set; }

    public DateTime? DBSDateSubmitToLA { get; set; }

    public DateTime? DBSDatePermitIssued { get; set; }

    public DateTime? DBSPermitFinalledDate { get; set; }

    public DateTime? DBSCertificateOccupancyDate { get; set; }

    public string? DBSRequiresFHAInspection { get; set; }

    public DateTime? NACInspectionDate { get; set; }

    public int? NACRecomForProjectSite { get; set; }

    public int? NACEstAccessRetrofitUnit { get; set; }

    public int? NACEstAccessRetrofitComAreas { get; set; }

    public int? NACEstAccessRetrofit { get; set; }

    public decimal? PrevailWageMaterialCostPlus30per { get; set; }

    public decimal? PlanCheckPermitCost { get; set; }

    public decimal? TotalCostForRetrofit { get; set; }

    public int? UnitsInDevOccupiedbyDisablePerson { get; set; }

    public string? Comments { get; set; }

    public decimal? Mob10perReqByAgreement { get; set; }

    public string? MobExisting { get; set; }

    public string? MobRecommend { get; set; }

    public int? Mob00StudioUnits { get; set; }

    public int? Mob0EfficiencyUnits { get; set; }

    public int? Mob01BedroomUnits { get; set; }

    public int? Mob02BedroomUnits { get; set; }

    public int? Mob03BedroomUnits { get; set; }

    public int? Mob04BedroomUnits { get; set; }

    public int? Mob05BedroomUnits { get; set; }

    public int? MobTotalNoOfUnits { get; set; }

    public int? Comm00StudioUnits { get; set; }

    public int? Comm0EfficiencyUnits { get; set; }

    public int? Comm01BedroomUnits { get; set; }

    public int? Comm02BedroomUnits { get; set; }

    public int? Comm03BedroomUnits { get; set; }

    public int? Comm04BedroomUnits { get; set; }

    public int? Comm05BedroomUnits { get; set; }

    public int? CommTotalNoOfUnits { get; set; }

    public int? CommUnitDesignated { get; set; }

    public decimal? UCF4perReqByAgreement { get; set; }

    public string? UCFExisting { get; set; }

    public string? UCFRecommended { get; set; }

    public int? UCF00StudioUnits { get; set; }

    public int? UCF0EfficiencyUnits { get; set; }

    public int? UCF01BedroomUnits { get; set; }

    public int? UCF02BedroomUnits { get; set; }

    public int? UCF03BedroomUnits { get; set; }

    public int? UCF04BedroomUnits { get; set; }

    public int? UCF05BedroomUnits { get; set; }

    public int? UCFMgrUnitTypeNotVerfied { get; set; }

    public int? UCFTotalNoOfUnits { get; set; }

    public int? SROUnits { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
