using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AccessLog
{
    public int AccessLogID { get; set; }

    public string? AppKey { get; set; }

    public string? UserName { get; set; }

    public string? LogonStatus { get; set; }

    public DateTime? LastLogOn { get; set; }

    public string? LogonData { get; set; }
}
