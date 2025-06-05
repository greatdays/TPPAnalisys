using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnWalkInApplicationDeclineReason
{
    public int AssnWalkInApplicationDeclineReasonId { get; set; }

    public int AuwaitListId { get; set; }

    public int LutApplicationDeclineReasonId { get; set; }

    public string? Text { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual AuwaitList AuwaitList { get; set; } = null!;

    public virtual LutApplicationDeclineReason LutApplicationDeclineReason { get; set; } = null!;
}
