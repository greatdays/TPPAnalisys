using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutTransferWaitListReason
{
    public int LutTransferWaitListReasonId { get; set; }

    public string? Reason { get; set; }

    public bool? IsAbsolute { get; set; }

    public bool IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AutransferWaitList> AutransferWaitLists { get; set; } = new List<AutransferWaitList>();

    public virtual ICollection<QrautransferWaitList> QrautransferWaitLists { get; set; } = new List<QrautransferWaitList>();
}
