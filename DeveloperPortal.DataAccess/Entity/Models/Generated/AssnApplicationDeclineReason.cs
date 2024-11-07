using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnApplicationDeclineReason
{
    public int AssnApplicationDeclineReasonId { get; set; }

    public int HRMApplicationId { get; set; }

    public int LutApplicationDeclineReasonId { get; set; }

    public string? Text { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual LutApplicationDeclineReason LutApplicationDeclineReason { get; set; } = null!;
}
