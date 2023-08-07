using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class QrprojectSiteUpcomingUnitVacancy
{
    public int QrprojectSiteUpcomingUnitVacancyId { get; set; }

    public int QuarterlyReportId { get; set; }

    public int ProjectSiteUpcomingUnitVacancyId { get; set; }

    public bool IsUnitBecomeVacant { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ProjectSiteUpcomingUnitVacancy ProjectSiteUpcomingUnitVacancy { get; set; } = null!;

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;
}
