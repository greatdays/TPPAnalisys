using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPAgencySnap
{
    public int AssnPMPAgencySnapID { get; set; }

    public int PMPSnapID { get; set; }

    public int PMPAgencyID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual PMPSnap PMPSnap { get; set; } = null!;
}
