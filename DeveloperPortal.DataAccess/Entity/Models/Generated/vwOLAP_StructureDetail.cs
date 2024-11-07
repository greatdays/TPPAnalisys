using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_StructureDetail
{
    public int? ProjectSiteID { get; set; }

    public string? PropertyName { get; set; }

    public string? StructureNo { get; set; }

    public int StructurePropSnapShotID { get; set; }

    public int StructureID { get; set; }

    public DateOnly? DateOf1stBuildingPermit { get; set; }

    public DateOnly? DateOMostRecentBuildingPermit { get; set; }

    public DateOnly? DateOfCurrentBuildingPermitNumber { get; set; }

    public DateTime? DateOf1stPlanCheckSubmissionForConversionToResidential { get; set; }

    public DateTime? DateOf1stBuildingPermitForConversionToResidential { get; set; }

    public string? FirstPlanCheckSubmissionForConversionToResidential { get; set; }

    public DateTime? DateOf1stCoFOForConversionToResidential { get; set; }

    public DateOnly? DateOf1stTCO { get; set; }

    public string Elevator { get; set; } = null!;

    public int? TotalUnit { get; set; }

    public int? SROUnitCnt { get; set; }

    public int? StudioUnitCnt { get; set; }

    public int? OneBRUnitCnt { get; set; }

    public int? TwoBRUnitCnt { get; set; }

    public int? ThreeBRUnitCnt { get; set; }

    public int? FourBRUnitCnt { get; set; }

    public string? BuildingFileNumber { get; set; }

    public string? FullAddress { get; set; }

    public int? EfficiencyUnitCnt { get; set; }

    public int? FivePlusBRUnitCnt { get; set; }

    public bool? RecommendedForCertification { get; set; }

    public string? _074_StartDateOfSurvey { get; set; }

    public string? _074_020_EndDateOfSurvey { get; set; }

    public string? _846_000_EstimatedTotalRemovalCost { get; set; }

    public int? _847_000_Region { get; set; }

    public string? _848_000_Facility { get; set; }

    public string? _849_000_AddressFromETA { get; set; }

    public string? _850_000_SurveyStandards { get; set; }

    public string? _851_000_SitePlanDrawingNumber { get; set; }
}
