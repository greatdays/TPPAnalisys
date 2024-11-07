using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutOutreachType
{
    public int LutOutreachTypeID { get; set; }

    public string? Description { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? SortOrder { get; set; }

    public virtual ICollection<PMPOutreachOrganisationSnap> PMPOutreachOrganisationSnaps { get; set; } = new List<PMPOutreachOrganisationSnap>();

    public virtual ICollection<PMPOutreachOrganisation> PMPOutreachOrganisations { get; set; } = new List<PMPOutreachOrganisation>();
}
