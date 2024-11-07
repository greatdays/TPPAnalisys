using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PhoneLog
{
    public int PhoneLogID { get; set; }

    public DateOnly ReceivedDate { get; set; }

    public string CallerName { get; set; } = null!;

    public int LutLanguageLineID { get; set; }

    public string PhoneNo { get; set; } = null!;

    public string? AdditionalPhoneNo { get; set; }

    public string? Email { get; set; }

    public int? ProjectSiteID { get; set; }

    public string? CallerType { get; set; }

    public int LutCallTypeID { get; set; }

    public string? OtherCallType { get; set; }

    public string Message { get; set; } = null!;

    public DateOnly ResponseDate { get; set; }

    public int ResponderID { get; set; }

    public string Outcome { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutCallType LutCallType { get; set; } = null!;

    public virtual LutLanguageLine LutLanguageLine { get; set; } = null!;

    public virtual ProjectSite? ProjectSite { get; set; }
}
