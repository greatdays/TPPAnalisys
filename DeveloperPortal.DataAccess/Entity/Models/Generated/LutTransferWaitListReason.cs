using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutTransferWaitListReason
{
    public int LutTransferWaitListReasonID { get; set; }

    public string? Reason { get; set; }

    public bool? IsAbsolute { get; set; }

    public bool IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AUTransferWaitList> AUTransferWaitLists { get; set; } = new List<AUTransferWaitList>();

    public virtual ICollection<QRAUTransferWaitList> QRAUTransferWaitLists { get; set; } = new List<QRAUTransferWaitList>();
}
