using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnUnitFeature
{
    public int AssnUnitFeatureID { get; set; }

    public int UnitAttributeID { get; set; }

    public int LutFeatureID { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutFeature LutFeature { get; set; } = null!;

    public virtual UnitAttribute UnitAttribute { get; set; } = null!;
}
