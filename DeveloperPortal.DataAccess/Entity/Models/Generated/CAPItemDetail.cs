using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class CAPItemDetail
{
    public int CAPItemDetailsID { get; set; }

    public int CAPDetailsID { get; set; }

    public int LUTCAPLanguageID { get; set; }

    public string ComplianceRequirement { get; set; } = null!;

    public string RequiredCorrectiveAction { get; set; } = null!;

    public string? CheckListStatus { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public virtual CAPDetail CAPDetails { get; set; } = null!;

    public virtual LUTCAPLanguage LUTCAPLanguage { get; set; } = null!;
}
