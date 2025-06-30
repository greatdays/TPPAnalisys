using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SurveyReport
{
    public int SurveyReportId { get; set; }

    public long? ServiceRequestId { get; set; }

    public DateTime? ReportDate { get; set; }

    public string? ResidentialBuildingType { get; set; }

    public int? TotalDwellingUnits { get; set; }

    public DateTime? ReformedAndFinalDate { get; set; }

    public string? ParkingRequired { get; set; }

    public DateTime? DbsdateSubmitToLa { get; set; }

    public DateTime? DbsdatePermitIssued { get; set; }

    public DateTime? DbspermitFinalledDate { get; set; }

    public DateTime? DbscertificateOccupancyDate { get; set; }

    public string? DbsrequiresFhainspection { get; set; }

    public DateTime? NacinspectionDate { get; set; }

    public int? NacrecomForProjectSite { get; set; }

    public int? NacestAccessRetrofitUnit { get; set; }

    public int? NacestAccessRetrofitComAreas { get; set; }

    public int? NacestAccessRetrofit { get; set; }

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

    public decimal? Ucf4perReqByAgreement { get; set; }

    public string? Ucfexisting { get; set; }

    public string? Ucfrecommended { get; set; }

    public int? Ucf00studioUnits { get; set; }

    public int? Ucf0efficiencyUnits { get; set; }

    public int? Ucf01bedroomUnits { get; set; }

    public int? Ucf02bedroomUnits { get; set; }

    public int? Ucf03bedroomUnits { get; set; }

    public int? Ucf04bedroomUnits { get; set; }

    public int? Ucf05bedroomUnits { get; set; }

    public int? UcfmgrUnitTypeNotVerfied { get; set; }

    public int? UcftotalNoOfUnits { get; set; }

    public int? Srounits { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
