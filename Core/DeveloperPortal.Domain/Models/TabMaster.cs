using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// This table holds information about all the tabs within an application. Any tab that needs to render common control has to be added to this table.
/// </summary>
public partial class TabMaster
{
    public int Id { get; set; }

    public int? TemplateId { get; set; }

    public int ApplicationId { get; set; }

    public string? TabName { get; set; }

    public string? Description { get; set; }

    public int? ParentTabId { get; set; }

    public int? ReferenceId { get; set; }

    public bool? IsVisible { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsClickable { get; set; }

    public int? ViewOrder { get; set; }

    public string? DisplayName { get; set; }

    public bool? ShowTitle { get; set; }

    public bool? IsLoginRequired { get; set; }

    public virtual ApplicationMaster Application { get; set; } = null!;

    public virtual ICollection<TabMaster> InverseParentTab { get; set; } = new List<TabMaster>();

    public virtual ICollection<TabMaster> InverseReference { get; set; } = new List<TabMaster>();

    public virtual TabMaster? ParentTab { get; set; }

    public virtual TabMaster? Reference { get; set; }

    public virtual ICollection<TabControlViewMap> TabControlViewMaps { get; set; } = new List<TabControlViewMap>();

    public virtual TemplateMaster? Template { get; set; }

    public virtual ICollection<RoleMaster> Roles { get; set; } = new List<RoleMaster>();
}
