using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Policy complliance detail information
/// </summary>
public partial class PolicyComplianceDetail
{
    public int PolicyComplianceDetailId { get; set; }

    public long? ServiceRequestId { get; set; }

    public int? CaseId { get; set; }

    public string? OwnerContactName { get; set; }

    public string? PmcontactName { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyAddress { get; set; }

    public DateOnly? CertificateIssueDate { get; set; }

    public DateOnly? CityConfirmationDate { get; set; }

    public DateOnly? PropertyAcknowledgementDate { get; set; }

    public DateOnly? AssessmentCompletionDate { get; set; }

    public DateOnly? CertificateExpiryDate { get; set; }

    public DateOnly? PolicyReviewVisitDate { get; set; }

    public DateOnly? OnsiteReportSentDate { get; set; }

    public DateOnly? OnsiteReportDueDate { get; set; }

    public bool? IsCompliant { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public Guid RowId { get; set; }

    public virtual Case? Case { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
