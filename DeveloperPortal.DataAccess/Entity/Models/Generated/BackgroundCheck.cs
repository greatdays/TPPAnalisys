using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class BackgroundCheck
{
    public int BackgroundCheckID { get; set; }

    public long ServiceRequestID { get; set; }

    public string DeveloperPropMgmt { get; set; } = null!;

    public string RequestorName { get; set; } = null!;

    public DateOnly RequestedDate { get; set; }

    public DateOnly Deadline { get; set; }

    public int? LutFollowUpTypeID { get; set; }

    public string? BGCComment { get; set; }

    public DateOnly? BGCSentDate { get; set; }

    public DateOnly? AnalystReviewDueDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual ICollection<AssnBGCNonCoveredProperty> AssnBGCNonCoveredProperties { get; set; } = new List<AssnBGCNonCoveredProperty>();

    public virtual ICollection<AssnBackgroundCheck> AssnBackgroundChecks { get; set; } = new List<AssnBackgroundCheck>();

    public virtual ICollection<BackgroundCheckReport> BackgroundCheckReports { get; set; } = new List<BackgroundCheckReport>();

    public virtual LutFollowUpType? LutFollowUpType { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
