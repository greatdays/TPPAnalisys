using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnPmpagency
{
    public int AssnPmpagencyId { get; set; }

    public int? Pmpid { get; set; }

    public int? PmpagencyId { get; set; }

    public virtual Pmp? Pmp { get; set; }

    public virtual Pmpagency? Pmpagency { get; set; }
}
