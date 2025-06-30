using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WfstateFlag
{
    public int WorkFlowFlagId { get; set; }

    public int? WfstateId { get; set; }

    public bool? IsDeleteLocked { get; set; }

    public bool? IsAddLocked { get; set; }

    public bool? IsClearLocked { get; set; }

    public bool? IsModifyLocked { get; set; }
}
