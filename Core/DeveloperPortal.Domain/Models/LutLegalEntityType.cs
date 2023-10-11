using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutLegalEntityType
{
    public int LutLegalEntityTypeId { get; set; }

    public string? LegalEntityType { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Pmp> Pmps { get; set; } = new List<Pmp>();
}
