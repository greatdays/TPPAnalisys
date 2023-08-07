using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapProjectDetail
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? FileGroup { get; set; }

    public string? Occupiedstatus { get; set; }

    public string PreSettlementDevelopment { get; set; } = null!;

    public double? Ahupscore { get; set; }

    public int? AhupproductionScheduleYear { get; set; }

    public bool? ListedOnAhupproductionSchedule { get; set; }

    public string DoFairHousingActAccessibilityProvisionsApply { get; set; } = null!;

    public string? AssignedRcs { get; set; }

    public bool? IsthisaPreVsadevelopment { get; set; }

    public int? MaximumMobilityCsacount { get; set; }

    public string? TypeOfProject { get; set; }

    public string Casetype { get; set; } = null!;

    public string? CaseStatus { get; set; }
}
