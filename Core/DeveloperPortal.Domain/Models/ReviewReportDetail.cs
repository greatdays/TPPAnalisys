using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class ReviewReportDetail
{
    public int ReviewReportDetailId { get; set; }

    public long? ServiceRequestId { get; set; }

    public DateTime? ReportDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public DateTime? ReportDueDate { get; set; }

    public DateTime? ReviewDate { get; set; }

    public string? ProjectType { get; set; }

    public string? Analyst { get; set; }

    public string? Supervisor { get; set; }

    public bool? IsFollowup { get; set; }

    public int? ReminderDays { get; set; }

    public bool? IsAuditComplete { get; set; }

    public DateTime? ReportSentDate { get; set; }

    public DateTime? ActionDueDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<ReviewReportItem> ReviewReportItems { get; set; } = new List<ReviewReportItem>();

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
