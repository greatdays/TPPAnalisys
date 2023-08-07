using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutStreetSuffix1
{
    public string PostDirCd { get; set; } = null!;

    /// <summary>
    /// Description.
    /// </summary>
    public string? Description { get; set; }

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

    public virtual ICollection<ContactIdentifier> ContactIdentifiers { get; set; } = new List<ContactIdentifier>();
}
