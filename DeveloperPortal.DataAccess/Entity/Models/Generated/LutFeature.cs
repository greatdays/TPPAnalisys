using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutFeature
{
    public int LutFeatureId { get; set; }

    public string? FeatureArea { get; set; }

    public string? Category { get; set; }

    public string? Feature { get; set; }

    public bool IsProjectSiteFeature { get; set; }

    public bool IsUnitFeature { get; set; }

    public bool IsMultiple { get; set; }

    public bool IsObsolute { get; set; }

    public bool IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPmpunitFeatureSnap> AssnPmpunitFeatureSnaps { get; set; } = new List<AssnPmpunitFeatureSnap>();

    public virtual ICollection<AssnPropertyFeature> AssnPropertyFeatures { get; set; } = new List<AssnPropertyFeature>();

    public virtual ICollection<AssnUnitFeature> AssnUnitFeatures { get; set; } = new List<AssnUnitFeature>();
}
