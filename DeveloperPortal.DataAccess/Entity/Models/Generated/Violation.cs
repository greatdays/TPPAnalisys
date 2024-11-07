using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Violation
{
    public int ViolationID { get; set; }

    public long? ServiceRequestID { get; set; }

    public int LutViolationID { get; set; }

    public int PropSnapshotID { get; set; }

    public string? Remedy { get; set; }

    /// <summary>
    /// Obsolete yes or no
    /// </summary>
    public bool IsPermitRequired { get; set; }

    /// <summary>
    /// Obsolete yes or no
    /// </summary>
    public bool IsFeeRequired { get; set; }

    public DateTime? ClearedOn { get; set; }

    public string? ClearedBy { get; set; }

    public decimal? MarkerLatitude { get; set; }

    public decimal? MarkerLongitude { get; set; }

    public string? ServiceTrackingID { get; set; }

    public bool IsDeleted { get; set; }

    public string? LocationInfo { get; set; }

    public string? CodeInfo { get; set; }

    public string? Justification { get; set; }

    public string? SeverityLevelProp { get; set; }

    public string? SeverityLevelUnit { get; set; }

    public string? SeverityLevelBldg { get; set; }

    public string? Attributes { get; set; }

    public string? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? LocationCategory { get; set; }

    public virtual ICollection<AssnInspectionViolation> AssnInspectionViolations { get; set; } = new List<AssnInspectionViolation>();

    public virtual ICollection<AssnScopeViolation> AssnScopeViolations { get; set; } = new List<AssnScopeViolation>();

    public virtual LutViolation LutViolation { get; set; } = null!;

    public virtual PropSnapshot PropSnapshot { get; set; } = null!;

    public virtual ServiceRequest? ServiceRequest { get; set; }

    public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();
}
