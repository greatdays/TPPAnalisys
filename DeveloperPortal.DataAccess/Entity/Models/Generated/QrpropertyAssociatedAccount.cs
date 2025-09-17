using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QrpropertyAssociatedAccount
{
    public int QrpropertyAssociatedAccountId { get; set; }

    public int QrfairHousingId { get; set; }

    public int QuarterlyReportId { get; set; }

    public string Role { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? CertificationDate { get; set; }

    public DateOnly? NextEnrolledFairHousingTrainingDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
