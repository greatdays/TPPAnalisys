using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnScopeViolation
{
    public int AssnScopeViolationID { get; set; }

    public int AssnBidScopeOfWorkID { get; set; }

    public int? ViolationID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual AssnBidScopeOfWork AssnBidScopeOfWork { get; set; } = null!;

    public virtual Violation? Violation { get; set; }

    public virtual ICollection<DrawRequest> DrawRequests { get; set; } = new List<DrawRequest>();
}
