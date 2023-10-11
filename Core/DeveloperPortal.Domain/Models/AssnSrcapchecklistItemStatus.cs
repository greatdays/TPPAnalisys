using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnSrcapchecklistItemStatus
{
    public int AssnSrcapchecklistItemStatusId { get; set; }

    public long ServiceRequestId { get; set; }

    public int LutCapchecklistItemId { get; set; }

    public int LutCapchecklistSubItemId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? ComplianceDate { get; set; }

    public string? Comments { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowId { get; set; }

    public bool? IsCompliantBeforeCap { get; set; }

    public virtual LutCapchecklistItem LutCapchecklistItem { get; set; } = null!;

    public virtual LutCapchecklistSubItem LutCapchecklistSubItem { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
