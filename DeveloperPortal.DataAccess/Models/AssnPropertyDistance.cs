using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnPropertyDistance
{
    public int ProjectSiteAttributeId { get; set; }

    public int LutDistanceTypeId { get; set; }

    public int LutDistanceId { get; set; }

    public virtual LutDistance LutDistance { get; set; } = null!;

    public virtual LutDistanceType LutDistanceType { get; set; } = null!;

    public virtual ProjectSiteAttribute ProjectSiteAttribute { get; set; } = null!;
}
