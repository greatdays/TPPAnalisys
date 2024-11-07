using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WSView_WSType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsObsolete { get; set; }

    public virtual ICollection<WSView_WSConfig> WSView_WSConfigs { get; set; } = new List<WSView_WSConfig>();
}
