using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Capextension
{
    public int CapextensionId { get; set; }

    public long ServiceRequestId { get; set; }

    public int ExtnCount { get; set; }

    public DateTime RequestDate { get; set; }

    public DateTime? GrantDenyDate { get; set; }

    public DateTime ExtnEndDate { get; set; }

    public string ExtnStatus { get; set; } = null!;

    public string? Reason { get; set; }

    public string Capstatus { get; set; } = null!;

    public string RequestedBy { get; set; } = null!;

    public string? ApprovedBy { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
