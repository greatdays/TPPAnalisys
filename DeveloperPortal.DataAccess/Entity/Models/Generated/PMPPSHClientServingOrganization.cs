using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PMPPSHClientServingOrganization
{
    public int PMPPSHClientServingOrganizationId { get; set; }

    public int PMPId { get; set; }

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

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual PMP PMP { get; set; } = null!;
}
