using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPmpunitFeatureSnap
{
    public int AssnPmpunitFeatureSnapId { get; set; }

    public int PmpsnapId { get; set; }

    public int AssnUnitFeatureId { get; set; }

    public int UnitAttributeId { get; set; }

    public int LutFeatureId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual LutFeature LutFeature { get; set; } = null!;

    public virtual Pmpsnap Pmpsnap { get; set; } = null!;
}
