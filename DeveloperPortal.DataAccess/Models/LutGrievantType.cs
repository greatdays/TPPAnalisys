using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutGrievantType
{
    public int LutGrievantTypeId { get; set; }

    public string OptionText { get; set; } = null!;

    public int? ViewOrder { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<GrievanceType> GrievanceTypes { get; set; } = new List<GrievanceType>();
}
