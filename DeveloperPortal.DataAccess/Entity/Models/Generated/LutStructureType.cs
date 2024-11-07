using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutStructureType
{
    public int LutStructureTypeID { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public int? SortBy { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
