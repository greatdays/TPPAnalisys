using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Subscription
{
    public int SubscriptionID { get; set; }

    public int ContactIdentifierID { get; set; }

    public bool IsListingAdded { get; set; }

    public bool IsOpenForApplication { get; set; }

    public bool IsWaitlistOpen { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsAccessibleUnit { get; set; }

    public bool IsOpenForAffordableApplication { get; set; }

    public bool IsClosedForAffordableApplication { get; set; }

    public virtual ContactIdentifier ContactIdentifier { get; set; } = null!;
}
