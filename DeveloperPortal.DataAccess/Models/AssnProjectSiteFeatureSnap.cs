using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnProjectSiteFeatureSnap
{
    public int AssnProjectSitefeatureSnapId { get; set; }

    public int ProjectSiteSnapId { get; set; }

    public int ProjectSiteAttributeId { get; set; }

    public int LutFeatureId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ProjectSiteSnap ProjectSiteSnap { get; set; } = null!;
}
