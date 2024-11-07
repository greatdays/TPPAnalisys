using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// TMS document word Template table
/// </summary>
public partial class DocTemplate
{
    /// <summary>
    /// Primary Key Identity column for the DocTemplate table
    /// </summary>
    public int DocTemplateID { get; set; }

    /// <summary>
    /// Type of TMS document
    /// </summary>
    public int CfgDocumentID { get; set; }

    /// <summary>
    /// Uploaded MS Word template
    /// </summary>
    public string? FormTemplate { get; set; }

    /// <summary>
    /// delete flag
    /// </summary>
    public bool FlgDeleted { get; set; }

    /// <summary>
    /// form effective date
    /// </summary>
    public DateTime? EffectiveDate { get; set; }

    /// <summary>
    /// form expire date
    /// </summary>
    public DateTime? ExpireDate { get; set; }

    /// <summary>
    /// Created by date
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Created by Who
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Last Modifed date
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Last modified by
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Unique ID in System
    /// </summary>
    public Guid RowID { get; set; }

    public virtual ICollection<DocumentEntity> DocumentEntities { get; set; } = new List<DocumentEntity>();
}
