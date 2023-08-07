using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class WsgridViewColumnConfig
{
    public int Id { get; set; }

    public int? WsdisplayConfigId { get; set; }

    public int? WsconfigId { get; set; }

    public string ColumnName { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public int? ViewOrder { get; set; }

    public bool IsVisible { get; set; }

    public string Link { get; set; } = null!;

    public string LinkTarget { get; set; } = null!;

    public bool? IsSortable { get; set; }

    public string SortingType { get; set; } = null!;

    public string? SortingDir { get; set; }

    public string DataType { get; set; } = null!;

    public string DataFormat { get; set; } = null!;

    public string Alignment { get; set; } = null!;

    public virtual WsviewWsconfig? Wsconfig { get; set; }

    public virtual WsgridViewDisplayConfig? WsdisplayConfig { get; set; }
}
