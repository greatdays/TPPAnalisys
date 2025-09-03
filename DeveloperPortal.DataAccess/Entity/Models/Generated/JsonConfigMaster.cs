using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class JsonConfigMaster
{
    public int Id { get; set; }

    public string Identifier { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string JsonConfig { get; set; } = null!;
}
