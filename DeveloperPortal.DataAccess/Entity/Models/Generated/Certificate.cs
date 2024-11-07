using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Keep policy certification issue and expiration information.  More certification will be add to this table when further development
/// </summary>
public partial class Certificate
{
    public int CertificateID { get; set; }

    public int? AchpProjectID { get; set; }

    public int LutCertificateTypeID { get; set; }

    public string? CertificationNum { get; set; }

    public int? CaseID { get; set; }

    public DateOnly? IssueDate { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public Guid RowID { get; set; }

    public long? ServiceRequestID { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Title { get; set; }

    public int? OrganizationID { get; set; }

    public virtual Case? Case { get; set; }

    public virtual LutCertificateType LutCertificateType { get; set; } = null!;

    public virtual Organization? Organization { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
