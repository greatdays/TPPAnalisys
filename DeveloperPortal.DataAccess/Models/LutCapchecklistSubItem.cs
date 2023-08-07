using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutCapchecklistSubItem
{
    public int LutCapchecklistSubItemId { get; set; }

    public int LutCapchecklistItemId { get; set; }

    public string SubItem { get; set; } = null!;

    public string? Description { get; set; }

    public string? DmssubCategory { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsObselete { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public virtual ICollection<AssnSrcapchecklistItemStatus> AssnSrcapchecklistItemStatuses { get; set; } = new List<AssnSrcapchecklistItemStatus>();

    public virtual LutCapchecklistItem LutCapchecklistItem { get; set; } = null!;
}
