using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ContactNameChangeLog
{
    public int ContactNameChangeLogId { get; set; }

    public int ContactIdentifierId { get; set; }

    public string OldFirstName { get; set; } = null!;

    public string? OldMiddleName { get; set; }

    public string OldLastName { get; set; } = null!;

    public string? OldReason { get; set; }

    public string NewFirstName { get; set; } = null!;

    public string? NewMiddleName { get; set; }

    public string NewLastName { get; set; } = null!;

    public string? NewReason { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ContactIdentifier ContactIdentifier { get; set; } = null!;
}
