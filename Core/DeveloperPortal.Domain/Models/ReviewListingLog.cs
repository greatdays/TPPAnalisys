using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class ReviewListingLog
{
    public int ReviewListingLogId { get; set; }

    public int? CaseId { get; set; }

    public string? Status { get; set; }

    public string? Username { get; set; }

    public string? UserFullName { get; set; }

    public string? UserEmail { get; set; }

    public bool? IsAcHpstaff { get; set; }

    public string? Attributes { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
