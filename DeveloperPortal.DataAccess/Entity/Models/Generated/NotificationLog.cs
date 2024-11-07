using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class NotificationLog
{
    public int Id { get; set; }

    public string? MailFrom { get; set; }

    public string? MailTo { get; set; }

    public string? Subject { get; set; }

    public string? Body { get; set; }

    public string? Status { get; set; }

    public string? Error { get; set; }

    public DateTime? SentOn { get; set; }

    public string? Action { get; set; }

    public string? RefrenceType { get; set; }

    public int? RefrenceId { get; set; }

    public string? MailCC { get; set; }

    public string? MailBCC { get; set; }

    public virtual ICollection<BatchJobDetail> BatchJobDetails { get; set; } = new List<BatchJobDetail>();
}
