using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutCAPCloseReason
{
    public int LutCAPCloseReasonId { get; set; }

    public string? Reason { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<CAPDetail> CAPDetails { get; set; } = new List<CAPDetail>();
}
