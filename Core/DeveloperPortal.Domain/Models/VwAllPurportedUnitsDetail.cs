using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwAllPurportedUnitsDetail
{
    public int? ProjectSiteId { get; set; }

    public string UnitNum { get; set; } = null!;

    public string IsAccessible { get; set; } = null!;

    public string? NoOfBedrooms { get; set; }

    public string AccessibilityFeature { get; set; } = null!;

    public string AffordabilityLevelAmi { get; set; } = null!;

    public string FundingRestriction { get; set; } = null!;

    public string ProgramEligibility { get; set; } = null!;

    public bool IsCes { get; set; }

    public bool OccupantDisabled { get; set; }

    public bool LeaseAddendum { get; set; }

    public DateTime? LeaseAddendumExecutedDate { get; set; }

    public DateTime? MoveInDate { get; set; }
}
