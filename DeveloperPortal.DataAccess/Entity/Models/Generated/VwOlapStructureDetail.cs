using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapStructureDetail
{
    public int? ProjectSiteId { get; set; }

    public string? PropertyName { get; set; }

    public string? StructureNo { get; set; }

    public int StructurePropSnapShotId { get; set; }

    public int StructureId { get; set; }

    public DateOnly? DateOf1stBuildingPermit { get; set; }

    public DateOnly? DateOmostRecentBuildingPermit { get; set; }

    public DateOnly? DateOfCurrentBuildingPermitNumber { get; set; }

    public DateTime? DateOf1stPlanCheckSubmissionForConversionToResidential { get; set; }

    public DateTime? DateOf1stBuildingPermitForConversionToResidential { get; set; }

    public string? FirstPlanCheckSubmissionForConversionToResidential { get; set; }

    public DateTime? DateOf1stCoFoforConversionToResidential { get; set; }

    public DateOnly? DateOf1stTco { get; set; }

    public string Elevator { get; set; } = null!;

    public int? TotalUnit { get; set; }

    public int? SrounitCnt { get; set; }

    public int? StudioUnitCnt { get; set; }

    public int? OneBrunitCnt { get; set; }

    public int? TwoBrunitCnt { get; set; }

    public int? ThreeBrunitCnt { get; set; }

    public int? FourBrunitCnt { get; set; }

    public string? BuildingFileNumber { get; set; }

    public string? FullAddress { get; set; }

    public int? EfficiencyUnitCnt { get; set; }

    public int? FivePlusBrunitCnt { get; set; }

    public bool? RecommendedForCertification { get; set; }

    public string? _074StartDateOfSurvey { get; set; }

    public string? _074020EndDateOfSurvey { get; set; }

    public string? _846000EstimatedTotalRemovalCost { get; set; }

    public int? _847000Region { get; set; }

    public string? _848000Facility { get; set; }

    public string? _849000AddressFromEta { get; set; }

    public string? _850000SurveyStandards { get; set; }

    public string? _851000SitePlanDrawingNumber { get; set; }
}
