using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class TassnPropContact
{
    public int AssnPropContactId { get; set; }

    public string? IdentifierType { get; set; }

    public string? Apn { get; set; }

    public int? StructureId { get; set; }

    public int? UnitId { get; set; }

    public int? SiteAddressId { get; set; }

    public int ContactIdentifierId { get; set; }

    public int LutContactTypeId { get; set; }

    public DateTime? AssociatedFrom { get; set; }

    public DateTime? AssociatedTo { get; set; }

    public bool IsReviewRequired { get; set; }

    public string? Source { get; set; }

    public string? Status { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ProjectId { get; set; }

    public int? ProjectSiteId { get; set; }

    public bool IsPrimaryAssnType { get; set; }

    public bool? IsPrimaryContact { get; set; }
}
