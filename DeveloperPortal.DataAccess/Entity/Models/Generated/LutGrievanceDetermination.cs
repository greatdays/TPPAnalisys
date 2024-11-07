using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGrievanceDetermination
{
    public int LutGrievanceDeterminationID { get; set; }

    public string DeterminationStatus { get; set; } = null!;

    public int? ViewOrder { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Grievance> Grievances { get; set; } = new List<Grievance>();
}
