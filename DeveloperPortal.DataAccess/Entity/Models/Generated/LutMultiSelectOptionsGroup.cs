using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutMultiSelectOptionsGroup
{
    public int LutMultiSelectOptionsGroupId { get; set; }

    public string OptionGroupName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<LutMultiSelectOption> LutMultiSelectOptions { get; set; } = new List<LutMultiSelectOption>();
}
