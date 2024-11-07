using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class EmailLog
{
    public int EmailLogID { get; set; }

    public DateOnly ReceivedDate { get; set; }

    public string EmailerName { get; set; } = null!;

    public string? PhoneNo { get; set; }

    public string? AdditionalPhoneNo { get; set; }

    public string Email { get; set; } = null!;

    public int? ProjectSiteID { get; set; }

    public string? CallerType { get; set; }

    public int LutMailTypeID { get; set; }

    public string? OtherMailType { get; set; }

    public string Message { get; set; } = null!;

    public DateOnly ResponseDate { get; set; }

    public int ResponderID { get; set; }

    public int LutOutcomeID { get; set; }

    public string? Outcome { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutMailType LutMailType { get; set; } = null!;

    public virtual LutOutcome LutOutcome { get; set; } = null!;

    public virtual ProjectSite? ProjectSite { get; set; }
}
