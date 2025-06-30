using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutAccessibleUnitFeature
{
    public int LutAccessibleUnitFeatureId { get; set; }

    public string? Name { get; set; }

    public bool? SpecialNoteRequired { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? Hvratio { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPmpprojSiteAccessibleUnitFeatureSnap> AssnPmpprojSiteAccessibleUnitFeatureSnaps { get; set; } = new List<AssnPmpprojSiteAccessibleUnitFeatureSnap>();

    public virtual ICollection<AssnProjSiteAccessibleUnitFeature> AssnProjSiteAccessibleUnitFeatures { get; set; } = new List<AssnProjSiteAccessibleUnitFeature>();
}
