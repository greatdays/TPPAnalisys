using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwAahrdefaultContact
{
    public int ProjectSiteId { get; set; }

    public string? FileNumber { get; set; }

    public int NoDefaultOwner { get; set; }

    public int DefaultOwnerContactId { get; set; }

    public string OwnerContact { get; set; } = null!;

    public string OwnerContactName { get; set; } = null!;

    public string OwnerCompanyName { get; set; } = null!;

    public string OwnerEmail { get; set; } = null!;

    public string OwnerPhone { get; set; } = null!;

    public string OwnerAddress { get; set; } = null!;

    public string OwnerHouseNum { get; set; } = null!;

    public string OwnerHouseFracNum { get; set; } = null!;

    public string OwnerStreet { get; set; } = null!;

    public string OwnerUnit { get; set; } = null!;

    public string OwnerCity { get; set; } = null!;

    public string OwnerState { get; set; } = null!;

    public string OwnerZip { get; set; } = null!;

    public bool? NoDefaultPm { get; set; }

    public int DefaultPmcontactId { get; set; }

    public string Pmcontact { get; set; } = null!;

    public string PmcontactName { get; set; } = null!;

    public string PmcompanyName { get; set; } = null!;

    public string Pmemail { get; set; } = null!;

    public string Pmphone { get; set; } = null!;

    public string Pmaddress { get; set; } = null!;

    public string PmhouseNum { get; set; } = null!;

    public string PmhouseFracNum { get; set; } = null!;

    public string Pmstreet { get; set; } = null!;

    public string Pmunit { get; set; } = null!;

    public string Pmcity { get; set; } = null!;

    public string Pmstate { get; set; } = null!;

    public string Pmzip { get; set; } = null!;
}
