using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapProjectDetailsUpdated
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

    public string? Casetype { get; set; }

    public string? CaseStatus { get; set; }

    public int? TotalNumberofMobilityUnitsRequired { get; set; }

    public int? TotalNumberofHearingUnitsRequired { get; set; }

    public string? Nacrecommendation { get; set; }
}
