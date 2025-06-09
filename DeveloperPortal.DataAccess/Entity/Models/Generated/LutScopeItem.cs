using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutScopeItem
{
    public int LutScopeItemId { get; set; }

    public string? ScopeItem { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsDefault { get; set; }

    public bool IsObsolete { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnBidScopeOfWork> AssnBidScopeOfWorks { get; set; } = new List<AssnBidScopeOfWork>();
}
