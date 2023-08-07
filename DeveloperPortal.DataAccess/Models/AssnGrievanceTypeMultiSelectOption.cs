using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnGrievanceTypeMultiSelectOption
{
    public int GrievanceTypeId { get; set; }

    public int LutMultiSelectOptionsId { get; set; }

    public string? MoreDetails { get; set; }

    public virtual GrievanceType GrievanceType { get; set; } = null!;

    public virtual LutMultiSelectOption LutMultiSelectOptions { get; set; } = null!;
}
