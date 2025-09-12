using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnFolder
{
    public int AssnFolderId { get; set; }

    public int FolderId { get; set; }

    public int ProjectId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ReferenceId { get; set; }

    public string? ReferenceType { get; set; }

    public virtual Folder Folder { get; set; } = null!;
}
