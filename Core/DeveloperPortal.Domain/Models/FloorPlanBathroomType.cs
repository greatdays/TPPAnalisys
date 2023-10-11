using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class FloorPlanBathroomType
{
    public int FloorPlanBathroomTypeId { get; set; }

    public int FloorPlanTypeId { get; set; }

    public int LutBathroomTypeId { get; set; }

    public int? LutBathroomTypeOptionId { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
