using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwAAHRPublicContact
{
    public int ProjectSiteID { get; set; }

    public string? FileNumber { get; set; }

    public int NoDefaultOwner { get; set; }

    public int DefaultOwnerContactID { get; set; }

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

    public bool? NoDefaultPM { get; set; }

    public int DefaultPMContactID { get; set; }

    public string PMContact { get; set; } = null!;

    public string PMContactName { get; set; } = null!;

    public string PMCompanyName { get; set; } = null!;

    public string PMEmail { get; set; } = null!;

    public string PMPhone { get; set; } = null!;

    public string PMAddress { get; set; } = null!;

    public string PMHouseNum { get; set; } = null!;

    public string PMHouseFracNum { get; set; } = null!;

    public string PMStreet { get; set; } = null!;

    public string PMUnit { get; set; } = null!;

    public string PMCity { get; set; } = null!;

    public string PMState { get; set; } = null!;

    public string PMZip { get; set; } = null!;
}
