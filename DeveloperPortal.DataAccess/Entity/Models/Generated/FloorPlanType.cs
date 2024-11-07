using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class FloorPlanType
{
    public int FloorPlanTypeID { get; set; }

    public string Name { get; set; } = null!;

    public int ProjectID { get; set; }

    public int PropsnapShotID { get; set; }

    public int? ProjectSiteID { get; set; }

    public int? StructureID { get; set; }

    public double? SquareFeet { get; set; }

    public int LutTotalBedroomID { get; set; }

    public int LutTotalBathroomID { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
