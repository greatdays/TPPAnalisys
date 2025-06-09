using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwAcHpdataForHhh
{
    public string? Himsnumber { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyAddress { get; set; }

    public string CurrentlyOccupiedOrNotOccupied { get; set; } = null!;

    public string SiteVisitDate { get; set; } = null!;

    public DateTime? PolicyComplianceReviewDate { get; set; }

    public string? PropertyManagementPlanPmpUpdated2020 { get; set; }

    public DateOnly? DateCityCertificationIssued { get; set; }
}
