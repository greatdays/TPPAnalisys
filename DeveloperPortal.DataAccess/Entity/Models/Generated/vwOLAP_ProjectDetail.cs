using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_ProjectDetail
{
    public int ProjectID { get; set; }

    public string? ProjectName { get; set; }

    public string? FileGroup { get; set; }

    public string? Occupiedstatus { get; set; }

    public string PreSettlementDevelopment { get; set; } = null!;

    public double? AHUPScore { get; set; }

    public int? AHUPProductionScheduleYear { get; set; }

    public bool? ListedOnAHUPProductionSchedule { get; set; }

    public string DoFairHousingActAccessibilityProvisionsApply { get; set; } = null!;

    public string? AssignedRCS { get; set; }

    public bool? IsthisaPreVSADevelopment { get; set; }

    public int? MaximumMobilityCSACount { get; set; }

    public string? TypeOfProject { get; set; }

    public string? casetype { get; set; }

    public string? CaseStatus { get; set; }

    public int? TotalNumberofMobilityUnitsRequired { get; set; }

    public int? TotalNumberofHearingUnitsRequired { get; set; }

    public string? NACRecommendation { get; set; }
}
