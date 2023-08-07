using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnOutreachTargetAudience
{
    public int AssnTargetAudienceId { get; set; }

    public int OutreachId { get; set; }

    public int LutTargetAudienceId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutTargetAudience LutTargetAudience { get; set; } = null!;

    public virtual OutreachAndAffimativeMarketing Outreach { get; set; } = null!;
}
