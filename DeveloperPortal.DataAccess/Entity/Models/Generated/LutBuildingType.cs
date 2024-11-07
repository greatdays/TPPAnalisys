using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutBuildingType
{
    public int LutBuildingTypeID { get; set; }

    public string? Name { get; set; }

    public bool IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<StructureAttribute> StructureAttributes { get; set; } = new List<StructureAttribute>();
}
