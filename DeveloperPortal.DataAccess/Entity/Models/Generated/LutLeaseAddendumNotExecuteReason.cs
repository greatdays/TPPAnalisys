using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutLeaseAddendumNotExecuteReason
{
    public int LutLeaseAddendumNotExecuteReasonID { get; set; }

    public string LeaseAddendumNotExecuteReason { get; set; } = null!;

    public bool IsAbsolute { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<PMPUnitAttributeSnap> PMPUnitAttributeSnaps { get; set; } = new List<PMPUnitAttributeSnap>();

    public virtual ICollection<QROccupancyUnit> QROccupancyUnits { get; set; } = new List<QROccupancyUnit>();

    public virtual ICollection<UnitAttribute> UnitAttributes { get; set; } = new List<UnitAttribute>();

    public virtual ICollection<UnitSnap> UnitSnaps { get; set; } = new List<UnitSnap>();
}
