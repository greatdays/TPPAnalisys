using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WsdetailViewDisplayConfig
{
    public int Id { get; set; }

    public int WstypeId { get; set; }

    public int? WsconfigId { get; set; }

    public string Name { get; set; } = null!;

    public string ParamNamenValue { get; set; } = null!;

    public int NoOfViewColumns { get; set; }

    public bool IsCollapsed { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual WsviewWsconfig? Wsconfig { get; set; }

    public virtual ICollection<WsdetailViewColumnConfig> WsdetailViewColumnConfigs { get; set; } = new List<WsdetailViewColumnConfig>();
}
