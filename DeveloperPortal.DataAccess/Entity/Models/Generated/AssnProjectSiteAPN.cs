using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnProjectSiteAPN
{
    public int AssnProjectSiteAPNID { get; set; }

    public int? ProjectSiteId { get; set; }

    public string? APNNo { get; set; }

    public bool? IsAcHP { get; set; }

    public bool? IsHIMS { get; set; }
}
