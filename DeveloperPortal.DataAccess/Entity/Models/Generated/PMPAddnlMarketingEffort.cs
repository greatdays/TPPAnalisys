using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PmpaddnlMarketingEffort
{
    public int PmpaddnlMarketingEffortId { get; set; }

    public int? Pmpid { get; set; }

    public DateTime? LeaseUpBannerPostDate { get; set; }

    public string? LeaseUpBannerParty { get; set; }

    public DateTime? LeaseUpPhoneLinePostDate { get; set; }

    public string? LeaseUpPhoneLineParty { get; set; }

    public string? OtherName { get; set; }

    public DateTime? OtherPostedDate { get; set; }

    public string? OtherResponsibleParty { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Pmp? Pmp { get; set; }
}
