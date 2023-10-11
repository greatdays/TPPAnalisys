using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapHimsunitInfo
{
    public string FullProjectNumber { get; set; } = null!;

    public int ProjUniqueId { get; set; }

    public string? Apnid { get; set; }

    public int? HseId { get; set; }

    public string? Address { get; set; }

    public string? Bedroom { get; set; }

    public string? Percent { get; set; }

    public int TotalUnits { get; set; }

    public int TotalBedrooms { get; set; }

    public int Home { get; set; }

    public int Restrict { get; set; }

    public int Bond { get; set; }

    public int? LandUse { get; set; }

    public int CraRestrict { get; set; }
}
