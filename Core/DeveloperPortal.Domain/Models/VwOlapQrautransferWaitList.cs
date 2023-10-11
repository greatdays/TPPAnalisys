using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapQrautransferWaitList
{
    public int? ProjectSiteId { get; set; }

    public int QuarterlyReportId { get; set; }

    public string? Quarter { get; set; }

    public int? Year { get; set; }

    public DateTime QrcreatedOn { get; set; }

    public DateTime? QrsubmittedOn { get; set; }

    public DateTime? QrreviwedOn { get; set; }

    public string? Action { get; set; }

    public int QrautransferWaitListId { get; set; }

    public string? TenantCurrentUnit { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? TransferRequestDate { get; set; }

    public bool? IsPreviousAuwaitList { get; set; }

    public DateTime? AccessibilieWaitListDate { get; set; }

    public string? UnitType { get; set; }

    public string? AccessibilityRequest { get; set; }

    public string? TotalBedroom { get; set; }

    public string? TotalBathroom { get; set; }

    public bool IsTransferred { get; set; }

    public DateTime? MovedInDate { get; set; }

    public int? MoveInProjectSiteId { get; set; }

    public string? TenantMovedUnit { get; set; }

    public string? Reason { get; set; }

    public DateTime? ReasonDate { get; set; }

    public string? Comment { get; set; }
}
