using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPAgency
{
    public int AssnPMPAgencyID { get; set; }

    public int? PMPID { get; set; }

    public int? PMPAgencyID { get; set; }

    public virtual PMP? PMP { get; set; }

    public virtual PMPAgency? PMPAgency { get; set; }
}
