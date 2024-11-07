using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnOutreachTargetAudience
{
    public int AssnTargetAudienceID { get; set; }

    public int OutreachID { get; set; }

    public int LutTargetAudienceID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutTargetAudience LutTargetAudience { get; set; } = null!;

    public virtual OutreachAndAffimativeMarketing Outreach { get; set; } = null!;
}
