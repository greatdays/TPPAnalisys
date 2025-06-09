using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwProjectSitePrimaryContact
{
    public bool? NoDefault { get; set; }

    public int DefaultContactId { get; set; }

    public string? ContactName { get; set; }

    public string? CompanyName { get; set; }

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? HouseNum { get; set; }

    public string? HouseFracNum { get; set; }

    public string Street { get; set; } = null!;

    public string? Unit { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? Phone { get; set; }

    public string? ContactType { get; set; }

    public int? ProjectSiteId { get; set; }
}
