using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnSRCAPChecklistItemStatus
{
    public int AssnSRCAPChecklistItemStatusID { get; set; }

    public long ServiceRequestID { get; set; }

    public int LutCAPChecklistItemId { get; set; }

    public int LutCAPChecklistSubItemId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? ComplianceDate { get; set; }

    public string? Comments { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowID { get; set; }

    public bool? IsCompliantBeforeCAP { get; set; }

    public virtual LutCAPChecklistItem LutCAPChecklistItem { get; set; } = null!;

    public virtual LutCAPChecklistSubItem LutCAPChecklistSubItem { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
