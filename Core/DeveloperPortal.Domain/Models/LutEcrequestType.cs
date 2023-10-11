using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutEcrequestType
{
    public int LutEcrequestTypeId { get; set; }

    public string EcrequestType { get; set; } = null!;

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<EffectiveCommunication> EffectiveCommunications { get; set; } = new List<EffectiveCommunication>();

    public virtual ICollection<LutEctype> LutEctypes { get; set; } = new List<LutEctype>();

    public virtual ICollection<QreffectiveCommunication> QreffectiveCommunications { get; set; } = new List<QreffectiveCommunication>();
}
