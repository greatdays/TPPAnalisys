using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectAttributeLog
{
    public int ProjectAttributeLogId { get; set; }

    public int? ProjectAttributeId { get; set; }

    public int? PropSnapshotId { get; set; }

    public string? ProjectName { get; set; }

    public bool? AnySeniorSite { get; set; }

    public string? AcHpassociatedAccessorParcelNumberApn { get; set; }

    public string? HimsassociatedAssessorParcelNumberApn { get; set; }

    public bool? SharedParkingLots { get; set; }

    public string? AssignedRcs { get; set; }

    public string? Status { get; set; }

    public int? ResidentialparkingOrNumberOfUnit { get; set; }

    public bool? AssignedReidentialParking { get; set; }

    public string? AcHpfileNumber { get; set; }

    public string? LutApplicableAccessibilityStandardId { get; set; }

    public int? TotalNumberofMobilityUnitsRequired { get; set; }

    public string? Himsnumber { get; set; }

    public bool? ListedonAhupproductionSchedule { get; set; }

    public double? MobiltyUnitsPercentageRequired { get; set; }

    public double? PercentageofCertifiedAccessibleSensoryUnits { get; set; }

    public bool? IsthisaPreCsadevelopment { get; set; }

    public double? Ahupscore { get; set; }

    public int? AhupproductionScheduleYear { get; set; }

    public bool? IsthisaPreVsadevelopment { get; set; }

    public int? TotalUnits { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public double? HearingandVisionUnitsPercentageRequired { get; set; }

    public double? PercentageofCertifiedAccessibleMobilityUnits { get; set; }

    public int? TotalNumberofHearingUnitsRequired { get; set; }

    public string? LutFundingId { get; set; }

    public int? MaximumMobilityCsacount { get; set; }

    public int? MaximumMobilityVcacount { get; set; }

    public int? MaximumHearingandVisionCsacount { get; set; }

    public int? MaximumHearingandVisionVcacount { get; set; }

    public int? LutFhastandardId { get; set; }
}
