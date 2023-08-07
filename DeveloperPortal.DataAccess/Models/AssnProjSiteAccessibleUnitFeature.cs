using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnProjSiteAccessibleUnitFeature
{
    public int AssnProjSiteAccessibleUnitFeatureId { get; set; }

    public int ProjectSiteAttributeId { get; set; }

    public int LutAccessibleUnitFeatureId { get; set; }

    public string? SpecialNote { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? Hvratio { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutAccessibleUnitFeature LutAccessibleUnitFeature { get; set; } = null!;

    public virtual ProjectSiteAttribute ProjectSiteAttribute { get; set; } = null!;
}
