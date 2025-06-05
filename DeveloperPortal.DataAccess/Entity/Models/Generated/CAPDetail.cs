using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Capdetail
{
    public int CapdetailsId { get; set; }

    public long ServiceRequestId { get; set; }

    public DateTime? ReportDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public string? PolicyAnalyst { get; set; }

    public string? Iepanalyst { get; set; }

    public DateTime? CapsentDate { get; set; }

    public DateTime? CapissueDate { get; set; }

    public DateTime? CapdueDate { get; set; }

    public string? Owner { get; set; }

    public string? Pm { get; set; }

    public string? CapcurrentStatus { get; set; }

    public DateTime? CapcompliedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public DateTime? CapreceivedDate { get; set; }

    public DateTime? CapclosureDate { get; set; }

    public int? LutWithdrawReasonId { get; set; }

    public int? LutCapcloseReasonId { get; set; }

    public string? OtherReason { get; set; }

    public string? Capsummary { get; set; }

    public int? LutCapchecklistItemId { get; set; }

    public virtual ICollection<CapitemDetail> CapitemDetails { get; set; } = new List<CapitemDetail>();

    public virtual LutCapchecklistItem? LutCapchecklistItem { get; set; }

    public virtual LutCapcloseReason? LutCapcloseReason { get; set; }

    public virtual LutWithdrawReason? LutWithdrawReason { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
