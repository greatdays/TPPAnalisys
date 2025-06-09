using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Folder
{
    public int FolderId { get; set; }

    public string Name { get; set; } = null!;

    public string? Comment { get; set; }

    public string? Attributes { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public int? RefFolderId { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnFolder> AssnFolders { get; set; } = new List<AssnFolder>();
}
