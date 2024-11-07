using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnTrainingRegistryProjectSite
{
    public int AssnTrainingRegistryProjectSiteID { get; set; }

    public int TrainingRegistryID { get; set; }

    public int ProjectSiteID { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ProjectSite ProjectSite { get; set; } = null!;

    public virtual TrainingRegistry TrainingRegistry { get; set; } = null!;
}
