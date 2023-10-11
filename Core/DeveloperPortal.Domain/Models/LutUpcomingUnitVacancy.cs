using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutUpcomingUnitVacancy
{
    public int LutUpcomingUnitVacancyId { get; set; }

    public string UpcomingUnitVacancy { get; set; } = null!;

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<QrupcomingUnitVacancy> QrupcomingUnitVacancies { get; set; } = new List<QrupcomingUnitVacancy>();

    public virtual ICollection<UpcomingUnitVacancy> UpcomingUnitVacancies { get; set; } = new List<UpcomingUnitVacancy>();
}
