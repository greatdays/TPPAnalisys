using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// document category use for DMS
/// </summary>
public partial class LutDocumentCategory
{
    /// <summary>
    /// Primary Key Identity column for the LutDocumentCategory table
    /// </summary>
    public int LutDocumentCategoryID { get; set; }

    /// <summary>
    /// Main category for the document
    /// </summary>
    public string Category { get; set; } = null!;

    /// <summary>
    /// sub-cateogorty for the document
    /// </summary>
    public string? SubCategory { get; set; }

    /// <summary>
    /// the main key used for this main and sub category
    /// </summary>
    public string ReferenceKey { get; set; } = null!;

    /// <summary>
    /// Description for the record
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 1 = the course mark as deleted in system.
    /// </summary>
    public bool IsDeleted { get; set; }

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
    public DateTime ModifiedOn { get; set; }

    /// <summary>
    /// Last modified by
    /// </summary>
    public string ModifiedBy { get; set; } = null!;

    /// <summary>
    /// Unique ID in System
    /// </summary>
    public Guid RowID { get; set; }

    public bool IsUserCategory { get; set; }

    public string? AccessRole { get; set; }

    public virtual ICollection<AssnDocumentSubCategoryStatus> AssnDocumentSubCategoryStatusDocumentStatuses { get; set; } = new List<AssnDocumentSubCategoryStatus>();

    public virtual ICollection<AssnDocumentSubCategoryStatus> AssnDocumentSubCategoryStatusSubCategories { get; set; } = new List<AssnDocumentSubCategoryStatus>();
}
