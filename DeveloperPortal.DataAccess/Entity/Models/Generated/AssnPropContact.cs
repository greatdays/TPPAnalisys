using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPropContact
{
    public int AssnPropContactID { get; set; }

    public string? IdentifierType { get; set; }

    public string? APN { get; set; }

    public int? StructureID { get; set; }

    public int? UnitID { get; set; }

    public int? SiteAddressID { get; set; }

    public int ContactIdentifierID { get; set; }

    public int LutContactTypeID { get; set; }

    public DateOnly? AssociatedFrom { get; set; }

    public DateOnly? AssociatedTo { get; set; }

    public bool IsReviewRequired { get; set; }

    public string? Source { get; set; }

    public string? Status { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ProjectID { get; set; }

    public int? ProjectSiteID { get; set; }

    public bool IsPrimaryAssnType { get; set; }

    public bool? IsPrimaryContact { get; set; }

    public bool IsContactPublic { get; set; }

    public virtual ContactIdentifier ContactIdentifier { get; set; } = null!;

    public virtual LutContactType LutContactType { get; set; } = null!;
}
