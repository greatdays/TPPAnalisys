using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwAAHRGISFeature
{
    public int? ProjectSiteID { get; set; }

    public string? ProjectName { get; set; }

    public string? Address { get; set; }

    public string SearchProperty { get; set; } = null!;

    public bool? IsCoveredProperty { get; set; }

    public decimal? LAT { get; set; }

    public decimal? lon { get; set; }
}
