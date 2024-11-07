using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class EventReminder
{
    public int EventReminderID { get; set; }

    public int EventID { get; set; }

    public int LutEventReminderTypeID { get; set; }

    public DateTime ReminderTime { get; set; }

    public int? NotificationTemplateID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual LutEventReminderType LutEventReminderType { get; set; } = null!;
}
