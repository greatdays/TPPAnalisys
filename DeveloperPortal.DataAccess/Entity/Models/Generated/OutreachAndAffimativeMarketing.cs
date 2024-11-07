using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class OutreachAndAffimativeMarketing
{
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

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnOutreachTargetAudience> AssnOutreachTargetAudiences { get; set; } = new List<AssnOutreachTargetAudience>();

    public virtual ICollection<AssnPMPSitesOutreach> AssnPMPSitesOutreaches { get; set; } = new List<AssnPMPSitesOutreach>();
}
