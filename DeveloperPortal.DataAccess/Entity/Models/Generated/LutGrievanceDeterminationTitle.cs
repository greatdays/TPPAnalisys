using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGrievanceDeterminationTitle
{
    public int LutGrievanceDeterminationTitleID { get; set; }

    public string OptionText { get; set; } = null!;

    public int? ViewOrder { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<GrievanceLog> GrievanceLogs { get; set; } = new List<GrievanceLog>();

    public virtual ICollection<QRGrievanceLog> QRGrievanceLogs { get; set; } = new List<QRGrievanceLog>();
}
