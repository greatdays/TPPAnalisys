using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnBackgroundCheck
{
    public int AssnBackgroundCheckId { get; set; }

    public int BackgroundCheckId { get; set; }

    public int PropSnapShotId { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual BackgroundCheck BackgroundCheck { get; set; } = null!;

    public virtual PropSnapshot PropSnapShot { get; set; } = null!;
}
