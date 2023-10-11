using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

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

    public int? SpdetailDisplayConfigId { get; set; }

    public int? SpgridDisplayConfigId { get; set; }

    public int? SpmatrixDisplayConfigId { get; set; }

    public int? NewsDisplayConfigId { get; set; }

    public int? CustomDisplayConfigId { get; set; }

    public int? WfnavigationDisplayConfigId { get; set; }

    public int? WflogDisplayConfigId { get; set; }

    public int? SpgroupDisplayConfigId { get; set; }

    public int? WsgridViewDisplayConfigId { get; set; }

    public int? WsdetailDisplayConfigId { get; set; }

    public string? JsonConfig { get; set; }

    public virtual ControlMaster Control { get; set; } = null!;

    public virtual CustomDisplayConfig? CustomDisplayConfig { get; set; }

    public virtual LinksDisplayConfig? LinkDisplayConfig { get; set; }

    public virtual NewsDisplayConfig? NewsDisplayConfig { get; set; }

    public virtual SpdetailViewDisplayConfig? SpdetailDisplayConfig { get; set; }

    public virtual SpgridViewDisplayConfig? SpgridDisplayConfig { get; set; }

    public virtual SpgroupViewDisplayConfig? SpgroupDisplayConfig { get; set; }

    public virtual SpmatrixViewDisplayConfig? SpmatrixDisplayConfig { get; set; }

    public virtual ICollection<TabControlViewMap> TabControlViewMaps { get; set; } = new List<TabControlViewMap>();

    public virtual WflogDisplayConfig? WflogDisplayConfig { get; set; }

    public virtual WfnavigationDisplayConfig? WfnavigationDisplayConfig { get; set; }

    public virtual WsdetailViewDisplayConfig? WsdetailDisplayConfig { get; set; }

    public virtual WsgridViewDisplayConfig? WsgridViewDisplayConfig { get; set; }
}
