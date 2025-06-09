using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class BidPackage
{
    public int BidPackageId { get; set; }

    public long BidPackageServiceRequestId { get; set; }

    public long SiteCaseServiceRequestId { get; set; }

    public string? TypeOfBuildingConstruction { get; set; }

    /// <summary>
    /// Contact associated with Site Service Request
    /// </summary>
    public int? ContactIdentifierId { get; set; }

    public string? Rcsusername { get; set; }

    public string? Rcsphone { get; set; }

    public int? LutContractorTypeId { get; set; }

    public decimal? EstimatedContractTotal { get; set; }

    public decimal? RetrofitScopeCost { get; set; }

    public decimal? Overhead { get; set; }

    public decimal? EstimatedBond { get; set; }

    public decimal? EstimatedPermit { get; set; }

    public string? Comments { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnBidScopeOfWork> AssnBidScopeOfWorks { get; set; } = new List<AssnBidScopeOfWork>();

    public virtual ICollection<AwardBidPackage> AwardBidPackages { get; set; } = new List<AwardBidPackage>();

    public virtual ServiceRequest BidPackageServiceRequest { get; set; } = null!;

    public virtual ContactIdentifier? ContactIdentifier { get; set; }

    public virtual ICollection<DrawRequest> DrawRequests { get; set; } = new List<DrawRequest>();

    public virtual LutContractorType? LutContractorType { get; set; }

    public virtual ServiceRequest SiteCaseServiceRequest { get; set; } = null!;
}
