using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwAahrgisfeature
{
    public int? ProjectSiteId { get; set; }

    public string? ProjectName { get; set; }

    public string? Address { get; set; }

    public string SearchProperty { get; set; } = null!;

    public bool? IsCoveredProperty { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Lon { get; set; }
}
