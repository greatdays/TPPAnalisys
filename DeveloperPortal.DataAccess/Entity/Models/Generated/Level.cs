using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Level
{
    public int LevelID { get; set; }

    public int? RefFloorID { get; set; }

    public int? StructureID { get; set; }

    public string? Floor { get; set; }

    public string? FloorType { get; set; }

    public int? TotalUnits { get; set; }

    public string? ServiceTrackingID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Status { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<PMPUnitSnap> PMPUnitSnaps { get; set; } = new List<PMPUnitSnap>();

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();

    public virtual ICollection<QROccupancyUnit> QROccupancyUnits { get; set; } = new List<QROccupancyUnit>();

    public virtual Structure? Structure { get; set; }

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
