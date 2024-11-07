using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Location
{
    public int LocationID { get; set; }

    public int LutLocationTypeID { get; set; }

    public int APNID { get; set; }

    public int? ProjectSiteID { get; set; }

    public int? StructureID { get; set; }

    public int? LevelID { get; set; }

    public int? UnitID { get; set; }

    public string? Label { get; set; }

    public string? Description { get; set; }

    public DateTime? DateBuilt { get; set; }

    public DateTime? DateDemolished { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Long { get; set; }

    public bool IsReviewRequired { get; set; }

    public string? Source { get; set; }

    public int? SourceRefID { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public string? ServiceTrackingID { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual APN APN { get; set; } = null!;

    public virtual ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();

    public virtual Level? Level { get; set; }

    public virtual LutLocationType LutLocationType { get; set; } = null!;

    public virtual ProjectSite? ProjectSite { get; set; }

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();

    public virtual Structure? Structure { get; set; }

    public virtual Unit? Unit { get; set; }
}
