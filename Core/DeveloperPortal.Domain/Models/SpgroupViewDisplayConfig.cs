using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class SpgroupViewDisplayConfig
{
    public int Id { get; set; }

    public int SpconfigId { get; set; }

    public string Name { get; set; } = null!;

    public string ParamNamenValue { get; set; } = null!;

    public int NoOfViewColumns { get; set; }

    public bool? IsCollapsed { get; set; }

    public string? GroupColumnName { get; set; }

    public string? LabelColumnName { get; set; }

    public string? ValueColumnName { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual SpviewSpconfig Spconfig { get; set; } = null!;

    public virtual ICollection<SpgroupViewColumnConfig> SpgroupViewColumnConfigs { get; set; } = new List<SpgroupViewColumnConfig>();
}
