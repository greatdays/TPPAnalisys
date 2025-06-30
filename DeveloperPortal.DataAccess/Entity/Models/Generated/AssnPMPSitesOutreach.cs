using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPmpsitesOutreach
{
    public int AssnPmpsitesOutreachId { get; set; }

    public int? Pmpid { get; set; }

    public int? PropsnapshotId { get; set; }

    public int? OutreachId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual OutreachAndAffimativeMarketing? Outreach { get; set; }

    public virtual Pmp? Pmp { get; set; }

    public virtual PropSnapshot? Propsnapshot { get; set; }
}
