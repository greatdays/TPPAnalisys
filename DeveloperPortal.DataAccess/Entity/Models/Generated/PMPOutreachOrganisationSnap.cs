using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PMPOutreachOrganisationSnap
{
    public int PMPOutreachOrganisationSnapID { get; set; }

    public int? PMPSnapID { get; set; }

    public int? OrganisationID { get; set; }

    public int? LutOutreachTypeID { get; set; }

    public string? OtherOutreachType { get; set; }

    public DateTime? OutreachDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutOutreachType? LutOutreachType { get; set; }

    public virtual Organization? Organisation { get; set; }

    public virtual PMPSnap? PMPSnap { get; set; }
}
