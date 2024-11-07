using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WF_Definition
{
    public int Id { get; set; }

    public int? ApplicationId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool IsObsolete { get; set; }

    public string? DiagramData { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ApplicationMaster? Application { get; set; }

    public virtual ICollection<CaseType> CaseTypes { get; set; } = new List<CaseType>();

    public virtual ICollection<WFLog_DisplayConfig> WFLog_DisplayConfigs { get; set; } = new List<WFLog_DisplayConfig>();

    public virtual ICollection<WFNavigation_DisplayConfig> WFNavigation_DisplayConfigs { get; set; } = new List<WFNavigation_DisplayConfig>();

    public virtual ICollection<WF_Action> WF_Actions { get; set; } = new List<WF_Action>();

    public virtual ICollection<WF_State> WF_States { get; set; } = new List<WF_State>();
}
