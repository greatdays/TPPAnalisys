using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutProjectSiteStatusDisplayName
{
    public int LutProjectSiteStatusDisplayNameId { get; set; }

    public string ProjectSiteStatus { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

    public string? DisplayIconColor { get; set; }
}
