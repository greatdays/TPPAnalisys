using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// This table holds information about different view configuration for all the controls. Every entry is an unique view which can be rendered on any tab.
/// </summary>
public partial class ControlViewMaster
{
    /// <summary>
    /// Primary Key of the table.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Control ID connects to Control Master. 
    /// </summary>
    public int ControlId { get; set; }

    /// <summary>
    /// This Name will be in sync with specific control&apos;s View Config Name. This is a redundnat field copied explicitly to make Tab &amp; View Config assignment easy.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Name or title to be displayed during rendering of this control. If not specified, blank title will be displayed.
    /// </summary>
    public string? DisplayName { get; set; }

    public string? Comments { get; set; }

    public int? LinkDisplayConfigId { get; set; }

    public int? SPDetailDisplayConfigId { get; set; }

    public int? SPGridDisplayConfigId { get; set; }

    public int? SPMatrixDisplayConfigId { get; set; }

    public int? NewsDisplayConfigId { get; set; }

    public int? CustomDisplayConfigId { get; set; }

    public int? WFNavigationDisplayConfigId { get; set; }

    public int? WFLogDisplayConfigId { get; set; }

    public int? SPGroupDisplayConfigId { get; set; }

    public int? WSGridViewDisplayConfigId { get; set; }

    public int? WSDetailDisplayConfigId { get; set; }

    public string? JsonConfig { get; set; }

    public virtual ControlMaster Control { get; set; } = null!;

    public virtual Custom_DisplayConfig? CustomDisplayConfig { get; set; }

    public virtual Links_DisplayConfig? LinkDisplayConfig { get; set; }

    public virtual News_DisplayConfig? NewsDisplayConfig { get; set; }

    public virtual SPDetailView_DisplayConfig? SPDetailDisplayConfig { get; set; }

    public virtual SPGridView_DisplayConfig? SPGridDisplayConfig { get; set; }

    public virtual SPGroupView_DisplayConfig? SPGroupDisplayConfig { get; set; }

    public virtual SPMatrixView_DisplayConfig? SPMatrixDisplayConfig { get; set; }

    public virtual ICollection<TabControlViewMap> TabControlViewMaps { get; set; } = new List<TabControlViewMap>();

    public virtual WFLog_DisplayConfig? WFLogDisplayConfig { get; set; }

    public virtual WFNavigation_DisplayConfig? WFNavigationDisplayConfig { get; set; }

    public virtual WSDetailView_DisplayConfig? WSDetailDisplayConfig { get; set; }

    public virtual WSGridView_DisplayConfig? WSGridViewDisplayConfig { get; set; }
}
