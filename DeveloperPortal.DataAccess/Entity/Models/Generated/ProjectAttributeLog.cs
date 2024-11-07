using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectAttributeLog
{
    public int ProjectAttributeLogID { get; set; }

    public int? ProjectAttributeID { get; set; }

    public int? PropSnapshotID { get; set; }

    public string? ProjectName { get; set; }

    public bool? AnySeniorSite { get; set; }

    public string? AcHPAssociatedAccessorParcelNumberAPN { get; set; }

    public string? HIMSAssociatedAssessorParcelNumberAPN { get; set; }

    public bool? SharedParkingLots { get; set; }

    public string? AssignedRCS { get; set; }

    public string? Status { get; set; }

    public int? ResidentialparkingOrNumberOfUnit { get; set; }

    public bool? AssignedReidentialParking { get; set; }

    public string? AcHPFileNumber { get; set; }

    public string? LutApplicableAccessibilityStandardId { get; set; }

    public int? TotalNumberofMobilityUnitsRequired { get; set; }

    public string? HIMSNumber { get; set; }

    public bool? ListedonAHUPProductionSchedule { get; set; }

    public double? MobiltyUnitsPercentageRequired { get; set; }

    public double? PercentageofCertifiedAccessibleSensoryUnits { get; set; }

    public bool? IsthisaPreCSADevelopment { get; set; }

    public double? AHUPScore { get; set; }

    public int? AHUPProductionScheduleYear { get; set; }

    public bool? IsthisaPreVSADevelopment { get; set; }

    public int? TotalUnits { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public double? HearingandVisionUnitsPercentageRequired { get; set; }

    public double? PercentageofCertifiedAccessibleMobilityUnits { get; set; }

    public int? TotalNumberofHearingUnitsRequired { get; set; }

    public string? LutFundingId { get; set; }

    public int? MaximumMobilityCSACount { get; set; }

    public int? MaximumMobilityVCACount { get; set; }

    public int? MaximumHearingandVisionCSACount { get; set; }

    public int? MaximumHearingandVisionVCACount { get; set; }

    public int? LutFHAStandardId { get; set; }
}
