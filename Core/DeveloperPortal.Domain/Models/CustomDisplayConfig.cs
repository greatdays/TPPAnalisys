using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class CustomDisplayConfig
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Area { get; set; }

    public string? Controller { get; set; }

    public string? Action { get; set; }

    public string? Parameters { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();
}
