using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnTrainingRegistryProjectSite
{
    public int AssnTrainingRegistryProjectSiteId { get; set; }

    public int TrainingRegistryId { get; set; }

    public int ProjectSiteId { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ProjectSite ProjectSite { get; set; } = null!;

    public virtual TrainingRegistry TrainingRegistry { get; set; } = null!;
}
