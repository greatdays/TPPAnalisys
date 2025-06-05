using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class EventNote
{
    public int EventNoteId { get; set; }

    public int EventId { get; set; }

    public string NoteDescription { get; set; } = null!;

    /// <summary>
    /// Record created username.
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Record created date.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Record modified username.
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Record modified date.
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    public virtual Event Event { get; set; } = null!;
}
