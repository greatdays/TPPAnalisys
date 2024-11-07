using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ServiceRequestContact
{
    public int ServiceRequestContactID { get; set; }

    public long ServiceRequestID { get; set; }

    public int LutContactTypeID { get; set; }

    public int ContactIdentifierID { get; set; }

    public string? AssociationType { get; set; }

    public DateOnly? AssociatedFrom { get; set; }

    public DateOnly? AssociatedTo { get; set; }

    /// <summary>
    /// Obsolete yes or no
    /// </summary>
    public bool IsMailing { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ContactIdentifier ContactIdentifier { get; set; } = null!;

    public virtual LutContactType LutContactType { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
