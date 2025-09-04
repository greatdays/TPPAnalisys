using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutReasonDeterminationNotProvidedSooner
{
    public int LutReasonDeterminationNotProvidedSoonerId { get; set; }

    public string ReasonDeterminationNotProvidedSooner { get; set; } = null!;

    public int ViewOrder { get; set; }

    public bool IsAbsolute { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AutransferWaitList> AutransferWaitLists { get; set; } = new List<AutransferWaitList>();

    public virtual ICollection<QrautransferWaitList> QrautransferWaitLists { get; set; } = new List<QrautransferWaitList>();
}
