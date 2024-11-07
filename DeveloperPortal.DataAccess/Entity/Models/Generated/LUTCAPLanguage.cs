using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LUTCAPLanguage
{
    public int LUTCAPLanguageID { get; set; }

    public int LutCAPChecklistItemID { get; set; }

    public string ComplianceItemHeader { get; set; } = null!;

    public string ComplianceRequirement { get; set; } = null!;

    public string RequiredCorrectiveAction { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public bool? IsObselete { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public virtual ICollection<CAPItemDetail> CAPItemDetails { get; set; } = new List<CAPItemDetail>();

    public virtual LutCAPChecklistItem LutCAPChecklistItem { get; set; } = null!;
}
