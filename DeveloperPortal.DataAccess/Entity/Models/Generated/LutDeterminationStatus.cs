using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutDeterminationStatus
{
    public int LutDeterminationStatusID { get; set; }

    public string DeterminationStatus { get; set; } = null!;

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<EffectiveCommunication> EffectiveCommunications { get; set; } = new List<EffectiveCommunication>();

    public virtual ICollection<QREffectiveCommunication> QREffectiveCommunications { get; set; } = new List<QREffectiveCommunication>();

    public virtual ICollection<QRReasonableAccommodation> QRReasonableAccommodations { get; set; } = new List<QRReasonableAccommodation>();

    public virtual ICollection<ReasonableAccommodation> ReasonableAccommodations { get; set; } = new List<ReasonableAccommodation>();
}
