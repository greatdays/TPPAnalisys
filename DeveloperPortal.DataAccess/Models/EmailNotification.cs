using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class EmailNotification
{
    public int EmailNotificationId { get; set; }

    public string MailTo { get; set; } = null!;

    public string? MailCc { get; set; }

    public string? MailBcc { get; set; }

    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string? Error { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? SentOn { get; set; }

    public short AttemptCnt { get; set; }

    public string? IdentifierType { get; set; }

    public long? IdentifierId { get; set; }

    public bool? IsSendInstantly { get; set; }
}
