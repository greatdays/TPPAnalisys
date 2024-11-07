using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutTotalBathroom
{
    public int LutTotalBathroomsID { get; set; }

    public string? Description { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AUTransferWaitList> AUTransferWaitLists { get; set; } = new List<AUTransferWaitList>();

    public virtual ICollection<AUWaitList> AUWaitLists { get; set; } = new List<AUWaitList>();

    public virtual ICollection<HRMApplication> HRMApplications { get; set; } = new List<HRMApplication>();

    public virtual ICollection<PMPUnitAttributeSnap> PMPUnitAttributeSnaps { get; set; } = new List<PMPUnitAttributeSnap>();

    public virtual ICollection<QRAUTransferWaitList> QRAUTransferWaitLists { get; set; } = new List<QRAUTransferWaitList>();

    public virtual ICollection<QRAUWaitList> QRAUWaitLists { get; set; } = new List<QRAUWaitList>();

    public virtual ICollection<QROccupancyUnit> QROccupancyUnits { get; set; } = new List<QROccupancyUnit>();

    public virtual ICollection<QRReasonableAccommodation> QRReasonableAccommodations { get; set; } = new List<QRReasonableAccommodation>();

    public virtual ICollection<ReasonableAccommodation> ReasonableAccommodations { get; set; } = new List<ReasonableAccommodation>();

    public virtual ICollection<UnitAttribute> UnitAttributeLutTotalBathrooms { get; set; } = new List<UnitAttribute>();

    public virtual ICollection<UnitAttribute> UnitAttributeTenantRequestedBathrooms { get; set; } = new List<UnitAttribute>();
}
