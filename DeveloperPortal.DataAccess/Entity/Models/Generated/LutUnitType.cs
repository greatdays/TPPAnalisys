using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutUnitType
{
    public int LutUnitTypeId { get; set; }

    public string? UnitType { get; set; }

    public bool IsObsolute { get; set; }

    public bool IsDeleted { get; set; }

    public string? DisplayText { get; set; }

    public int? SortOrder { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsUnitType { get; set; }

    public virtual ICollection<AutransferWaitList> AutransferWaitLists { get; set; } = new List<AutransferWaitList>();

    public virtual ICollection<AuwaitList> AuwaitLists { get; set; } = new List<AuwaitList>();

    public virtual ICollection<Hrmapplication> Hrmapplications { get; set; } = new List<Hrmapplication>();

    public virtual ICollection<PmpunitAttributeSnap> PmpunitAttributeSnaps { get; set; } = new List<PmpunitAttributeSnap>();

    public virtual ICollection<QrautransferWaitList> QrautransferWaitLists { get; set; } = new List<QrautransferWaitList>();

    public virtual ICollection<QrauwaitList> QrauwaitLists { get; set; } = new List<QrauwaitList>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnits { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<UnitAttribute> UnitAttributeLutUnitTypes { get; set; } = new List<UnitAttribute>();

    public virtual ICollection<UnitAttribute> UnitAttributeTenantRequestedUnitTypes { get; set; } = new List<UnitAttribute>();
}
