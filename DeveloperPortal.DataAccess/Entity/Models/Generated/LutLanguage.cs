using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutLanguage
{
    public int LutLanguageId { get; set; }

    public string Language { get; set; } = null!;

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<EffectiveCommunication> EffectiveCommunications { get; set; } = new List<EffectiveCommunication>();

    public virtual ICollection<QreffectiveCommunication> QreffectiveCommunications { get; set; } = new List<QreffectiveCommunication>();
}
