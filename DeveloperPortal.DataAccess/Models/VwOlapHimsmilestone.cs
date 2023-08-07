using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapHimsmilestone
{
    public string FullProjectNumber { get; set; } = null!;

    public int ProjUniqueId { get; set; }

    public string? MilestoneName { get; set; }

    public int LutMilestoneNameCd { get; set; }

    public DateTime? DateRequested { get; set; }

    public DateTime? DateReceived { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }
}
