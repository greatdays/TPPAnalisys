using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutPMPProjType
{
    public int LutPMPProjTypeID { get; set; }

    public string Name { get; set; } = null!;

    public bool? SpecialNoteRequired { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPMPProjTypeSiteAttrSnap> AssnPMPProjTypeSiteAttrSnaps { get; set; } = new List<AssnPMPProjTypeSiteAttrSnap>();

    public virtual ICollection<AssnPMPProjTypeSiteAttr> AssnPMPProjTypeSiteAttrs { get; set; } = new List<AssnPMPProjTypeSiteAttr>();
}
