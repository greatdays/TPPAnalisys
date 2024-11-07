using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PolicyComplianceReminder
{
    public int PolicyComplianceReminderID { get; set; }

    public long ServiceRequestID { get; set; }

    public string? ReminderLog { get; set; }

    public int ReminderDueDays { get; set; }

    public DateOnly ReminderStartDate { get; set; }

    public DateOnly ReminderDueDate { get; set; }

    public string? ReminderSetBy { get; set; }

    public DateOnly? ReminderSetOn { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifedBy { get; set; } = null!;

    public Guid RowID { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
