using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPScatteredSite
{
    public int AssnPMPScatteredSiteID { get; set; }

    public int? PMPID { get; set; }

    public int? PropSnapshotID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual PMP? PMP { get; set; }

    public virtual PropSnapshot? PropSnapshot { get; set; }
}
