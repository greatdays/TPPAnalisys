using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutUserType
{
    public int LutUserTypeId { get; set; }

    public string UserType { get; set; } = null!;

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<EffectiveCommunication> EffectiveCommunications { get; set; } = new List<EffectiveCommunication>();

    public virtual ICollection<GrievanceLog> GrievanceLogs { get; set; } = new List<GrievanceLog>();

    public virtual ICollection<QreffectiveCommunication> QreffectiveCommunications { get; set; } = new List<QreffectiveCommunication>();

    public virtual ICollection<QrgrievanceLog> QrgrievanceLogs { get; set; } = new List<QrgrievanceLog>();

    public virtual ICollection<QrreasonableAccommodation> QrreasonableAccommodations { get; set; } = new List<QrreasonableAccommodation>();

    public virtual ICollection<ReasonableAccommodation> ReasonableAccommodations { get; set; } = new List<ReasonableAccommodation>();
}
