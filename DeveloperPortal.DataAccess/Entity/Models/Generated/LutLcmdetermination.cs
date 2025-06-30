using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutLcmdetermination
{
    public int LutLcmdeterminationId { get; set; }

    public string? LcmdeterminationType { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<ProjectSiteAttribute> ProjectSiteAttributes { get; set; } = new List<ProjectSiteAttribute>();
}
