using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutContractorType
{
    public int LutContractorTypeId { get; set; }

    public string? ContractorType { get; set; }

    public bool? IsObsolete { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<BidPackage> BidPackages { get; set; } = new List<BidPackage>();
}
