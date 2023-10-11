using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class UpcomingUnitVacancy
{
    public int UpcomingUnitVacancyId { get; set; }

    public int ProjSitePropSnapShotId { get; set; }

    public bool IsUnitBecomeVacant { get; set; }

    public int? UnitPropSnapShotId { get; set; }

    public DateTime? NoticeDate { get; set; }

    public DateTime? ExpectedVacancyDate { get; set; }

    public DateTime? ActualVacancyDate { get; set; }

    public bool? IsQualifiedAutl { get; set; }

    public int? CurrentUnitPropSnapShotId { get; set; }

    public int? LutUpcomingUnitVacancyId { get; set; }

    public string? Other { get; set; }

    public bool? IsQualifiedAuwl { get; set; }

    public string? Auwlno { get; set; }

    public bool? IsQualifiedNonPwdinAu { get; set; }

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

    public virtual ICollection<QrupcomingUnitVacancy> QrupcomingUnitVacancies { get; set; } = new List<QrupcomingUnitVacancy>();

    public virtual PropSnapshot? UnitPropSnapShot { get; set; }
}
