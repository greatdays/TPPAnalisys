using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGrievanceDeterminationStatus
{
    public int LutGrievanceDeterminationStatusID { get; set; }

    public string DeterminationStatus { get; set; } = null!;

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<GrievanceLog> GrievanceLogs { get; set; } = new List<GrievanceLog>();

    public virtual ICollection<QRGrievanceLog> QRGrievanceLogs { get; set; } = new List<QRGrievanceLog>();
}
