using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGrievanceSource
{
    public int LutGrievanceSourceId { get; set; }

    public string Description { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<GrievanceAppeal> GrievanceAppeals { get; set; } = new List<GrievanceAppeal>();

    public virtual ICollection<Grievance> Grievances { get; set; } = new List<Grievance>();
}
