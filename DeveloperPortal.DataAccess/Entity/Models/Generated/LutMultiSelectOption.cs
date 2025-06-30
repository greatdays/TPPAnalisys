using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutMultiSelectOption
{
    public int LutMultiSelectOptionsId { get; set; }

    public int LutMultiSelectOptionsGroupId { get; set; }

    public string OptionText { get; set; } = null!;

    public bool HasMoreDetails { get; set; }

    public int? ViewOrder { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AssnGrievanceTypeMultiSelectOption> AssnGrievanceTypeMultiSelectOptions { get; set; } = new List<AssnGrievanceTypeMultiSelectOption>();

    public virtual LutMultiSelectOptionsGroup LutMultiSelectOptionsGroup { get; set; } = null!;
}
