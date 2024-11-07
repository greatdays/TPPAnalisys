using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnBGCNonCoveredProperty
{
    public int AssnBGCNonCoveredPropertyID { get; set; }

    public int BackgroundCheckID { get; set; }

    public int NonCoveredProjectSiteID { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual BackgroundCheck BackgroundCheck { get; set; } = null!;

    public virtual NonCoveredProjectSite NonCoveredProjectSite { get; set; } = null!;
}
