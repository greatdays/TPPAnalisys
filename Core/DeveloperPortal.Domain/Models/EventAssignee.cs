using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class EventAssignee
{
    public int EventId { get; set; }

    public string AssigneeName { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;
}
