using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class RoleMaster
{
    public int Id { get; set; }

    public int? ApplicationId { get; set; }

    public string? Name { get; set; }

    public virtual ApplicationMaster? Application { get; set; }

    public virtual ICollection<WF_ActionViewPermission> WF_ActionViewPermissions { get; set; } = new List<WF_ActionViewPermission>();

    public virtual ICollection<LookupMaster> LookupMasters { get; set; } = new List<LookupMaster>();

    public virtual ICollection<TabControlViewMap> TabControlViews { get; set; } = new List<TabControlViewMap>();

    public virtual ICollection<TabMaster> Tabs { get; set; } = new List<TabMaster>();

    public virtual ICollection<WF_Action> WFActions { get; set; } = new List<WF_Action>();

    public virtual ICollection<WF_Action> WFActionsNavigation { get; set; } = new List<WF_Action>();
}
