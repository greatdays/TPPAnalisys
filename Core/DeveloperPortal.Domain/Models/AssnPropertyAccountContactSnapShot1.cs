using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnPropertyAccountContactSnapShot1
{
    public int Id { get; set; }

    public DateTime CaptureDate { get; set; }

    public int ProjectSiteId { get; set; }

    public string? FileNumber { get; set; }

    public string? LinkType { get; set; }

    public int? ContactId { get; set; }

    public int? LutContactTypeId { get; set; }

    public string? ContactType { get; set; }

    public bool? IsPrimaryAssnType { get; set; }

    public string? Attribute { get; set; }
}
