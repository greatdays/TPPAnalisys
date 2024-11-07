using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class BackgroundCheckReport
{
    public int BackgroundCheckReportID { get; set; }

    public int BackgroundCheckID { get; set; }

    public string? APN { get; set; }

    public string? FileGroup { get; set; }

    public string? FileNumber { get; set; }

    public string PropertyName { get; set; } = null!;

    public string PropertyAddress { get; set; } = null!;

    public string? DeveloperPortfolio { get; set; }

    public string? PropMgmtCompany { get; set; }

    public int? HIMsConstructionPercent { get; set; }

    public string? IsOccupied { get; set; }

    public string? PolicyComplianceReviewDate { get; set; }

    public string? AssignedAnalyst { get; set; }

    public string? AssignedAnalystFullName { get; set; }

    public string? AssignedAnalystEmail { get; set; }

    public string? RegistryPropertyListing { get; set; }

    public string? LFHTAOwner { get; set; }

    public string? LFHTAADACoordinator { get; set; }

    public string? LFHTAGrievanceCoordinator { get; set; }

    public string? LFHTARegionalManager { get; set; }

    public string? LFHTAPropertyManager { get; set; }

    public string? LastQuarterlyReport { get; set; }

    public string? VCAUtilizationSurvey { get; set; }

    public string? ConventionalUnitWaitingList { get; set; }

    public string? VCAReceipt { get; set; }

    public string? RevisedPoliciesDistribution { get; set; }

    public string? AdoptionNComplianceSelfCertification { get; set; }

    public string? PropertyManagementPlan { get; set; }

    public string? PostingRequirements { get; set; }

    public string? AssistanceAnimalRefundLog { get; set; }

    public virtual BackgroundCheck BackgroundCheck { get; set; } = null!;
}
