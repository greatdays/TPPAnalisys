using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class BatchJobDetailLog
{
    public int BatchJobDetailLogID { get; set; }

    public int BatchJobDetailID { get; set; }

    public int BatchJobID { get; set; }

    public int? ProjectSiteID { get; set; }

    public int? LutBatchStatusID { get; set; }

    public int? DocTemplateID { get; set; }

    public int? DocumentEntityID { get; set; }

    public string? OutputName { get; set; }

    public string? MailToFirstName { get; set; }

    public string? MailToLastName { get; set; }

    public string? MailToAddress { get; set; }

    public string? MailToEmail { get; set; }

    public string? RefKeyName1 { get; set; }

    public string? RefKeyValue1 { get; set; }

    public string? RefKeyName2 { get; set; }

    public string? RefKeyValue2 { get; set; }

    public int? OwnerContactHistoryID { get; set; }

    public int? PMContactHistoryID { get; set; }

    public int? NotificationTemplateID { get; set; }

    public int? NotificationLogsID { get; set; }

    public string? Comment { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime LogOn { get; set; }

    public string LogBy { get; set; } = null!;

    public string? LogHost { get; set; }

    public string? LogApp { get; set; }

    public Guid RowID { get; set; }
}
