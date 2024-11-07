using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwComment
{
    public int CommentID { get; set; }

    public string ReferenceID { get; set; } = null!;

    public string ReferenceType { get; set; } = null!;

    public string CommentText { get; set; } = null!;

    public bool? IsInternal { get; set; }

    public bool? IsWorklog { get; set; }

    public string? JSONAttribute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string CreatedUserName { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}
