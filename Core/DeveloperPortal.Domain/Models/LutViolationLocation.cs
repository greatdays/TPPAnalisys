using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// Violation Location - Kitchen, Living Room etc
/// </summary>
public partial class LutViolationLocation
{
    public int LutViolationLocationId { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? VisualIndicator { get; set; }

    /// <summary>
    /// Obsolete yes or no
    /// </summary>
    public bool IsObsolete { get; set; }

    /// <summary>
    /// Created by which user
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Created on which datetime
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Modified by which user
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified on which datetime
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<CannedNote> CannedNotes { get; set; } = new List<CannedNote>();

    public virtual ICollection<LutServiceRequestType> LutServiceRequestTypes { get; set; } = new List<LutServiceRequestType>();

    public virtual ICollection<LutViolation> LutViolations { get; set; } = new List<LutViolation>();
}
