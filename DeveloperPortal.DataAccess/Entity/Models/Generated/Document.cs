using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Document
{
    public int DocumentId { get; set; }

    public string Name { get; set; } = null!;

    public string Link { get; set; } = null!;

    public string FileSize { get; set; } = null!;

    public string? OtherDocumentType { get; set; }

    public DateTime? ExpDate { get; set; }

    public string? Comment { get; set; }

    public string? Attributes { get; set; }

    public int? DocumentTemplateId { get; set; }

    public string? DocumentNum { get; set; }

    public string? DocumentEntity { get; set; }

    public bool? IsCurrent { get; set; }

    public bool? IsDeleted { get; set; }

    public string? ServiceTrackingId { get; set; }

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

    public int? DocumentCategoryId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<AssnDocument> AssnDocuments { get; set; } = new List<AssnDocument>();

    public virtual ICollection<AssnFolderDocument> AssnFolderDocuments { get; set; } = new List<AssnFolderDocument>();

    public virtual LutDocumentCategory? DocumentCategory { get; set; }

    public virtual DocumentTemplate? DocumentTemplate { get; set; }

    public virtual ICollection<FundingSource> FundingSources { get; set; } = new List<FundingSource>();
}
