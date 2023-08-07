using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutExternalGroup
{
    public int LutExternalGroupId { get; set; }

    public string? Name { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
