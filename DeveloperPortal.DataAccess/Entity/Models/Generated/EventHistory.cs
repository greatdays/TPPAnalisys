using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class EventHistory
{
    public int EventHistoryId { get; set; }

    public int EventId { get; set; }

    public DateTime? EventStartOn { get; set; }

    public DateTime? EventEndOn { get; set; }

    public string? EventStatus { get; set; }

    /// <summary>
    /// Created by which user
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Created on which datetime
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Modified by which user
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified on which datetime
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<EventAssigneeHistory> EventAssigneeHistories { get; set; } = new List<EventAssigneeHistory>();
}
