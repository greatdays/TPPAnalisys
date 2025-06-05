using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnContactContact
{
    public int AssnContactContactId { get; set; }

    public int PrimaryContactId { get; set; }

    public int SecondaryContactId { get; set; }

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

    public virtual ContactIdentifier PrimaryContact { get; set; } = null!;

    public virtual ContactIdentifier SecondaryContact { get; set; } = null!;
}
