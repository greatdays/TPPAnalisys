using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutParkingType
{
    public int LutParkingTypeId { get; set; }

    public string? ParkingType { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<ProjectSiteAttribute> ProjectSiteAttributes { get; set; } = new List<ProjectSiteAttribute>();
}
