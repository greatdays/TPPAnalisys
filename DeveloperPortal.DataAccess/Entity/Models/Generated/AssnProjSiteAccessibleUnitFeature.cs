using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnProjSiteAccessibleUnitFeature
{
    public int AssnProjSiteAccessibleUnitFeatureID { get; set; }

    public int ProjectSiteAttributeID { get; set; }

    public int LutAccessibleUnitFeatureID { get; set; }

    public string? SpecialNote { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? HVRatio { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutAccessibleUnitFeature LutAccessibleUnitFeature { get; set; } = null!;

    public virtual ProjectSiteAttribute ProjectSiteAttribute { get; set; } = null!;
}
