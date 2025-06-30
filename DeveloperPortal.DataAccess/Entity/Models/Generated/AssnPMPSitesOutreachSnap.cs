using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPmpsitesOutreachSnap
{
    public int AssnPmpsitesOutreachSnapId { get; set; }

    public int PmpsnapId { get; set; }

    public int? PropsnapshotId { get; set; }

    public int? OutreachId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual Pmpsnap Pmpsnap { get; set; } = null!;

    public virtual PropSnapshot? Propsnapshot { get; set; }
}
