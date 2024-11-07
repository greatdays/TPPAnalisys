using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QuarterlyReport
{
    public int QuarterlyReportID { get; set; }

    public long? ServiceRequestID { get; set; }

    public int? PropSnapShotID { get; set; }

    public int? Year { get; set; }

    public string? Quarter { get; set; }

    public int? SubmittedCaseLogID { get; set; }

    public int? ReviewedCaseLogID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual PropSnapshot? PropSnapShot { get; set; }

    public virtual ICollection<QRAUTransferWaitList> QRAUTransferWaitLists { get; set; } = new List<QRAUTransferWaitList>();

    public virtual ICollection<QRAUWaitList> QRAUWaitLists { get; set; } = new List<QRAUWaitList>();

    public virtual ICollection<QREffectiveCommunication> QREffectiveCommunications { get; set; } = new List<QREffectiveCommunication>();

    public virtual ICollection<QRFairHousing> QRFairHousings { get; set; } = new List<QRFairHousing>();

    public virtual ICollection<QRGrievanceLog> QRGrievanceLogs { get; set; } = new List<QRGrievanceLog>();

    public virtual ICollection<QROccupancyUnit> QROccupancyUnits { get; set; } = new List<QROccupancyUnit>();

    public virtual ICollection<QRProjectSiteFutureWaitList> QRProjectSiteFutureWaitLists { get; set; } = new List<QRProjectSiteFutureWaitList>();

    public virtual ICollection<QRProjectSiteNoChangeReport> QRProjectSiteNoChangeReports { get; set; } = new List<QRProjectSiteNoChangeReport>();

    public virtual ICollection<QRProjectSiteUpcomingUnitVacancy> QRProjectSiteUpcomingUnitVacancies { get; set; } = new List<QRProjectSiteUpcomingUnitVacancy>();

    public virtual ICollection<QRReasonableAccommodation> QRReasonableAccommodations { get; set; } = new List<QRReasonableAccommodation>();

    public virtual ICollection<QRUpcomingUnitVacancy> QRUpcomingUnitVacancies { get; set; } = new List<QRUpcomingUnitVacancy>();

    public virtual ICollection<QRUtilizationSurvey> QRUtilizationSurveys { get; set; } = new List<QRUtilizationSurvey>();

    public virtual CaseLog? ReviewedCaseLog { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }

    public virtual CaseLog? SubmittedCaseLog { get; set; }
}
