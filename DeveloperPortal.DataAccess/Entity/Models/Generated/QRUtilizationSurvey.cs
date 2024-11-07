using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QRUtilizationSurvey
{
    public int QRUtilizationSurveyID { get; set; }

    public int? QuarterlyReportID { get; set; }

    public int? UnitPropSnapShotID { get; set; }

    public bool? IsOccupied { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public DateOnly? MoveInDate { get; set; }

    public DateOnly? UtilizationSurveyDate { get; set; }

    public int? IsFullyAUNeeded { get; set; }

    public int? TenantRequestedUnitTypeID { get; set; }

    public int? TenantRequestedBedroomsID { get; set; }

    public int? TenantRequestedBathroomsID { get; set; }

    public bool? IsAddedToAUTL { get; set; }

    public string? NotAddedToAUTLReason { get; set; }

    public int? IsAccessibleFeaturesNeeded { get; set; }

    public string? AccessibleFeatureType { get; set; }

    public bool? IsAdvisedRightToRM { get; set; }

    public bool? IsAddedToRARMLog { get; set; }

    public string? NotAddedToRARMLogReason { get; set; }

    public int? IsTenantHasAssistanceAnimal { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual QuarterlyReport? QuarterlyReport { get; set; }

    public virtual PropSnapshot? UnitPropSnapShot { get; set; }
}
