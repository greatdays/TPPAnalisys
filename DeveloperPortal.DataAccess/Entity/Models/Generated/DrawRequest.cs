using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class DrawRequest
{
    public int DrawRequestID { get; set; }

    public long ServiceRequestID { get; set; }

    public int BidPackageID { get; set; }

    public decimal? Amount { get; set; }

    public string? Comments { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual BidPackage BidPackage { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;

    public virtual ICollection<AssnScopeViolation> AssnScopeViolations { get; set; } = new List<AssnScopeViolation>();
}
