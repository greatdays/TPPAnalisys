using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapQrgrievanceLog
{
    public int? ProjectSiteId { get; set; }

    public int QuarterlyReportId { get; set; }

    public string? Quarter { get; set; }

    public int? Year { get; set; }

    public DateTime QrcreatedOn { get; set; }

    public DateTime? QrsubmittedOn { get; set; }

    public DateTime? QrreviwedOn { get; set; }

    public string? Action { get; set; }

    public int QrgrievanceLogId { get; set; }

    public int? ProjSitePropSnapShotId { get; set; }

    public bool IsReasonableAccommodation { get; set; }

    public bool IsEffectiveCommunication { get; set; }

    public bool IsFairHousingComplaint { get; set; }

    public string UserType { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? ApplicantAddress { get; set; }

    public string? TenantCurrentUnit { get; set; }

    public DateTime? GrievanceDate { get; set; }

    public string? GrievanceDetail { get; set; }

    public DateTime? DeterminationDate { get; set; }

    public string? DeterminationStatus { get; set; }

    public string? DeterminationDetail { get; set; }

    public DateTime? AnticipatedDate { get; set; }

    public DateTime? ImplementationDate { get; set; }

    public string? ImplementationInformation { get; set; }

    public bool IsFairHousingComplaintFiled { get; set; }

    public bool IsHudcompliantFiled { get; set; }

    public bool IsHcidlacompliantFiled { get; set; }
}
