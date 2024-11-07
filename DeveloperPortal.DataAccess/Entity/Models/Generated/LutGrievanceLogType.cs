using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGrievanceLogType
{
    public int LutGrievanceLogTypeID { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<GrievanceLog1> GrievanceLog1s { get; set; } = new List<GrievanceLog1>();
}
