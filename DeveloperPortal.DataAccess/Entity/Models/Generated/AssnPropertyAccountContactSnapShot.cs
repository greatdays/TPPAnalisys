using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPropertyAccountContactSnapShot
{
    public int ID { get; set; }

    public DateTime CaptureDate { get; set; }

    public int ProjectSiteID { get; set; }

    public string? FileNumber { get; set; }

    public string? LinkType { get; set; }

    public int? ContactID { get; set; }

    public int? LutContactTypeID { get; set; }

    public string? ContactType { get; set; }
}
