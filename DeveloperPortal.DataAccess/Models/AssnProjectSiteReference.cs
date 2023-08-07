using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnProjectSiteReference
{
    public int AssnProjectSiteReferenceId { get; set; }

    public int? ProjectSiteId { get; set; }

    public int? ReferenceType { get; set; }

    public int? ViewOrder { get; set; }

    public int? RefPrimaryKey { get; set; }

    public string? RefNumber { get; set; }

    public int? SiteNumber { get; set; }

    public string? Description { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ProjectSite? ProjectSite { get; set; }

    public virtual LutReferenceType? ReferenceTypeNavigation { get; set; }
}
