using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnComment
{
    public int CommentId { get; set; }

    public string ReferenceId { get; set; } = null!;

    public string ReferenceType { get; set; } = null!;

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

    public virtual Comment Comment { get; set; } = null!;
}
