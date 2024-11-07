using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_PolicyCaseDetail
{
    public long? rn { get; set; }

    public int? ProjectSiteID { get; set; }

    public string status { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int? ReviewReportDetailID { get; set; }

    public long ServiceRequestID { get; set; }

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
