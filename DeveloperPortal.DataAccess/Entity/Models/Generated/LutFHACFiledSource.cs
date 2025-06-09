using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutFhacfiledSource
{
    public int LutFhacfiledSourceId { get; set; }

    public string FhacfiledSource { get; set; } = null!;

    public bool IsAbsolute { get; set; }

    public bool IsDeleted { get; set; }

    public int ViewOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnFhacfiledDate> AssnFhacfiledDates { get; set; } = new List<AssnFhacfiledDate>();

    public virtual ICollection<AssnQrfhacfiledDate> AssnQrfhacfiledDates { get; set; } = new List<AssnQrfhacfiledDate>();
}
