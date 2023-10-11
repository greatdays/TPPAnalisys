using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class WsdetailViewColumnConfig
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

    public virtual WsviewWsconfig? Wsconfig { get; set; }

    public virtual WsdetailViewDisplayConfig? WsdisplayConfig { get; set; }
}
