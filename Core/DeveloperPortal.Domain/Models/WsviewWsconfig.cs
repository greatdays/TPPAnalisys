using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class WsviewWsconfig
{
    public int Id { get; set; }

    public int WstypeId { get; set; }

    public string Wsurl { get; set; } = null!;

    public string? SecurityToken { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<WsdetailViewColumnConfig> WsdetailViewColumnConfigs { get; set; } = new List<WsdetailViewColumnConfig>();

    public virtual ICollection<WsdetailViewDisplayConfig> WsdetailViewDisplayConfigs { get; set; } = new List<WsdetailViewDisplayConfig>();

    public virtual ICollection<WsgridViewColumnConfig> WsgridViewColumnConfigs { get; set; } = new List<WsgridViewColumnConfig>();

    public virtual ICollection<WsgridViewDisplayConfig> WsgridViewDisplayConfigs { get; set; } = new List<WsgridViewDisplayConfig>();

    public virtual WsviewWstype Wstype { get; set; } = null!;
}
