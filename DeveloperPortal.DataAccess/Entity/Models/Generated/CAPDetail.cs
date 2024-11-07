using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class CAPDetail
{
    public int CAPDetailsID { get; set; }

    public long ServiceRequestID { get; set; }

    public DateTime? ReportDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public string? PolicyAnalyst { get; set; }

    public string? IEPAnalyst { get; set; }

    public DateTime? CAPSentDate { get; set; }

    public DateTime? CAPIssueDate { get; set; }

    public DateTime? CAPDueDate { get; set; }

    public string? Owner { get; set; }

    public string? PM { get; set; }

    public string? CAPCurrentStatus { get; set; }

    public DateTime? CAPCompliedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public DateTime? CAPReceivedDate { get; set; }

    public DateTime? CAPClosureDate { get; set; }

    public int? LutWithdrawReasonId { get; set; }

    public int? LutCAPCloseReasonId { get; set; }

    public string? OtherReason { get; set; }

    public string? CAPSummary { get; set; }

    public virtual ICollection<CAPItemDetail> CAPItemDetails { get; set; } = new List<CAPItemDetail>();

    public virtual LutCAPCloseReason? LutCAPCloseReason { get; set; }

    public virtual LutWithdrawReason? LutWithdrawReason { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
