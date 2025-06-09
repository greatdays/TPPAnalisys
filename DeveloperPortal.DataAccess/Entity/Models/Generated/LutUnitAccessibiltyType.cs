using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutUnitAccessibiltyType
{
    public int LutUnitAccessibiltyTypeId { get; set; }

    public string UnitAccessibiltyType { get; set; } = null!;

    /// <summary>
    /// Description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Is Obsolete.
    /// </summary>
    public bool IsObsolete { get; set; }

    /// <summary>
    /// Record created username.
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Record created date.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Record modified username.
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Record modified date.
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<PmpunitSnap> PmpunitSnaps { get; set; } = new List<PmpunitSnap>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
