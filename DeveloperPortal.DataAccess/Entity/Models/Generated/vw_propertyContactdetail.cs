using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vw_propertyContactdetail
{
    public long ServiceRequestID { get; set; }

    public string ContactType { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactCompany { get; set; }

    public int LutContactTypeID { get; set; }
}
