using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class CapitemDetail
{
    public int CapitemDetailsId { get; set; }

    public int CapdetailsId { get; set; }

    public int LutcaplanguageId { get; set; }

    public string ComplianceRequirement { get; set; } = null!;

    public string RequiredCorrectiveAction { get; set; } = null!;

    public string? CheckListStatus { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public virtual Capdetail Capdetails { get; set; } = null!;

    public virtual Lutcaplanguage Lutcaplanguage { get; set; } = null!;
}
