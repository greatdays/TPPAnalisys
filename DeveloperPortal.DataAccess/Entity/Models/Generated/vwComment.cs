using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwComment
{
    public int CommentId { get; set; }

    public string ReferenceId { get; set; } = null!;

    public string ReferenceType { get; set; } = null!;

    public string CommentText { get; set; } = null!;

    public bool? IsInternal { get; set; }

    public bool? IsWorklog { get; set; }

    public string? Jsonattribute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string CreatedUserName { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}
