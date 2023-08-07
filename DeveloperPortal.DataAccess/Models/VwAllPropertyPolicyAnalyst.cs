using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwAllPropertyPolicyAnalyst
{
    public int PropSnapshotId { get; set; }

    public int ProjectSiteId { get; set; }

    public string? FileNumber { get; set; }

    public string? PropertyName { get; set; }

    public string? AssigneeName { get; set; }

    public string? Email { get; set; }
}
