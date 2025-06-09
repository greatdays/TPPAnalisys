using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class HotlineCount
{
    public int HotlineCountId { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public int? CallCount { get; set; }

    public string? Comment { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
