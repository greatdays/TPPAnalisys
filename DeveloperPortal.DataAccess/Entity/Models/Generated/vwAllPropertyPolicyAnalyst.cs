using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwAllPropertyPolicyAnalyst
{
    public int PropSnapshotID { get; set; }

    public int ProjectSiteID { get; set; }

    public string? FileNumber { get; set; }

    public string? PropertyName { get; set; }

    public string? AssigneeName { get; set; }

    public string AssigneeFullName { get; set; } = null!;

    public string? Email { get; set; }
}
