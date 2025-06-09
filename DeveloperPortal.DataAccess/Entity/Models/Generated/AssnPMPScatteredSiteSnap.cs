using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPmpscatteredSiteSnap
{
    public int AssnPmpscatteredSiteSnapId { get; set; }

    public int? PmpsnapId { get; set; }

    public int? PropSnapshotId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual Pmpsnap? Pmpsnap { get; set; }

    public virtual PropSnapshot? PropSnapshot { get; set; }
}
