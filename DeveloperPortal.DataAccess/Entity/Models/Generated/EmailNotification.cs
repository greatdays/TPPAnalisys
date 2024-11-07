using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class EmailNotification
{
    public int EmailNotificationID { get; set; }

    public string MailTo { get; set; } = null!;

    public string? MailCC { get; set; }

    public string? MailBCC { get; set; }

    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string? Error { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? SentOn { get; set; }

    public short AttemptCnt { get; set; }

    public string? IdentifierType { get; set; }

    public long? IdentifierID { get; set; }

    public bool? IsSendInstantly { get; set; }
}
