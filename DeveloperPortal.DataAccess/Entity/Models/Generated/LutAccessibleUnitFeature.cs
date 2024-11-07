using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutAccessibleUnitFeature
{
    public int LutAccessibleUnitFeatureID { get; set; }

    public string? Name { get; set; }

    public bool? SpecialNoteRequired { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? HVRatio { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPMPProjSiteAccessibleUnitFeatureSnap> AssnPMPProjSiteAccessibleUnitFeatureSnaps { get; set; } = new List<AssnPMPProjSiteAccessibleUnitFeatureSnap>();

    public virtual ICollection<AssnProjSiteAccessibleUnitFeature> AssnProjSiteAccessibleUnitFeatures { get; set; } = new List<AssnProjSiteAccessibleUnitFeature>();
}
