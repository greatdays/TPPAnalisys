using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapPolicyCaseDetail
{
    public long? Rn { get; set; }

    public int? ProjectSiteId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int? ReviewReportDetailId { get; set; }

    public long ServiceRequestId { get; set; }

    public DateOnly? Reportdate { get; set; }

    public string? ProjectType { get; set; }

    public string? Analyst { get; set; }

    public DateOnly? ReportDueDate { get; set; }

    public DateOnly? ActionDueDate { get; set; }

    public DateOnly? ReportSentDate { get; set; }

    public DateOnly? CaseReminderDue { get; set; }

    public string? CheckListItems { get; set; }

    public string? ReportItem { get; set; }

    public string? ReportDescription { get; set; }
}
