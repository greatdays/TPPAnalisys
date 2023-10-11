using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class EnforcementOrderReviewDetail
{
    public int EnforcementOrderReviewDetailId { get; set; }

    public long? ServiceRequestId { get; set; }

    public DateTime? AdoptionDate { get; set; }

    public DateTime? CapissuedDate { get; set; }

    public DateTime? CorrectiveActionPlanDate { get; set; }

    public DateTime? OrderToComplyDueDate { get; set; }

    public string? OrderToComplyObligation { get; set; }

    public DateTime? ComplianceDeadlineDate { get; set; }

    public DateTime? RegAgreementExecutionDate { get; set; }

    public int? LutTemplateId { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? OrderToComplyIssueDate { get; set; }

    public int? LutWithdrawReasonId { get; set; }

    public string? RecorderNo { get; set; }

    public DateTime? RecordedDate { get; set; }

    public virtual LutTemplate1? LutTemplate { get; set; }

    public virtual LutWithdrawReason? LutWithdrawReason { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
