using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Listing
{
    public int ListingID { get; set; }

    public long ServiceRequestID { get; set; }

    public int PropSnapshotID { get; set; }

    public int? ListingTypeID { get; set; }

    public string? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? UnitInputJson { get; set; }

    public virtual ICollection<HRMApplication> HRMApplications { get; set; } = new List<HRMApplication>();

    public virtual LutListingType? ListingType { get; set; }

    public virtual PropSnapshot PropSnapshot { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
