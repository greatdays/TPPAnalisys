using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// Lookup table for PnCProject.
/// Sourec of PnC Project
/// </summary>
public partial class LutProjSource
{
    /// <summary>
    /// Primary Key Identity column for the LutProjSource table.  A code represent source of PnC Project
    /// </summary>
    public string LutProjSourceCd { get; set; } = null!;

    /// <summary>
    /// Description for LutProjSourceCD
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Short form for the code
    /// </summary>
    public string? ShortCode { get; set; }

    /// <summary>
    /// long form for the code
    /// </summary>
    public string? LongCode { get; set; }

    /// <summary>
    /// The settlement agreement version number
    /// </summary>
    public string? Saversion { get; set; }

    /// <summary>
    /// Exhibit from settlement agreement
    /// </summary>
    public string? Exhibit { get; set; }

    /// <summary>
    /// Sequence for report sorting
    /// </summary>
    public int? OrderSeq { get; set; }

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
    public Guid RowId { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
