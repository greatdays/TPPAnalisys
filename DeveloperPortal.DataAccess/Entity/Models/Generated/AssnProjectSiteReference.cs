using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnProjectSiteReference
{
    public int AssnProjectSiteReferenceID { get; set; }

    public int? ProjectSIteID { get; set; }

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

    public virtual ProjectSite? ProjectSIte { get; set; }

    public virtual LutReferenceType? ReferenceTypeNavigation { get; set; }
}
