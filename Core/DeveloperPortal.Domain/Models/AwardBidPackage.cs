using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AwardBidPackage
{
    public int AwardBidPackageId { get; set; }

    public int? BidPackageId { get; set; }

    public string ContractorUsername { get; set; } = null!;

    public DateTime? DateAward { get; set; }

    public decimal? Amount { get; set; }

    public string? Comments { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? ProjectCommencementDate { get; set; }

    public virtual BidPackage? BidPackage { get; set; }
}
