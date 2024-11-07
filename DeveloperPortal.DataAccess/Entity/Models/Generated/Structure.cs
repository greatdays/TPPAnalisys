using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Structure
{
    public int StructureID { get; set; }

    public int? RefBuildingID { get; set; }

    public int APNID { get; set; }

    public int? LutStructureTypeID { get; set; }

    public string? Description { get; set; }

    public DateTime? DateBuilt { get; set; }

    public DateTime? DateDemolished { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Long { get; set; }

    public bool IsReviewRequired { get; set; }

    public string? Source { get; set; }

    public string? SourceRefID { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public bool IsDeleted { get; set; }

    public string? StructureNo { get; set; }

    public string? Label { get; set; }

    public string? ServiceTrackingID { get; set; }

    public int? TotalUnits { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? BuildingFileNumber { get; set; }

    public virtual APN APN { get; set; } = null!;

    public virtual ICollection<Level> Levels { get; set; } = new List<Level>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual LutStructureType1? LutStructureType { get; set; }

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();

    public virtual ICollection<QROccupancyUnit> QROccupancyUnits { get; set; } = new List<QROccupancyUnit>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();

    public virtual ICollection<SiteAddress> SiteAddresses { get; set; } = new List<SiteAddress>();
}
