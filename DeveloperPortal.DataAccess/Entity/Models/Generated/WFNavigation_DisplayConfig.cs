using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WFNavigation_DisplayConfig
{
    public int Id { get; set; }

    public int WFDefinitionID { get; set; }

    public string Name { get; set; } = null!;

    public string NavigationStyle { get; set; } = null!;

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual WF_Definition WF_Definition { get; set; } = null!;
}
