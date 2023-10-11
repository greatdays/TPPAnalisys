using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutApplicationDeclineReason
{
    public int LutApplicationDeclineReasonId { get; set; }

    public string DeclineReason { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnApplicationDeclineReason> AssnApplicationDeclineReasons { get; set; } = new List<AssnApplicationDeclineReason>();

    public virtual ICollection<AssnWalkInApplicationDeclineReason> AssnWalkInApplicationDeclineReasons { get; set; } = new List<AssnWalkInApplicationDeclineReason>();
}
