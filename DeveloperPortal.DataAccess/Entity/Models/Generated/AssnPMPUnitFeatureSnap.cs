using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPUnitFeatureSnap
{
    public int AssnPMPUnitFeatureSnapID { get; set; }

    public int PMPSnapID { get; set; }

    public int AssnUnitFeatureID { get; set; }

    public int UnitAttributeID { get; set; }

    public int LutFeatureID { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual LutFeature LutFeature { get; set; } = null!;

    public virtual PMPSnap PMPSnap { get; set; } = null!;
}
