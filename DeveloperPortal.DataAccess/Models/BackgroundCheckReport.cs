using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class BackgroundCheckReport
{
    public int BackgroundCheckReportId { get; set; }

    public int BackgroundCheckId { get; set; }

    public string Apn { get; set; } = null!;

    public string FileGroup { get; set; } = null!;

    public string FileNumber { get; set; } = null!;

    public string PropertyName { get; set; } = null!;

    public string PropertyAddress { get; set; } = null!;

    public string? DeveloperPortfolio { get; set; }

    public string? PropMgmtCompany { get; set; }

    public int? HimsConstructionPercent { get; set; }

    public string? IsOccupied { get; set; }

    public string? PolicyComplianceReviewDate { get; set; }

    public string? AssignedAnalyst { get; set; }

    public string? RegistryPropertyListing { get; set; }

    public string? Lfhtaowner { get; set; }

    public string? Lfhtaadacoordinator { get; set; }

    public string? LfhtagrievanceCoordinator { get; set; }

    public string? LfhtaregionalManager { get; set; }

    public string? LfhtapropertyManager { get; set; }

    public string? LastQuarterlyReport { get; set; }

    public string? VcautilizationSurvey { get; set; }

    public string? ConventionalUnitWaitingList { get; set; }

    public string? Vcareceipt { get; set; }

    public string? RevisedPoliciesDistribution { get; set; }

    public string? AdoptionNcomplianceSelfCertification { get; set; }

    public string? PropertyManagementPlan { get; set; }

    public string? PostingRequirements { get; set; }

    public string? AssistanceAnimalRefundLog { get; set; }

    public virtual BackgroundCheck BackgroundCheck { get; set; } = null!;
}
