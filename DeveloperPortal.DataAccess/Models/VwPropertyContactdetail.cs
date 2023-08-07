using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwPropertyContactdetail
{
    public long ServiceRequestId { get; set; }

    public string ContactType { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactCompany { get; set; }

    public int LutContactTypeId { get; set; }
}
