using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnPmpscatteredSite
{
    public int AssnPmpscatteredSiteId { get; set; }

    public int? Pmpid { get; set; }

    public int? PropSnapshotId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Pmp? Pmp { get; set; }

    public virtual PropSnapshot? PropSnapshot { get; set; }
}
