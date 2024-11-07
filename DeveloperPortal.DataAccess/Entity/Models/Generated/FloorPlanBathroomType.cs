using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class FloorPlanBathroomType
{
    public int FloorPlanBathroomTypeID { get; set; }

    public int FloorPlanTypeID { get; set; }

    public int LutBathroomTypeID { get; set; }

    public int? LutBathroomTypeOptionID { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
