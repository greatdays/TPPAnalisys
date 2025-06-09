using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnLutDistanceTypeSnap
{
    public int AssnDistanceTypeSnapId { get; set; }

    public int ProjectSiteSnapId { get; set; }

    public int ProjectSiteAttributeId { get; set; }

    public int LutDistanceTypeId { get; set; }

    public int LutDistanceId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ProjectSiteSnap ProjectSiteSnap { get; set; } = null!;
}
