using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SpgridViewColumnConfig
{
    public int Id { get; set; }

    public int DisplayConfigId { get; set; }

    /// <summary>
    /// Reference to SPView_SPConfiguration
    /// </summary>
    public int SpconfigId { get; set; }

    public string ColumnName { get; set; } = null!;

    public string? DisplayName { get; set; }

    public int? ViewOrder { get; set; }

    public bool? IsVisible { get; set; }

    public bool? IsExport { get; set; }

    public string? Link { get; set; }

    public string? Target { get; set; }

    public bool? IsSortableColumn { get; set; }

    public virtual SpgridViewDisplayConfig DisplayConfig { get; set; } = null!;

    public virtual SpviewSpconfig Spconfig { get; set; } = null!;
}
