using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutCAPChecklistItem
{
    public int LutCAPChecklistItemId { get; set; }

    public string Item { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsObselete { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public virtual ICollection<AssnSRCAPChecklistItemStatus> AssnSRCAPChecklistItemStatuses { get; set; } = new List<AssnSRCAPChecklistItemStatus>();

    public virtual ICollection<LUTCAPLanguage> LUTCAPLanguages { get; set; } = new List<LUTCAPLanguage>();

    public virtual ICollection<LutCAPChecklistSubItem> LutCAPChecklistSubItems { get; set; } = new List<LutCAPChecklistSubItem>();
}
