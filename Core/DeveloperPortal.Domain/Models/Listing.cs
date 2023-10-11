using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Listing
{
    public int ListingId { get; set; }

    public long ServiceRequestId { get; set; }

    public int PropSnapshotId { get; set; }

    public int? ListingTypeId { get; set; }

    public string? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Hrmapplication> Hrmapplications { get; set; } = new List<Hrmapplication>();

    public virtual LutListingType? ListingType { get; set; }

    public virtual PropSnapshot PropSnapshot { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
