using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnBackgroundCheck
{
    public int AssnBackgroundCheckID { get; set; }

    public int BackgroundCheckID { get; set; }

    public int PropSnapShotID { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual BackgroundCheck BackgroundCheck { get; set; } = null!;

    public virtual PropSnapshot PropSnapShot { get; set; } = null!;
}
