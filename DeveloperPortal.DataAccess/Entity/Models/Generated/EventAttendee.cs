using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class EventAttendee
{
    public int EventId { get; set; }

    public string AttendeeName { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;
}
