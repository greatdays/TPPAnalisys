using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PmpunitInfoSummarySnap
{
    public int PmpunitInfoSummarySnapId { get; set; }

    public int PmpsnapId { get; set; }

    public string? Ami { get; set; }

    public string? BedRoomSize { get; set; }

    public string? NoOfunit { get; set; }

    public string? AccessibilityType { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual Pmpsnap Pmpsnap { get; set; } = null!;
}
