using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// Keep policy certification issue and expiration information.  More certification will be add to this table when further development
/// </summary>
public partial class Certificate
{
    public int CertificateId { get; set; }

    public int? AchpProjectId { get; set; }

    public int LutCertificateTypeId { get; set; }

    public string? CertificationNum { get; set; }

    public int? CaseId { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public Guid RowId { get; set; }

    public long? ServiceRequestId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Title { get; set; }

    public int? OrganizationId { get; set; }

    public virtual Case? Case { get; set; }

    public virtual LutCertificateType LutCertificateType { get; set; } = null!;

    public virtual Organization? Organization { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
