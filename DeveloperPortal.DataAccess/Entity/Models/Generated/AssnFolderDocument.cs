using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnFolderDocument
{
    public int AssnFolderDocumentId { get; set; }

    public int FolderId { get; set; }

    public int DocumentId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Document Document { get; set; } = null!;
}
