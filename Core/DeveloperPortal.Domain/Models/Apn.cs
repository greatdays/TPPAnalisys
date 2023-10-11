using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Apn
{
    public int Apnid { get; set; }

    public int? RefApnid { get; set; }

    public string? Apn1 { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Long { get; set; }

    public string? Polygon { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? PrefSiteAddressId { get; set; }

    public string? ServiceTrackingId { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();

    public virtual ICollection<Structure> Structures { get; set; } = new List<Structure>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();

    public virtual ICollection<SiteAddress> SiteAddresses { get; set; } = new List<SiteAddress>();
}
