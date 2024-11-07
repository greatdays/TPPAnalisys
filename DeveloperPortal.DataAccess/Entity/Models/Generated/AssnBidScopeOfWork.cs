using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnBidScopeOfWork
{
    public int AssnBidScopeOfWorkID { get; set; }

    public int BidPackageID { get; set; }

    public int LutScopeItemID { get; set; }

    public string? Location { get; set; }

    public int Quantity { get; set; }

    public string? Comments { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public decimal? Amount { get; set; }

    public virtual ICollection<AssnScopeViolation> AssnScopeViolations { get; set; } = new List<AssnScopeViolation>();

    public virtual BidPackage BidPackage { get; set; } = null!;

    public virtual LutScopeItem LutScopeItem { get; set; } = null!;
}
