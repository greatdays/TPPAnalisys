using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPmpprojSiteAccessibleUnitFeatureSnap
{
    public int AssnPmpprojSiteAccessibleUnitFeatureSnapId { get; set; }

    public int PmpsnapId { get; set; }

    public int ProjectSiteAttributeId { get; set; }

    public int LutAccessibleUnitFeatureId { get; set; }

    public string? SpecialNote { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? Hvratio { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutAccessibleUnitFeature LutAccessibleUnitFeature { get; set; } = null!;

    public virtual Pmpsnap Pmpsnap { get; set; } = null!;

    public virtual ProjectSiteAttribute ProjectSiteAttribute { get; set; } = null!;
}
