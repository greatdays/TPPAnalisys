using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutWithdrawReason
{
    public int LutWithdrawReasonId { get; set; }

    public string? WithdrawReason { get; set; }

    public bool IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<CAPDetail> CAPDetails { get; set; } = new List<CAPDetail>();

    public virtual ICollection<EnforcementOrderReviewDetail> EnforcementOrderReviewDetails { get; set; } = new List<EnforcementOrderReviewDetail>();
}
