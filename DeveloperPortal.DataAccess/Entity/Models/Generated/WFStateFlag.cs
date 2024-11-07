using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WFStateFlag
{
    public int WorkFlowFlagID { get; set; }

    public int? WFStateID { get; set; }

    public bool? IsDeleteLocked { get; set; }

    public bool? IsAddLocked { get; set; }

    public bool? IsClearLocked { get; set; }

    public bool? IsModifyLocked { get; set; }
}
