using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Document
{
    public int DocumentID { get; set; }

    public string Name { get; set; } = null!;

    public string Link { get; set; } = null!;

    public string FileSize { get; set; } = null!;

    public string? OtherDocumentType { get; set; }

    public DateTime? ExpDate { get; set; }

    public string? Comment { get; set; }

    public string? Attributes { get; set; }

    public int? DocumentTemplateID { get; set; }

    public string? DocumentNum { get; set; }

    public string? DocumentEntity { get; set; }

    public bool? IsCurrent { get; set; }

    public bool? IsDeleted { get; set; }

    public string? ServiceTrackingID { get; set; }

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

    public virtual ICollection<AssnDocument> AssnDocuments { get; set; } = new List<AssnDocument>();

    public virtual DocumentTemplate? DocumentTemplate { get; set; }
}
