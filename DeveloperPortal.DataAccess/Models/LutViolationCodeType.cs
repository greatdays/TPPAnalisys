using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutViolationCodeType
{
    public int LutViolationCodeTypeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

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

    public virtual ICollection<LutViolationCode> LutViolationCodes { get; set; } = new List<LutViolationCode>();
}
