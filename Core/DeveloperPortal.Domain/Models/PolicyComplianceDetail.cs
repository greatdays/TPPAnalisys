using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

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

    public DateTime? CertificateIssueDate { get; set; }

    public DateTime? CityConfirmationDate { get; set; }

    public DateTime? PropertyAcknowledgementDate { get; set; }

    public DateTime? AssessmentCompletionDate { get; set; }

    public DateTime? CertificateExpiryDate { get; set; }

    public DateTime? PolicyReviewVisitDate { get; set; }

    public DateTime? OnsiteReportSentDate { get; set; }

    public DateTime? OnsiteReportDueDate { get; set; }

    public bool? IsCompliant { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public Guid RowId { get; set; }

    public virtual Case? Case { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
