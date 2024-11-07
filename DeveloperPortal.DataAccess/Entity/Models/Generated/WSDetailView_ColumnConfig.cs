using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WSDetailView_ColumnConfig
{
    public int Id { get; set; }

    public int? WSDisplayConfigId { get; set; }

    public int? WSConfigId { get; set; }

    public string ColumnName { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public int? ViewOrder { get; set; }

    public bool IsVisible { get; set; }

    public string Link { get; set; } = null!;

    public string LinkTarget { get; set; } = null!;

    public virtual WSView_WSConfig? WSConfig { get; set; }

    public virtual WSDetailView_DisplayConfig? WSDisplayConfig { get; set; }
}
