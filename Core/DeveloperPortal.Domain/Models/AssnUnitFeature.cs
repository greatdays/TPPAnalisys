using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnUnitFeature
{
    public int AssnUnitFeatureId { get; set; }

    public int UnitAttributeId { get; set; }

    public int LutFeatureId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutFeature LutFeature { get; set; } = null!;

    public virtual UnitAttribute UnitAttribute { get; set; } = null!;
}
