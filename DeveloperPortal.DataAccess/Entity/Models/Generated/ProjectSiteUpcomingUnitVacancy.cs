using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectSiteUpcomingUnitVacancy
{
    public int ProjectSiteUpcomingUnitVacancyID { get; set; }

    public int ProjSitePropSnapShotID { get; set; }

    public bool? IsUnitBecomeVacant { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual PropSnapshot ProjSitePropSnapShot { get; set; } = null!;

    public virtual ICollection<QRProjectSiteUpcomingUnitVacancy> QRProjectSiteUpcomingUnitVacancies { get; set; } = new List<QRProjectSiteUpcomingUnitVacancy>();
}
