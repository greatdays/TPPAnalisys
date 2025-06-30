using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PmpoutreachAndAffimativeMarketingSnap
{
    public int OutreachSnapId { get; set; }

    public int PmpsnapId { get; set; }

    public int OutreachId { get; set; }

    public DateTime? DateOfOutreach { get; set; }

    public string? OrganizationName { get; set; }

    public string? ContactName { get; set; }

    public string? ContactPhone { get; set; }

    public string? LocationOfDistribution { get; set; }

    public string? OutreachType { get; set; }

    public string? PartyForDistrubution { get; set; }

    public string? Comments { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual Pmpsnap Pmpsnap { get; set; } = null!;
}
