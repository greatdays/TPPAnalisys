using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AcHPAPN
{
    public int ProjectSiteID { get; set; }

    public string? FileNumber { get; set; }

    public long apn { get; set; }

    public bool FlgDeleted { get; set; }

    public bool FlgObsolete { get; set; }

    public long NewAPN { get; set; }
}
