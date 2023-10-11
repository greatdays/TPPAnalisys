using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutAltContactType
{
    public int LutAltContactTypeId { get; set; }

    public string? PreferContactType { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;
}
