using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class EventConfiguration
{
    public int Id { get; set; }

    public string? ConfigType { get; set; }

    public string? ConfigJson { get; set; }
}
