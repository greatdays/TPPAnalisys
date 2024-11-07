using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnGrievanceTypeMultiSelectOption
{
    public int GrievanceTypeID { get; set; }

    public int LutMultiSelectOptionsID { get; set; }

    public string? MoreDetails { get; set; }

    public virtual GrievanceType GrievanceType { get; set; } = null!;

    public virtual LutMultiSelectOption LutMultiSelectOptions { get; set; } = null!;
}
