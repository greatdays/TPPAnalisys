using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPScatteredSiteSnap
{
    public int AssnPMPScatteredSiteSnapID { get; set; }

    public int? PMPSnapID { get; set; }

    public int? PropSnapshotID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual PMPSnap? PMPSnap { get; set; }

    public virtual PropSnapshot? PropSnapshot { get; set; }
}
