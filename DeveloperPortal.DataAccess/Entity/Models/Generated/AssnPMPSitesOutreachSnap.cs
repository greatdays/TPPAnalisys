using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPSitesOutreachSnap
{
    public int AssnPMPSitesOutreachSnapID { get; set; }

    public int PMPSnapID { get; set; }

    public int? PropsnapshotID { get; set; }

    public int? OutreachID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual PMPSnap PMPSnap { get; set; } = null!;

    public virtual PropSnapshot? Propsnapshot { get; set; }
}
