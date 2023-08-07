using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutListingType
{
    public int LutListingTypeId { get; set; }

    public string? ListingType { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();
}
