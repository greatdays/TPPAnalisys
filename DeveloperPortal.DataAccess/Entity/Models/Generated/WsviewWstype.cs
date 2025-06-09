using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WsviewWstype
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsObsolete { get; set; }

    public virtual ICollection<WsviewWsconfig> WsviewWsconfigs { get; set; } = new List<WsviewWsconfig>();
}
