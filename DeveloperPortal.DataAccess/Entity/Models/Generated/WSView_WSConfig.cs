using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WSView_WSConfig
{
    public int Id { get; set; }

    public int WSTypeId { get; set; }

    public string WSUrl { get; set; } = null!;

    public string? SecurityToken { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<WSDetailView_ColumnConfig> WSDetailView_ColumnConfigs { get; set; } = new List<WSDetailView_ColumnConfig>();

    public virtual ICollection<WSDetailView_DisplayConfig> WSDetailView_DisplayConfigs { get; set; } = new List<WSDetailView_DisplayConfig>();

    public virtual ICollection<WSGridView_ColumnConfig> WSGridView_ColumnConfigs { get; set; } = new List<WSGridView_ColumnConfig>();

    public virtual ICollection<WSGridView_DisplayConfig> WSGridView_DisplayConfigs { get; set; } = new List<WSGridView_DisplayConfig>();

    public virtual WSView_WSType WSType { get; set; } = null!;
}
