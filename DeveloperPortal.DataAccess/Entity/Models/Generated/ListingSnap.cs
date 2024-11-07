using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ListingSnap
{
    public int ListingSnapID { get; set; }

    public int ListingID { get; set; }

    public long ServiceRequestID { get; set; }

    public int PropSnapshotID { get; set; }

    public int? ListingTypeID { get; set; }

    public string? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<HRMApplication> HRMApplications { get; set; } = new List<HRMApplication>();

    public virtual ICollection<ProjectSiteSnap> ProjectSiteSnaps { get; set; } = new List<ProjectSiteSnap>();
}
