using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QuarterlyReport
{
    public int QuarterlyReportId { get; set; }

    public long? ServiceRequestId { get; set; }

    public int? PropSnapShotId { get; set; }

    public int? Year { get; set; }

    public string? Quarter { get; set; }

    public int? SubmittedCaseLogId { get; set; }

    public int? ReviewedCaseLogId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual PropSnapshot? PropSnapShot { get; set; }

    public virtual ICollection<QrautransferWaitList> QrautransferWaitLists { get; set; } = new List<QrautransferWaitList>();

    public virtual ICollection<QrauwaitList> QrauwaitLists { get; set; } = new List<QrauwaitList>();

    public virtual ICollection<QreffectiveCommunication> QreffectiveCommunications { get; set; } = new List<QreffectiveCommunication>();

    public virtual ICollection<QrfairHousing> QrfairHousings { get; set; } = new List<QrfairHousing>();

    public virtual ICollection<QrgrievanceLog> QrgrievanceLogs { get; set; } = new List<QrgrievanceLog>();

    public virtual ICollection<QrnewStaffContactInfo> QrnewStaffContactInfos { get; set; } = new List<QrnewStaffContactInfo>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnits { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<QrprojectSiteFutureWaitList> QrprojectSiteFutureWaitLists { get; set; } = new List<QrprojectSiteFutureWaitList>();

    public virtual ICollection<QrprojectSiteNoChangeReport> QrprojectSiteNoChangeReports { get; set; } = new List<QrprojectSiteNoChangeReport>();

    public virtual ICollection<QrprojectSiteUpcomingUnitVacancy> QrprojectSiteUpcomingUnitVacancies { get; set; } = new List<QrprojectSiteUpcomingUnitVacancy>();

    public virtual ICollection<QrreasonableAccommodation> QrreasonableAccommodations { get; set; } = new List<QrreasonableAccommodation>();

    public virtual ICollection<QrupcomingUnitVacancy> QrupcomingUnitVacancies { get; set; } = new List<QrupcomingUnitVacancy>();

    public virtual ICollection<QrutilizationSurvey> QrutilizationSurveys { get; set; } = new List<QrutilizationSurvey>();

    public virtual CaseLog? ReviewedCaseLog { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }

    public virtual CaseLog? SubmittedCaseLog { get; set; }
}
