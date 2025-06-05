using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class GrievanceLog1
{
    public int GrievanceLogId { get; set; }

    public int GrievanceId { get; set; }

    public int LutGrievanceLogTypeId { get; set; }

    public string? LogText { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Grievance Grievance { get; set; } = null!;

    public virtual LutGrievanceLogType LutGrievanceLogType { get; set; } = null!;
}
