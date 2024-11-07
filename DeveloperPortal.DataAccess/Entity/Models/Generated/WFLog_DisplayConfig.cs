using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WFLog_DisplayConfig
{
    public int Id { get; set; }

    public int WFDefinitionID { get; set; }

    public string Name { get; set; } = null!;

    public string LogGroupedBy { get; set; } = null!;

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual WF_Definition WFDefinition { get; set; } = null!;
}
