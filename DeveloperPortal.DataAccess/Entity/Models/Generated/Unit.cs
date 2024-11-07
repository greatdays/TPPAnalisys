using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Unit
{
    public int UnitID { get; set; }

    public int? RefUnitID { get; set; }

    public int? SiteAddressID { get; set; }

    public int? APNID { get; set; }

    public int? BuildingID { get; set; }

    public int? LevelID { get; set; }

    public int? ProjectID { get; set; }

    public int? ProjectSiteID { get; set; }

    public string? UnitNum { get; set; }

    public string? Status { get; set; }

    public string? ServiceTrackingID { get; set; }

    public int? LutUnitAccessibiltyTypeID { get; set; }

    public bool? IsUpdated { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Attributes { get; set; }

    public string? Source { get; set; }

    public virtual APN? APN { get; set; }

    public virtual Structure? Building { get; set; }

    public virtual Level? Level { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual LutUnitAccessibiltyType? LutUnitAccessibiltyType { get; set; }

    public virtual ICollection<PMPUnitSnap> PMPUnitSnaps { get; set; } = new List<PMPUnitSnap>();

    public virtual Project? Project { get; set; }

    public virtual ProjectSite? ProjectSite { get; set; }

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();

    public virtual SiteAddress? SiteAddress { get; set; }
}
