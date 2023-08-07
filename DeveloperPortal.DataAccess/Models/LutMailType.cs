using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutMailType
{
    public int LutMailTypeId { get; set; }

    public string MailType { get; set; } = null!;

    public int SortOrder { get; set; }

    public bool IsAbsolute { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<EmailLog> EmailLogs { get; set; } = new List<EmailLog>();
}
