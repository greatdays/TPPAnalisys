using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutCloseReason
{
    public int LutCloseReasonId { get; set; }

    public string? Reason { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<EnforcementMilestone> EnforcementMilestones { get; set; } = new List<EnforcementMilestone>();
}
