using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutOccupancyReason
{
    public int LutOccupancyReasonId { get; set; }

    public string OccupancyReason { get; set; } = null!;

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<QroccupancyUnit> QroccupancyUnits { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<UnitAttribute> UnitAttributes { get; set; } = new List<UnitAttribute>();
}
