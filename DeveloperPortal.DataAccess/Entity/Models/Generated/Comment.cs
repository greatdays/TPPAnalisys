using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Comment
{
    public int CommentID { get; set; }

    public string CommentText { get; set; } = null!;

    public bool? IsInternal { get; set; }

    public bool? IsWorklog { get; set; }

    public string? JSONAttribute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Role { get; set; }

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

    public string? ServiceTrackingID { get; set; }

    public virtual ICollection<AssnComment> AssnComments { get; set; } = new List<AssnComment>();
}
