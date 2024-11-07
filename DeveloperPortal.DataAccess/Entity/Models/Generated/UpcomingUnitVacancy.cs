using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class UpcomingUnitVacancy
{
    public int UpcomingUnitVacancyID { get; set; }

    public int ProjSitePropSnapShotID { get; set; }

    public bool IsUnitBecomeVacant { get; set; }

    public int? UnitPropSnapShotID { get; set; }

    public DateOnly? NoticeDate { get; set; }

    public DateOnly? ExpectedVacancyDate { get; set; }

    public DateOnly? ActualVacancyDate { get; set; }

    public bool? IsQualifiedAUTL { get; set; }

    public int? CurrentUnitPropSnapShotID { get; set; }

    public int? LutUpcomingUnitVacancyID { get; set; }

    public string? Other { get; set; }

    public bool? IsQualifiedAUWL { get; set; }

    public string? AUWLNo { get; set; }

    public bool? IsQualifiedNonPWDInAU { get; set; }

    public bool IsDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual PropSnapshot? CurrentUnitPropSnapShot { get; set; }

    public virtual LutUpcomingUnitVacancy? LutUpcomingUnitVacancy { get; set; }

    public virtual PropSnapshot ProjSitePropSnapShot { get; set; } = null!;

    public virtual ICollection<QRUpcomingUnitVacancy> QRUpcomingUnitVacancies { get; set; } = new List<QRUpcomingUnitVacancy>();

    public virtual PropSnapshot? UnitPropSnapShot { get; set; }
}
