using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGrievanceReferralAgency
{
    public int LutGrievanceReferralAgencyID { get; set; }

    public string AgencyName { get; set; } = null!;

    public int? ViewOrder { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Grievance> GrievancesNavigation { get; set; } = new List<Grievance>();

    public virtual ICollection<GrievanceAppeal> GrievanceAppeals { get; set; } = new List<GrievanceAppeal>();

    public virtual ICollection<Grievance> Grievances { get; set; } = new List<Grievance>();
}
