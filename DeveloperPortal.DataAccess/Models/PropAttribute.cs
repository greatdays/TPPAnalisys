using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class PropAttribute
{
    public int PropSnapshotId { get; set; }

    public int LutPropAttributeId { get; set; }

    public string FlagValue { get; set; } = null!;

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

    public virtual LutPropAttribute LutPropAttribute { get; set; } = null!;

    public virtual PropSnapshot PropSnapshot { get; set; } = null!;
}
