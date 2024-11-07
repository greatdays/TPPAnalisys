using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PMPOutreachAndAffimativeMarketingSnap
{
    public int OutreachSnapID { get; set; }

    public int PMPSnapID { get; set; }

    public int OutreachID { get; set; }

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

    public virtual PMPSnap PMPSnap { get; set; } = null!;
}
