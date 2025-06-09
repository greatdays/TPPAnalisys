using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PmpoutreachOrganisation
{
    public int PmpoutreachOrganisationId { get; set; }

    public int? Pmpid { get; set; }

    public int? OrganisationId { get; set; }

    public int? OutreachTypeId { get; set; }

    public string? OtherOutreachType { get; set; }

    public DateTime? OutreachDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Organization? Organisation { get; set; }

    public virtual LutOutreachType? OutreachType { get; set; }

    public virtual Pmp? Pmp { get; set; }
}
