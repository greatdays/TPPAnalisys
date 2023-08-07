using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class EnforcementMilestone
{
    public int EnforcementMilestoneId { get; set; }

    public int? CaseId { get; set; }

    public DateTime? EnforcementCaseOpenDate { get; set; }

    public DateTime? OrderToComplyIssueDate { get; set; }

    public DateTime? MailedOrdeToComply { get; set; }

    public DateTime? ComplianceDueDate { get; set; }

    public string? Rcapcorrections { get; set; }

    public DateTime? ExtensionToComplyDueDate { get; set; }

    public string? SubsequentActions { get; set; }

    public string? ResponsibleCityStaff { get; set; }

    public DateTime? CityCertificationIssuedDate { get; set; }

    public DateTime? EnforcementCaseClosedDate { get; set; }

    public bool ComplianceAchieved { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? CommentsConcerningEnforcement { get; set; }

    public string? DeliveryConfirmationInformation { get; set; }

    public DateTime? OrderToComplyDueDate { get; set; }

    public DateTime? OrderToComplyAchievedDate { get; set; }

    public int? LutCloseReasonId { get; set; }

    public string? OtherCloseReason { get; set; }

    public DateTime? DatePolicyComplianceDecertified { get; set; }

    public DateTime? DatePolicyCertificationReIssued { get; set; }

    public DateTime? EnfComplianceAchievedDate { get; set; }

    public DateTime? ReferredForRemovalDate { get; set; }

    public DateTime? ReferredToCityAttorneyDate { get; set; }

    public DateTime? RevisedOrderToComplyDueDate { get; set; }

    public virtual Case? Case { get; set; }

    public virtual LutCloseReason? LutCloseReason { get; set; }
}
