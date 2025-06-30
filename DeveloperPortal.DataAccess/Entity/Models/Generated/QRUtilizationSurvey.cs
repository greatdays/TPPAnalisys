using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QrutilizationSurvey
{
    public int QrutilizationSurveyId { get; set; }

    public int? QuarterlyReportId { get; set; }

    public int? UnitPropSnapShotId { get; set; }

    public bool? IsOccupied { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public DateOnly? MoveInDate { get; set; }

    public DateOnly? UtilizationSurveyDate { get; set; }

    public int? IsFullyAuneeded { get; set; }

    public int? TenantRequestedUnitTypeId { get; set; }

    public int? TenantRequestedBedroomsId { get; set; }

    public int? TenantRequestedBathroomsId { get; set; }

    public bool? IsAddedToAutl { get; set; }

    public string? NotAddedToAutlreason { get; set; }

    public int? IsAccessibleFeaturesNeeded { get; set; }

    public string? AccessibleFeatureType { get; set; }

    public bool? IsAdvisedRightToRm { get; set; }

    public bool? IsAddedToRarmlog { get; set; }

    public string? NotAddedToRarmlogReason { get; set; }

    public int? IsTenantHasAssistanceAnimal { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual QuarterlyReport? QuarterlyReport { get; set; }

    public virtual PropSnapshot? UnitPropSnapShot { get; set; }
}
