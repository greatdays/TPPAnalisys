using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class ListingSnap
{
    public int ListingSnapId { get; set; }

    public int ListingId { get; set; }

    public long ServiceRequestId { get; set; }

    public int PropSnapshotId { get; set; }

    public int? ListingTypeId { get; set; }

    public string? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<Hrmapplication> Hrmapplications { get; set; } = new List<Hrmapplication>();

    public virtual ICollection<ProjectSiteSnap> ProjectSiteSnaps { get; set; } = new List<ProjectSiteSnap>();
}
