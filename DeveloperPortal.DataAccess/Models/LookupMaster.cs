using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LookupMaster
{
    public int LookupMasterId { get; set; }

    public string? SchemaName { get; set; }

    public string? TableName { get; set; }

    public bool IsLocked { get; set; }

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

    public virtual ICollection<RoleMaster> Roles { get; set; } = new List<RoleMaster>();
}
