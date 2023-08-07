using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// Type of Project from HIMS system.
/// All PnC Project comes from HIMS
/// </summary>
public partial class LutTypeofProject
{
    /// <summary>
    /// Primary Key Identity column for the LutTypeofProject table.  This number match HIMS
    /// </summary>
    public int LutTypeofProjectId { get; set; }

    /// <summary>
    /// description about type of project
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 1 = the course mark as deleted in system.
    /// </summary>
    public bool IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

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
