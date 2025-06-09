using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPmpoutreachTargetAudienceSnap
{
    public int AssnPmptargetAudienceSnapId { get; set; }

    public int PmpsnapId { get; set; }

    public int OutreachId { get; set; }

    public int LutTargetAudienceId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutTargetAudience LutTargetAudience { get; set; } = null!;

    public virtual Pmpsnap Pmpsnap { get; set; } = null!;
}
