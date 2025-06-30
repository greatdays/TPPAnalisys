using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutFixedFloatingUnit
{
    public int LutFixedFloatingUnitId { get; set; }

    public string? Description { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<PmpunitAttributeSnap> PmpunitAttributeSnaps { get; set; } = new List<PmpunitAttributeSnap>();

    public virtual ICollection<UnitAttribute> UnitAttributes { get; set; } = new List<UnitAttribute>();
}
