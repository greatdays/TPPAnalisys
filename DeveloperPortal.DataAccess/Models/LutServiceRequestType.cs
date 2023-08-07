using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutServiceRequestType
{
    public int LutServiceRequestTypeId { get; set; }

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

    public Guid? ApplicationGuid { get; set; }

    public virtual ICollection<AssnServiceRequestTypeViolation> AssnServiceRequestTypeViolations { get; set; } = new List<AssnServiceRequestTypeViolation>();

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();

    public virtual ICollection<LutViolationLocation> LutViolationLocations { get; set; } = new List<LutViolationLocation>();
}
