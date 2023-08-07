using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutOutreachType
{
    public int LutOutreachTypeId { get; set; }

    public string? Description { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? SortOrder { get; set; }

    public virtual ICollection<PmpoutreachOrganisation> PmpoutreachOrganisations { get; set; } = new List<PmpoutreachOrganisation>();
}
