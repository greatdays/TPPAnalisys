using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapQrauwaitList
{
    public int? ProjectSiteId { get; set; }

    public int QuarterlyReportId { get; set; }

    public string? Quarter { get; set; }

    public int? Year { get; set; }

    public DateTime QrcreatedOn { get; set; }

    public DateTime? QrsubmittedOn { get; set; }

    public DateTime? QrreviwedOn { get; set; }

    public string? Action { get; set; }

    public int QrauwaitListId { get; set; }

    public int? HrmapplicationId { get; set; }

    public string? TenantCurrentUnit { get; set; }

    public string? ApplicationType { get; set; }

    public DateTime? ApplicationDateTime { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public int? AuwaitListPosition { get; set; }

    public int? LotteryPosition { get; set; }

    public int? WaitListPosition { get; set; }

    public string? UnitType { get; set; }

    public string? TotalBedroom { get; set; }

    public string? TotalBathroom { get; set; }

    public string? AccessibilityRequest { get; set; }

    public bool? IsApplicantMovedIn { get; set; }

    public DateTime? MovedInDate { get; set; }

    public string? TenantMovedUnit { get; set; }

    public string? ApplicantMovedUnit { get; set; }

    public DateTime? TenantAutransferDate { get; set; }

    public string? NatureOfRarequests { get; set; }
}
