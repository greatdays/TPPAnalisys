using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class TabControlViewMap
{
    /// <summary>
    /// Primary Key of the table.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// This ID represents Tab on which associated control will be rendered. It connects to Tab Master.
    /// </summary>
    public int TabId { get; set; }

    /// <summary>
    /// This ID will connect to Contro View Master to fetch the associated Control with specific View Configuration.
    /// </summary>
    public int ControlViewId { get; set; }

    /// <summary>
    /// Optional Parameter to specify the locatin where control should be rendered. This should be in sync with sections on Tab.
    /// </summary>
    public string? RenderSection { get; set; }

    public int? ViewOrder { get; set; }

    public virtual ControlViewMaster ControlView { get; set; } = null!;

    public virtual TabMaster Tab { get; set; } = null!;

    public virtual ICollection<RoleMaster> Roles { get; set; } = new List<RoleMaster>();
}
