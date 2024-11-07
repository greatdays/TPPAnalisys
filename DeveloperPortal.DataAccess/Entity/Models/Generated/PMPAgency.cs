using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PMPAgency
{
    public int PMPAgencyID { get; set; }

    public string? PMPAgencyName { get; set; }

    public string? PMPAgencyContactName { get; set; }

    public string? PMPAgencyAddress { get; set; }

    public string? PMPAgencyPhoneNumber { get; set; }

    public string? PMPAgencyEmail { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPMPAgency> AssnPMPAgencies { get; set; } = new List<AssnPMPAgency>();
}
