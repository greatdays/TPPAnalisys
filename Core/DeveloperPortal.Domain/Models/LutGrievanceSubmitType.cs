using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutGrievanceSubmitType
{
    public int LutGrievanceSubmitTypeId { get; set; }

    public string GrievanceSubmitType { get; set; } = null!;

    public bool IsAbsolute { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<GrievanceLog> GrievanceLogs { get; set; } = new List<GrievanceLog>();

    public virtual ICollection<QrgrievanceLog> QrgrievanceLogs { get; set; } = new List<QrgrievanceLog>();
}
