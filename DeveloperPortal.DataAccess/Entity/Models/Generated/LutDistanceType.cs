using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutDistanceType
{
    public int LutDistanceTypeID { get; set; }

    public string? DistanceType { get; set; }

    public bool IsObsolute { get; set; }

    public bool IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPropertyDistance> AssnPropertyDistances { get; set; } = new List<AssnPropertyDistance>();
}
