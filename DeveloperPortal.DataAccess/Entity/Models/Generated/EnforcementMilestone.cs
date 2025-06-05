using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class EnforcementMilestone
{
    public int EnforcementMilestoneId { get; set; }

    public int? CaseId { get; set; }

    public DateOnly? EnforcementCaseOpenDate { get; set; }

    public DateOnly? OrderToComplyIssueDate { get; set; }

    public DateOnly? MailedOrdeToComply { get; set; }

    public DateOnly? ComplianceDueDate { get; set; }

    public string? Rcapcorrections { get; set; }

    public DateOnly? ExtensionToComplyDueDate { get; set; }

    public string? SubsequentActions { get; set; }

    public string? ResponsibleCityStaff { get; set; }

    public DateOnly? CityCertificationIssuedDate { get; set; }

    public DateOnly? EnforcementCaseClosedDate { get; set; }

    public bool ComplianceAchieved { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? CommentsConcerningEnforcement { get; set; }

    public string? DeliveryConfirmationInformation { get; set; }

    public DateOnly? OrderToComplyDueDate { get; set; }

    public DateOnly? OrderToComplyAchievedDate { get; set; }

    public int? LutCloseReasonId { get; set; }

    public string? OtherCloseReason { get; set; }

    public DateOnly? DatePolicyComplianceDecertified { get; set; }

    public DateOnly? DatePolicyCertificationReIssued { get; set; }

    public DateOnly? EnfComplianceAchievedDate { get; set; }

    public DateOnly? ReferredForRemovalDate { get; set; }

    public DateOnly? ReferredToCityAttorneyDate { get; set; }

    public DateOnly? RevisedOrderToComplyDueDate { get; set; }

    public virtual Case? Case { get; set; }

    public virtual LutCloseReason? LutCloseReason { get; set; }
}
