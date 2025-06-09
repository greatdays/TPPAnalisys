using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectAttribute
{
    public int ProjectAttributeId { get; set; }

    public int PropSnapshotId { get; set; }

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

    public string? LutNacRecomadationId { get; set; }

    public int? LutAhupscoreId { get; set; }

    public bool? IsExistingProject { get; set; }

    public string? ProjectDescription { get; set; }

    public bool? Eapproject { get; set; }

    public bool? ModularProject { get; set; }

    public bool? ProjectWithScatteredSites { get; set; }

    public string? AdditionalRcs { get; set; }

    public string? ResponseToRetrofitSurveyEmailContent { get; set; }

    public int? LutSiteSurveyGroupId { get; set; }

    public string? PrimaryHimsnumber { get; set; }

    public string? AssociatedHimsnumbers { get; set; }

    public DateTime? CovenantExpirationDate { get; set; }

    public string? ProjectStatusLabel { get; set; }

    public virtual PropSnapshot PropSnapshot { get; set; } = null!;
}
