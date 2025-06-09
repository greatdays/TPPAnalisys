using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPmpprojTypeSiteAttrSnap
{
    public int AssnPmpprojTypeSiteAttrSnapId { get; set; }

    public int PmpsnapId { get; set; }

    public int ProjectSiteAttributeId { get; set; }

    public int LutPmpprojTypeId { get; set; }

    public string? SpecialNote { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutPmpprojType LutPmpprojType { get; set; } = null!;

    public virtual Pmpsnap Pmpsnap { get; set; } = null!;

    public virtual ProjectSiteAttribute ProjectSiteAttribute { get; set; } = null!;
}
