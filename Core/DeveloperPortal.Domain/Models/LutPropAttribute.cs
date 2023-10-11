using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutPropAttribute
{
    public int LutPropAttributeId { get; set; }

    public string FlagType { get; set; } = null!;

    public string? IdentifierType { get; set; }

    public virtual ICollection<PropAttribute> PropAttributes { get; set; } = new List<PropAttribute>();
}
