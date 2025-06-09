using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class FloorPlanType
{
    public int FloorPlanTypeId { get; set; }

    public string Name { get; set; } = null!;

    public int ProjectId { get; set; }

    public int PropsnapShotId { get; set; }

    public int? ProjectSiteId { get; set; }

    public int? StructureId { get; set; }

    public double? SquareFeet { get; set; }

    public int LutTotalBedroomId { get; set; }

    public int LutTotalBathroomId { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
