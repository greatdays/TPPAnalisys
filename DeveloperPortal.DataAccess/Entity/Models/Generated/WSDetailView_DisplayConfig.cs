using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WSDetailView_DisplayConfig
{
    public int Id { get; set; }

    public int WSTypeId { get; set; }

    public int? WSConfigId { get; set; }

    public string Name { get; set; } = null!;

    public string ParamNamenValue { get; set; } = null!;

    public int NoOfViewColumns { get; set; }

    public bool IsCollapsed { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual WSView_WSConfig? WSConfig { get; set; }

    public virtual ICollection<WSDetailView_ColumnConfig> WSDetailView_ColumnConfigs { get; set; } = new List<WSDetailView_ColumnConfig>();
}
