using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPSitesOutreach
{
    public int AssnPMPSitesOutreachID { get; set; }

    public int? PMPID { get; set; }

    public int? PropsnapshotID { get; set; }

    public int? OutreachID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual OutreachAndAffimativeMarketing? Outreach { get; set; }

    public virtual PMP? PMP { get; set; }

    public virtual PropSnapshot? Propsnapshot { get; set; }
}
