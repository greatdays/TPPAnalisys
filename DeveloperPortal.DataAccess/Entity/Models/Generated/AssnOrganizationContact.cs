using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnOrganizationContact
{
    public int AssnOrganizationContactID { get; set; }

    public int OrganizationID { get; set; }

    public int ContactIdentifierID { get; set; }

    public string AssociationType { get; set; } = null!;

    public DateOnly AssociatedFrom { get; set; }

    public DateOnly? AssociatedTo { get; set; }

    public bool IsReviewRequired { get; set; }

    public string? Source { get; set; }

    public string? Status { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ContactIdentifier ContactIdentifier { get; set; } = null!;

    public virtual Organization Organization { get; set; } = null!;
}
