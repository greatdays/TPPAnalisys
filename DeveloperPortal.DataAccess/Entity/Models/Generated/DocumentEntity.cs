using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Generate document value (xml)
/// </summary>
public partial class DocumentEntity
{
    /// <summary>
    /// Primary Key Identity column for the DocumentEntity table
    /// </summary>
    public int DocumentEntityId { get; set; }

    /// <summary>
    /// Template being use when generate the record
    /// </summary>
    public int DocTemplateId { get; set; }

    /// <summary>
    /// Document Number for the document
    /// </summary>
    public string? DocumentNum { get; set; }

    /// <summary>
    /// CMS Case ID if workflow applied
    /// </summary>
    public int? CaseId { get; set; }

    /// <summary>
    /// add data for the docuemnt stored in xml
    /// </summary>
    public string DocumentEntity1 { get; set; } = null!;

    /// <summary>
    /// 1 = the latest version of document.  0 = old version
    /// </summary>
    public bool IsCurrent { get; set; }

    /// <summary>
    /// 1 = the record mark as deleted
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Created by date
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Created by Who
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Unique ID in System
    /// </summary>
    public Guid? RowId { get; set; }

    public int? CaseLogId { get; set; }

    public virtual Case? Case { get; set; }

    public virtual DocTemplate DocTemplate { get; set; } = null!;
}
