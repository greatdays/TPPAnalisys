using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutAhupscore
{
    public int LutAhupscoreId { get; set; }

    public string? Name { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsObsolute { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
