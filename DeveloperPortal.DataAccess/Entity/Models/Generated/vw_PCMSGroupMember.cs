using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vw_PCMSGroupMember
{
    public string? Member_Name { get; set; }

    public string? Email1 { get; set; }

    public string? SiteAddress { get; set; }

    public string? Name { get; set; }

    public int PrimaryContactID { get; set; }

    public string? Title { get; set; }

    public int SecondaryContactID { get; set; }

    public int ProjectSiteID { get; set; }

    public bool isdeleted { get; set; }

    public string? source { get; set; }

    public string? contsource { get; set; }

    public int ContactID { get; set; }

    public int? ProjectID { get; set; }
}
