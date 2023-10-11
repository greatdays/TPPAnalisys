using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutTotalBedroom
{
    public int LutTotalBedroomsId { get; set; }

    public string? Description { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? SortOrder { get; set; }

    public virtual ICollection<AutransferWaitList> AutransferWaitLists { get; set; } = new List<AutransferWaitList>();

    public virtual ICollection<AuwaitList> AuwaitLists { get; set; } = new List<AuwaitList>();

    public virtual ICollection<Hrmapplication> Hrmapplications { get; set; } = new List<Hrmapplication>();

    public virtual ICollection<QrautransferWaitList> QrautransferWaitLists { get; set; } = new List<QrautransferWaitList>();

    public virtual ICollection<QrauwaitList> QrauwaitLists { get; set; } = new List<QrauwaitList>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnits { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<QrreasonableAccommodation> QrreasonableAccommodations { get; set; } = new List<QrreasonableAccommodation>();

    public virtual ICollection<ReasonableAccommodation> ReasonableAccommodations { get; set; } = new List<ReasonableAccommodation>();

    public virtual ICollection<UnitAttribute> UnitAttributeLutTotalBedrooms { get; set; } = new List<UnitAttribute>();

    public virtual ICollection<UnitAttribute> UnitAttributeTenantRequestedBedrooms { get; set; } = new List<UnitAttribute>();
}
