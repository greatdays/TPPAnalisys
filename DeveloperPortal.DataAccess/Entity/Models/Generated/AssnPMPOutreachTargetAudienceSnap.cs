using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPOutreachTargetAudienceSnap
{
    public int AssnPMPTargetAudienceSnapID { get; set; }

    public int PMPSnapID { get; set; }

    public int OutreachID { get; set; }

    public int LutTargetAudienceID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutTargetAudience LutTargetAudience { get; set; } = null!;

    public virtual PMPSnap PMPSnap { get; set; } = null!;
}
