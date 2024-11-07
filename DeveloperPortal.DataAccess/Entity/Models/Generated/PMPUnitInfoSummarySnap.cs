using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PMPUnitInfoSummarySnap
{
    public int PMPUnitInfoSummarySnapID { get; set; }

    public int PMPSnapID { get; set; }

    public string? AMI { get; set; }

    public string? BedRoomSize { get; set; }

    public string? NoOfunit { get; set; }

    public string? AccessibilityType { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual PMPSnap PMPSnap { get; set; } = null!;
}
