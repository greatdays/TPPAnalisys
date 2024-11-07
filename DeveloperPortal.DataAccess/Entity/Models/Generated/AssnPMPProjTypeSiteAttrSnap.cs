using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPProjTypeSiteAttrSnap
{
    public int AssnPMPProjTypeSiteAttrSnapID { get; set; }

    public int PMPSnapID { get; set; }

    public int ProjectSiteAttributeID { get; set; }

    public int LutPMPProjTypeID { get; set; }

    public string? SpecialNote { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutPMPProjType LutPMPProjType { get; set; } = null!;

    public virtual PMPSnap PMPSnap { get; set; } = null!;

    public virtual ProjectSiteAttribute ProjectSiteAttribute { get; set; } = null!;
}
