using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Account type category
/// </summary>
public partial class LutAccountTypeCategory
{
    /// <summary>
    /// Primary Key Identity column for the LutAccountTypeCategory table
    /// </summary>
    public int LutAccountTypeCategoryId { get; set; }

    /// <summary>
    /// short description for the recrod
    /// </summary>
    public string Category { get; set; } = null!;

    /// <summary>
    /// long description for the record
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 1 = record mark as deleted
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
    public Guid RowId { get; set; }
}
