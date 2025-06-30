using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Unit
{
    public int UnitId { get; set; }

    public int? RefUnitId { get; set; }

    public int? SiteAddressId { get; set; }

    public int? Apnid { get; set; }

    public int? BuildingId { get; set; }

    public int? LevelId { get; set; }

    public int? ProjectId { get; set; }

    public int? ProjectSiteId { get; set; }

    public string? UnitNum { get; set; }

    public string? Status { get; set; }

    public string? ServiceTrackingId { get; set; }

    public int? LutUnitAccessibiltyTypeId { get; set; }

    public bool? IsUpdated { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Attributes { get; set; }

    public string? Source { get; set; }

    public virtual Apn? Apn { get; set; }

    public virtual Structure? Building { get; set; }

    public virtual Level? Level { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual LutUnitAccessibiltyType? LutUnitAccessibiltyType { get; set; }

    public virtual ICollection<PmpunitSnap> PmpunitSnaps { get; set; } = new List<PmpunitSnap>();

    public virtual Project? Project { get; set; }

    public virtual ProjectSite? ProjectSite { get; set; }

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();

    public virtual SiteAddress? SiteAddress { get; set; }
}
