using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutConstructionType
{
    public int LutConstructionTypeId { get; set; }

    public string? Name { get; set; }

    public bool? IsObsolete { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
