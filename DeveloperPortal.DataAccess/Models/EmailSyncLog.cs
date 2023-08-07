using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class EmailSyncLog
{
    public int EmailSyncLogId { get; set; }

    public string IdentifierType { get; set; } = null!;

    public int IdentifierId { get; set; }

    public string MailType { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}
