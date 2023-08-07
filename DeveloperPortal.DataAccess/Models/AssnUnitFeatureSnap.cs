using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnUnitFeatureSnap
{
    public int AssnUnitFeatureSnapId { get; set; }

    public int UnitSnapId { get; set; }

    public int UnitAttributeId { get; set; }

    public int LutFeatureId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual UnitSnap UnitSnap { get; set; } = null!;
}
