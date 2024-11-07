using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPropertyDistance
{
    public int ProjectSiteAttributeID { get; set; }

    public int LutDistanceTypeID { get; set; }

    public int LutDistanceID { get; set; }

    public virtual LutDistance LutDistance { get; set; } = null!;

    public virtual LutDistanceType LutDistanceType { get; set; } = null!;

    public virtual ProjectSiteAttribute ProjectSiteAttribute { get; set; } = null!;
}
