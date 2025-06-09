using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WfnavigationDisplayConfig
{
    public int Id { get; set; }

    public int WfdefinitionId { get; set; }

    public string Name { get; set; } = null!;

    public string NavigationStyle { get; set; } = null!;

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual WfDefinition Wfdefinition { get; set; } = null!;
}
