using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutContactType
{
    public int LutContactTypeId { get; set; }

    public string? LutContactTypeCd { get; set; }

    public string ContactType { get; set; } = null!;

    /// <summary>
    /// Description.
    /// </summary>
    public string? Description { get; set; }

    public string? Category { get; set; }

    /// <summary>
    /// Is Obsolete.
    /// </summary>
    public bool IsObsolete { get; set; }

    /// <summary>
    /// Record created username.
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Record created date.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Record modified username.
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Record modified date.
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPropContact> AssnPropContacts { get; set; } = new List<AssnPropContact>();

    public virtual ICollection<Hrmapplication> Hrmapplications { get; set; } = new List<Hrmapplication>();

    public virtual ICollection<ServiceRequestContact> ServiceRequestContacts { get; set; } = new List<ServiceRequestContact>();
}
