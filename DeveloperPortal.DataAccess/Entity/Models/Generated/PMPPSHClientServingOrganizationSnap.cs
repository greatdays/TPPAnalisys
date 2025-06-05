using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PmppshclientServingOrganizationSnap
{
    public int PmppshclientServingOrganizationSnapId { get; set; }

    public int PmpsnapId { get; set; }

    public string? OrganizationName { get; set; }

    public string? Address { get; set; }

    public string? ResourceType { get; set; }

    public string? Phone { get; set; }

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual Pmpsnap Pmpsnap { get; set; } = null!;
}
