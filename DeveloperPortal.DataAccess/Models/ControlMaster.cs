using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// This table holds list of all the controls available in Common Control library. Any new control must be added to this table.
/// </summary>
public partial class ControlMaster
{
    public int Id { get; set; }

    /// <summary>
    /// Name of control
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Description of control
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Name of MVC controller for this control. The name should match exactly as in code. This property will be used to call controller of this Control whereever needed.
    /// </summary>
    public string? Controller { get; set; }

    /// <summary>
    /// Name of Action registered with controller which will return the render view.  The name should match exactly as in code.
    /// </summary>
    public string RenderAction { get; set; } = null!;

    /// <summary>
    /// Name of Action registered with controller which will return the top level manage/configuration view for this control.  The name should match exactly as in code.
    /// </summary>
    public string ManageAction { get; set; } = null!;

    public string? Area { get; set; }

    /// <summary>
    /// Text message to be displayed if no display configuration is done.
    /// </summary>
    public string? NoConfigText { get; set; }

    public string? StaticJsonConfig { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();
}
