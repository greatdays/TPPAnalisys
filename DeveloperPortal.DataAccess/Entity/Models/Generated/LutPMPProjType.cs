using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutPmpprojType
{
    public int LutPmpprojTypeId { get; set; }

    public string Name { get; set; } = null!;

    public bool? SpecialNoteRequired { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPmpprojTypeSiteAttrSnap> AssnPmpprojTypeSiteAttrSnaps { get; set; } = new List<AssnPmpprojTypeSiteAttrSnap>();

    public virtual ICollection<AssnPmpprojTypeSiteAttr> AssnPmpprojTypeSiteAttrs { get; set; } = new List<AssnPmpprojTypeSiteAttr>();
}
