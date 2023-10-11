using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnProjectSiteApn
{
    public int AssnProjectSiteApnid { get; set; }

    public int? ProjectSiteId { get; set; }

    public string? Apnno { get; set; }

    public bool? IsAcHp { get; set; }

    public bool? IsHims { get; set; }
}
