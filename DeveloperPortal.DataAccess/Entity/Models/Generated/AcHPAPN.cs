using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AcHpapn
{
    public int ProjectSiteId { get; set; }

    public string? FileNumber { get; set; }

    public long Apn { get; set; }

    public bool FlgDeleted { get; set; }

    public bool FlgObsolete { get; set; }

    public long NewApn { get; set; }
}
