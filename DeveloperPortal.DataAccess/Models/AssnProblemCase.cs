using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnProblemCase
{
    public int AssnProblemCaseId { get; set; }

    public int CaseId { get; set; }

    public string CommentText { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual Case Case { get; set; } = null!;
}
