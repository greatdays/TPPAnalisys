using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class EventAssignee
{
    public int EventID { get; set; }

    public string AssigneeName { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;
}
