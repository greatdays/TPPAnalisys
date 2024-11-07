using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PMPOutreachOrganisation
{
    public int PMPOutreachOrganisationID { get; set; }

    public int? PMPID { get; set; }

    public int? OrganisationID { get; set; }

    public int? OutreachTypeId { get; set; }

    public string? OtherOutreachType { get; set; }

    public DateTime? OutreachDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Organization? Organisation { get; set; }

    public virtual LutOutreachType? OutreachType { get; set; }

    public virtual PMP? PMP { get; set; }
}
