using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SPGroupView_ColumnConfig
{
    public int Id { get; set; }

    public int DisplayConfigId { get; set; }

    public int SPConfigId { get; set; }

    public string ColumnName { get; set; } = null!;

    public string? DisplayName { get; set; }

    public int? ViewOrder { get; set; }

    public bool? IsVisible { get; set; }

    public string? Link { get; set; }

    public string? Target { get; set; }

    public virtual SPGroupView_DisplayConfig DisplayConfig { get; set; } = null!;

    public virtual SPView_SPConfig SPConfig { get; set; } = null!;
}
