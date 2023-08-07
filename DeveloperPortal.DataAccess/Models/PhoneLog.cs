using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class PhoneLog
{
    public int PhoneLogId { get; set; }

    public DateTime ReceivedDate { get; set; }

    public string CallerName { get; set; } = null!;

    public int LutLanguageLineId { get; set; }

    public string PhoneNo { get; set; } = null!;

    public string? AdditionalPhoneNo { get; set; }

    public string? Email { get; set; }

    public int? ProjectSiteId { get; set; }

    public string? CallerType { get; set; }

    public int LutCallTypeId { get; set; }

    public string? OtherCallType { get; set; }

    public string Message { get; set; } = null!;

    public DateTime ResponseDate { get; set; }

    public int ResponderId { get; set; }

    public string Outcome { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutCallType LutCallType { get; set; } = null!;

    public virtual LutLanguageLine LutLanguageLine { get; set; } = null!;

    public virtual ProjectSite? ProjectSite { get; set; }
}
