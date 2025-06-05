using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Lookup table for the type of certification
/// </summary>
public partial class LutCertificateType
{
    public int LutCertificateTypeId { get; set; }

    public string ComplianceType { get; set; } = null!;

    public string? Comment { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowId { get; set; }

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
}
