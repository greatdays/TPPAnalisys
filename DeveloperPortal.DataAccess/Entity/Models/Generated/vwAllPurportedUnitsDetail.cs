using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwAllPurportedUnitsDetail
{
    public int? ProjectSiteID { get; set; }

    public string UnitNum { get; set; } = null!;

    public string IsAccessible { get; set; } = null!;

    public string? No__of_Bedrooms { get; set; }

    public string Accessibility_Feature { get; set; } = null!;

    public string Affordability_Level_AMI { get; set; } = null!;

    public string Funding_Restriction { get; set; } = null!;

    public string Program_Eligibility { get; set; } = null!;

    public bool IsCES { get; set; }

    public bool Occupant_Disabled { get; set; }

    public bool Lease_Addendum { get; set; }

    public DateOnly? LeaseAddendumExecutedDate { get; set; }

    public DateOnly? Move_In_Date { get; set; }
}
