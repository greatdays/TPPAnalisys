using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnBgcnonCoveredProperty
{
    public int AssnBgcnonCoveredPropertyId { get; set; }

    public int BackgroundCheckId { get; set; }

    public int NonCoveredProjectSiteId { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual BackgroundCheck BackgroundCheck { get; set; } = null!;

    public virtual NonCoveredProjectSite NonCoveredProjectSite { get; set; } = null!;
}
