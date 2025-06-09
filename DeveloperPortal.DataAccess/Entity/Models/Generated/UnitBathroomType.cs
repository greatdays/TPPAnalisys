using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class UnitBathroomType
{
    public int UnitBathroomTypeId { get; set; }

    public int UnitAttributeId { get; set; }

    public int LutBathroomTypeId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutBathroomType LutBathroomType { get; set; } = null!;

    public virtual UnitAttribute UnitAttribute { get; set; } = null!;
}
