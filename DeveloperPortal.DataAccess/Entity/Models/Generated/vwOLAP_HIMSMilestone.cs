using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_HIMSMilestone
{
    public string FullProjectNumber { get; set; } = null!;

    public int ProjUniqueID { get; set; }

    public string? MilestoneName { get; set; }

    public int LutMilestoneNameCD { get; set; }

    public DateTime? DateRequested { get; set; }

    public DateTime? DateReceived { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }
}
