using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PmpaddnlMarketingEffortSnap
{
    public int PmpaddnlMarketingEffortSnapId { get; set; }

    public int PmpsnapId { get; set; }

    public DateTime? LeaseUpBannerPostDate { get; set; }

    public string? LeaseUpBannerParty { get; set; }

    public DateTime? LeaseUpPhoneLinePostDate { get; set; }

    public string? LeaseUpPhoneLineParty { get; set; }

    public string? OtherName { get; set; }

    public DateTime? OtherPostedDate { get; set; }

    public string? OtherResponsibleParty { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual Pmpsnap Pmpsnap { get; set; } = null!;
}
