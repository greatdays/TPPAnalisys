using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Lutcaplanguage
{
    public int LutcaplanguageId { get; set; }

    public int LutCapchecklistItemId { get; set; }

    public string ComplianceItemHeader { get; set; } = null!;

    public string ComplianceRequirement { get; set; } = null!;

    public string RequiredCorrectiveAction { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public bool? IsObselete { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public virtual ICollection<CapitemDetail> CapitemDetails { get; set; } = new List<CapitemDetail>();

    public virtual LutCapchecklistItem LutCapchecklistItem { get; set; } = null!;
}
