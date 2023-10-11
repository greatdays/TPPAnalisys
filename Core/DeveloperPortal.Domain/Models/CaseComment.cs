using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class CaseComment
{
    public int CommentId { get; set; }

    public string Description { get; set; } = null!;

    public bool? IsDeleted { get; set; }

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

    public virtual ICollection<CaseLog> CaseLogs { get; set; } = new List<CaseLog>();

    public virtual ICollection<Case> Cases { get; set; } = new List<Case>();
}
