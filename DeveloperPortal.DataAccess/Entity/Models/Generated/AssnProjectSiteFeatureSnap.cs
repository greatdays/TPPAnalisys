using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnProjectSiteFeatureSnap
{
    public int AssnProjectSitefeatureSnapID { get; set; }

    public int ProjectSiteSnapID { get; set; }

    public int ProjectSiteAttributeID { get; set; }

    public int LutFeatureID { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ProjectSiteSnap ProjectSiteSnap { get; set; } = null!;
}
