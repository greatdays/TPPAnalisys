using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class BatchJobDetail
{
    public int BatchJobDetailId { get; set; }

    public int BatchJobId { get; set; }

    public int? ProjectSiteId { get; set; }

    public int? ProjUniqueId { get; set; }

    public int LutBatchStatusId { get; set; }

    public int? DocTemplateId { get; set; }

    public int? DocumentEntityId { get; set; }

    public string? OutputName { get; set; }

    public string? MailToFirstName { get; set; }

    public string? MailToLastName { get; set; }

    public string? MailToAddress { get; set; }

    public string? MailToEmail { get; set; }

    public string? RefKeyName1 { get; set; }

    public string? RefKeyValue1 { get; set; }

    public string? RefKeyName2 { get; set; }

    public string? RefKeyValue2 { get; set; }

    public string? RefKeyName3 { get; set; }

    public string? RefKeyValue3 { get; set; }

    public int? OwnerContactHistoryId { get; set; }

    public int? PmcontactHistoryId { get; set; }

    public int? NotificationTemplateId { get; set; }

    public int? NotificationLogsId { get; set; }

    public string? Comment { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowId { get; set; }

    public string? Attributes { get; set; }

    public virtual BatchJob BatchJob { get; set; } = null!;

    public virtual LutBatchStatus LutBatchStatus { get; set; } = null!;

    public virtual NotificationLog? NotificationLogs { get; set; }

    public virtual NotificationTemplate? NotificationTemplate { get; set; }
}
