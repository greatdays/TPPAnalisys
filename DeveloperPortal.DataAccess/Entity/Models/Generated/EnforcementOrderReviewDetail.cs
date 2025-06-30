using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class EnforcementOrderReviewDetail
{
    public int EnforcementOrderReviewDetailId { get; set; }

    public long? ServiceRequestId { get; set; }

    public DateOnly? AdoptionDate { get; set; }

    public DateOnly? CapissuedDate { get; set; }

    public DateOnly? CorrectiveActionPlanDate { get; set; }

    public DateOnly? OrderToComplyDueDate { get; set; }

    public string? OrderToComplyObligation { get; set; }

    public DateOnly? ComplianceDeadlineDate { get; set; }

    public DateOnly? RegAgreementExecutionDate { get; set; }

    public int? LutTemplateId { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateOnly? OrderToComplyIssueDate { get; set; }

    public int? LutWithdrawReasonId { get; set; }

    public string? RecorderNo { get; set; }

    public DateOnly? RecordedDate { get; set; }

    public virtual LutTemplate1? LutTemplate { get; set; }

    public virtual LutWithdrawReason? LutWithdrawReason { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
