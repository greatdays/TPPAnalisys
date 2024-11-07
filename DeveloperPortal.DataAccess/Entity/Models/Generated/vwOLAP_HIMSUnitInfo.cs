using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_HIMSUnitInfo
{
    public string FullProjectNumber { get; set; } = null!;

    public int ProjUniqueID { get; set; }

    public string? APNID { get; set; }

    public int? HSE_ID { get; set; }

    public string? address { get; set; }

    public string? Bedroom { get; set; }

    public string? Percent { get; set; }

    public int TotalUnits { get; set; }

    public int TotalBedrooms { get; set; }

    public int Home { get; set; }

    public int Restrict { get; set; }

    public int bond { get; set; }

    public int? LandUse { get; set; }

    public int CRA_Restrict { get; set; }
}
