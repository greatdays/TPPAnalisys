using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnDocument
{
    public int AssnDocumentID { get; set; }

    public int DocumentID { get; set; }

    public string? ReferenceID { get; set; }

    public string? ReferenceType { get; set; }

    public string? AssociationType { get; set; }

    public DateOnly? AssociatedFrom { get; set; }

    public DateOnly? AssociatedTo { get; set; }

    /// <summary>
    /// Created By
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Created On
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Modified By
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified On
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    public virtual Document Document { get; set; } = null!;
}
