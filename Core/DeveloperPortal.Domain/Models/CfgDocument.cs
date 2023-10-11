using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// TMS Document Config table
/// </summary>
public partial class CfgDocument
{
    /// <summary>
    /// Primary Key Identity column for the CfgDocument table
    /// </summary>
    public int CfgDocumentId { get; set; }

    /// <summary>
    /// TMS Document Name
    /// </summary>
    public string DocumentName { get; set; } = null!;

    /// <summary>
    /// Running number configuration
    /// </summary>
    public int? CfgNextRunId { get; set; }

    /// <summary>
    /// Created by date
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Created by Who
    /// </summary>
    public string? CreatedBy { get; set; }

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
    public Guid RowId { get; set; }
}
