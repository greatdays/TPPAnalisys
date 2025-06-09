using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutTenantSelectedFrom
{
    public int LutTenantSelectedFromId { get; set; }

    public string TenantSelectedFrom { get; set; } = null!;

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public int? SortOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<PmpunitAttributeSnap> PmpunitAttributeSnaps { get; set; } = new List<PmpunitAttributeSnap>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnits { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<UnitAttribute> UnitAttributes { get; set; } = new List<UnitAttribute>();
}
