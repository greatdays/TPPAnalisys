using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectSiteMarketingFlyerSnap
{
    public int MarketingFlyerSnapId { get; set; }

    public int? MarketingFlyerId { get; set; }

    public int? ProjectSiteSnapId { get; set; }

    public string? DeveloperName { get; set; }

    public string? PMCompanyName { get; set; }

    public DateOnly? LotteryDate { get; set; }

    public string? MethodToAcceptApplication1 { get; set; }

    public string? MethodToAcceptApplication2 { get; set; }

    public string? MethodToAcceptApplication3 { get; set; }

    public string? MethodToAcceptApplication4 { get; set; }

    public string? MailingAddressForApplication { get; set; }

    public string? FaxNumber { get; set; }

    public string? PropertyFeatures { get; set; }

    public string? UnitsAvailable { get; set; }

    public string? AccessibleFeatures { get; set; }

    public string? IncomeLimits { get; set; }

    public string? ReferralAgency { get; set; }

    public string? SupportServices { get; set; }

    public string? DescForReasonableAccommodation { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ProjectSiteSnap? ProjectSiteSnap { get; set; }
}
