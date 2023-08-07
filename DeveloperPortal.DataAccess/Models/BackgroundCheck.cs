using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class BackgroundCheck
{
    public int BackgroundCheckId { get; set; }

    public long ServiceRequestId { get; set; }

    public string DeveloperPropMgmt { get; set; } = null!;

    public string RequestorName { get; set; } = null!;

    public DateTime RequestedDate { get; set; }

    public DateTime Deadline { get; set; }

    public int? LutFollowUpTypeId { get; set; }

    public string? Bgccomment { get; set; }

    public DateTime? BgcsentDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnBackgroundCheck> AssnBackgroundChecks { get; set; } = new List<AssnBackgroundCheck>();

    public virtual ICollection<BackgroundCheckReport> BackgroundCheckReports { get; set; } = new List<BackgroundCheckReport>();

    public virtual LutFollowUpType? LutFollowUpType { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
