using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPProjSiteAccessibleUnitFeatureSnap
{
    public int AssnPMPProjSiteAccessibleUnitFeatureSnapID { get; set; }

    public int PMPSnapID { get; set; }

    public int ProjectSiteAttributeID { get; set; }

    public int LutAccessibleUnitFeatureID { get; set; }

    public string? SpecialNote { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? HVRatio { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutAccessibleUnitFeature LutAccessibleUnitFeature { get; set; } = null!;

    public virtual PMPSnap PMPSnap { get; set; } = null!;

    public virtual ProjectSiteAttribute ProjectSiteAttribute { get; set; } = null!;
}
