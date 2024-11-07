using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnLutDistanceTypeSnap
{
    public int AssnDistanceTypeSnapID { get; set; }

    public int ProjectSiteSnapID { get; set; }

    public int ProjectSiteAttributeID { get; set; }

    public int LutDistanceTypeID { get; set; }

    public int LutDistanceID { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ProjectSiteSnap ProjectSiteSnap { get; set; } = null!;
}
