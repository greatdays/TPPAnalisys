using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutTargetAudience
{
    public int LutTargetAudienceId { get; set; }

    public string? Name { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnOutreachTargetAudience> AssnOutreachTargetAudiences { get; set; } = new List<AssnOutreachTargetAudience>();
}
