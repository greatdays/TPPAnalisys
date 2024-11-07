using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QRProjectSiteUpcomingUnitVacancy
{
    public int QRProjectSiteUpcomingUnitVacancyID { get; set; }

    public int QuarterlyReportID { get; set; }

    public int ProjectSiteUpcomingUnitVacancyID { get; set; }

    public bool IsUnitBecomeVacant { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ProjectSiteUpcomingUnitVacancy ProjectSiteUpcomingUnitVacancy { get; set; } = null!;

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;
}
