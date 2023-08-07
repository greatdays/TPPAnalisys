using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutProjectSiteStatus
{
    /// <summary>
    /// Primary Key Identity column for the Holiday table
    /// </summary>
    public int LutProjectSiteStatusId { get; set; }

    /// <summary>
    /// Description of status
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// 1 = is covered property
    /// </summary>
    public bool? IsCoveredProperty { get; set; }

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

    public virtual ICollection<ProjectSite> ProjectSites { get; set; } = new List<ProjectSite>();
}
