using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Event
{
    public int EventId { get; set; }

    public string? Title { get; set; }

    public string? Summary { get; set; }

    public DateOnly? ScheduleDate { get; set; }

    public DateTime? StartOn { get; set; }

    public DateTime? EndOn { get; set; }

    public string? Status { get; set; }

    public string? ReferenceType { get; set; }

    public string? ReferenceId { get; set; }

    public string? ReferenceStatus { get; set; }

    public string? ReferenceApn { get; set; }

    public string? EventLocation { get; set; }

    public int? DueDays { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Attributes { get; set; }

    public virtual ICollection<EventAssignee> EventAssignees { get; set; } = new List<EventAssignee>();

    public virtual ICollection<EventAttendee> EventAttendees { get; set; } = new List<EventAttendee>();

    public virtual ICollection<EventHistory> EventHistories { get; set; } = new List<EventHistory>();

    public virtual ICollection<EventNote> EventNotes { get; set; } = new List<EventNote>();

    public virtual ICollection<EventReminder> EventReminders { get; set; } = new List<EventReminder>();
}
