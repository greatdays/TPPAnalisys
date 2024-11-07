using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SPGroupView_DisplayConfig
{
    public int Id { get; set; }

    public int SPConfigId { get; set; }

    public string Name { get; set; } = null!;

    public string ParamNamenValue { get; set; } = null!;

    public int NoOfViewColumns { get; set; }

    public bool? IsCollapsed { get; set; }

    public string? GroupColumnName { get; set; }

    public string? LabelColumnName { get; set; }

    public string? ValueColumnName { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual SPView_SPConfig SPConfig { get; set; } = null!;

    public virtual ICollection<SPGroupView_ColumnConfig> SPGroupView_ColumnConfigs { get; set; } = new List<SPGroupView_ColumnConfig>();
}
