using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutHousingType
{
    public int LutHousingTypeId { get; set; }

    public string? HousingType { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<ProjectSiteAttribute> ProjectSiteAttributes { get; set; } = new List<ProjectSiteAttribute>();
}
