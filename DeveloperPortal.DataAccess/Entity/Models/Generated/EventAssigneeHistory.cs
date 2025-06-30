using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class EventAssigneeHistory
{
    public int EventHistoryId { get; set; }

    public string AssigneeName { get; set; } = null!;

    public virtual EventHistory EventHistory { get; set; } = null!;
}
