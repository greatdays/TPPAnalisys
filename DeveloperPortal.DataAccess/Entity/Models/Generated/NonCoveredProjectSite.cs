using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class NonCoveredProjectSite
{
    public int NonCoveredProjectSiteId { get; set; }

    public string PropertyName { get; set; } = null!;

    public string PropertyAddress { get; set; } = null!;

    public string DeveloperPortfolio { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual ICollection<AssnBgcnonCoveredProperty> AssnBgcnonCoveredProperties { get; set; } = new List<AssnBgcnonCoveredProperty>();
}
