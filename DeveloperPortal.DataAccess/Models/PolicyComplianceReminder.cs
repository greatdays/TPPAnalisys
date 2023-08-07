using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class PolicyComplianceReminder
{
    public int PolicyComplianceReminderId { get; set; }

    public long ServiceRequestId { get; set; }

    public string? ReminderLog { get; set; }

    public int ReminderDueDays { get; set; }

    public DateTime ReminderStartDate { get; set; }

    public DateTime ReminderDueDate { get; set; }

    public string? ReminderSetBy { get; set; }

    public DateTime? ReminderSetOn { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifedBy { get; set; } = null!;

    public Guid RowId { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
