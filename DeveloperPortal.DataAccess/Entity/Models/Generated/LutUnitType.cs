using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutUnitType
{
    public int LutUnitTypeID { get; set; }

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

    public virtual ICollection<AUTransferWaitList> AUTransferWaitLists { get; set; } = new List<AUTransferWaitList>();

    public virtual ICollection<AUWaitList> AUWaitLists { get; set; } = new List<AUWaitList>();

    public virtual ICollection<HRMApplication> HRMApplications { get; set; } = new List<HRMApplication>();

    public virtual ICollection<PMPUnitAttributeSnap> PMPUnitAttributeSnaps { get; set; } = new List<PMPUnitAttributeSnap>();

    public virtual ICollection<QRAUTransferWaitList> QRAUTransferWaitLists { get; set; } = new List<QRAUTransferWaitList>();

    public virtual ICollection<QRAUWaitList> QRAUWaitLists { get; set; } = new List<QRAUWaitList>();

    public virtual ICollection<QROccupancyUnit> QROccupancyUnits { get; set; } = new List<QROccupancyUnit>();

    public virtual ICollection<UnitAttribute> UnitAttributeLutUnitTypes { get; set; } = new List<UnitAttribute>();

    public virtual ICollection<UnitAttribute> UnitAttributeTenantRequestedUnitTypes { get; set; } = new List<UnitAttribute>();
}
