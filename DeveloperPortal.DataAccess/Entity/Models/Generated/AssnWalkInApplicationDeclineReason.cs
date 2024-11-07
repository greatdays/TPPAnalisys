using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnWalkInApplicationDeclineReason
{
    public int AssnWalkInApplicationDeclineReasonID { get; set; }

    public int AUWaitListID { get; set; }

    public int LutApplicationDeclineReasonID { get; set; }

    public string? Text { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual AUWaitList AUWaitList { get; set; } = null!;

    public virtual LutApplicationDeclineReason LutApplicationDeclineReason { get; set; } = null!;
}
