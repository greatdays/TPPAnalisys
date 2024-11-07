using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class CCRISdiagram
{
    public string name { get; set; } = null!;

    public int principal_id { get; set; }

    public int diagram_id { get; set; }

    public int? version { get; set; }

    public byte[]? definition { get; set; }
}
