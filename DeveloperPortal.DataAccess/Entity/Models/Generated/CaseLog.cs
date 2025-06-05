using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class CaseLog
{
    /// <summary>
    /// Primary key of the table
    /// </summary>
    public int CaseLogId { get; set; }

    /// <summary>
    /// Case Id
    /// </summary>
    public int CaseId { get; set; }

    /// <summary>
    /// Action taken
    /// </summary>
    public string Action { get; set; } = null!;

    /// <summary>
    /// Previous State
    /// </summary>
    public string? FromState { get; set; }

    /// <summary>
    /// New State
    /// </summary>
    public string ToState { get; set; } = null!;

    /// <summary>
    /// Last Assignee Id
    /// </summary>
    public string? LastAssigneeId { get; set; }

    /// <summary>
    /// New Assignee Id
    /// </summary>
    public string? NewAssigneeId { get; set; }

    /// <summary>
    /// Last Assignee Id
    /// </summary>
    public string? LastAssigneeName { get; set; }

    /// <summary>
    /// New Assignee Id
    /// </summary>
    public string? NewAssigneeName { get; set; }

    /// <summary>
    /// CommentDetails by user
    /// </summary>
    public string? CaseComment { get; set; }

    /// <summary>
    /// WorkLog Created By
    /// </summary>
    public string? WorkLog { get; set; }

    /// <summary>
    /// Created By
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Created On
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Modified By
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified On
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AuditVisitDetail> AuditVisitDetails { get; set; } = new List<AuditVisitDetail>();

    public virtual Case Case { get; set; } = null!;

    public virtual ICollection<QuarterlyReport> QuarterlyReportReviewedCaseLogs { get; set; } = new List<QuarterlyReport>();

    public virtual ICollection<QuarterlyReport> QuarterlyReportSubmittedCaseLogs { get; set; } = new List<QuarterlyReport>();

    public virtual ICollection<CaseComment> Comments { get; set; } = new List<CaseComment>();
}
