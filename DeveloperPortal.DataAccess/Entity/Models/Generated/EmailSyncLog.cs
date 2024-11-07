using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class EmailSyncLog
{
    public int EmailSyncLogID { get; set; }

    public string IdentifierType { get; set; } = null!;

    public int IdentifierID { get; set; }

    public string MailType { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}
