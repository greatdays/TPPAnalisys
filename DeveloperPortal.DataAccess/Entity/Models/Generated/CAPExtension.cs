using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class CAPExtension
{
    public int CAPExtensionID { get; set; }

    public long ServiceRequestID { get; set; }

    public int ExtnCount { get; set; }

    public DateTime RequestDate { get; set; }

    public DateTime? GrantDenyDate { get; set; }

    public DateTime ExtnEndDate { get; set; }

    public string ExtnStatus { get; set; } = null!;

    public string? Reason { get; set; }

    public string CAPStatus { get; set; } = null!;

    public string RequestedBy { get; set; } = null!;

    public string? ApprovedBy { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
