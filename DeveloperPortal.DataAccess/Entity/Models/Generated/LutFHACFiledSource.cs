using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutFHACFiledSource
{
    public int LutFHACFiledSourceID { get; set; }

    public string FHACFiledSource { get; set; } = null!;

    public bool IsAbsolute { get; set; }

    public bool IsDeleted { get; set; }

    public int ViewOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnFHACFiledDate> AssnFHACFiledDates { get; set; } = new List<AssnFHACFiledDate>();

    public virtual ICollection<AssnQRFHACFiledDate> AssnQRFHACFiledDates { get; set; } = new List<AssnQRFHACFiledDate>();
}
