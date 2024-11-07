using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_QRAUWaitList
{
    public string YearQR { get; set; } = null!;

    public string? MaxYearQR { get; set; }

    public int? QuarterlyReportID { get; set; }

    public int? MaxQrID { get; set; }

    public DateTime QRReportCreateDate { get; set; }

    public int? ProjectID { get; set; }

    public int? PropertyID { get; set; }

    public string? Project_Name { get; set; }

    public string? Property_Name { get; set; }

    public int? QRAUWaitListID { get; set; }

    public int? AUWaitListID { get; set; }

    public string? FileNumber { get; set; }

    public string? ApplicationType { get; set; }

    public DateTime? ApplicationDateTime { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? WaitListPosition { get; set; }

    public string? UnitType { get; set; }

    public string? Bedroom { get; set; }

    public string? Bathroom { get; set; }

    public string? AccessibilityRequest { get; set; }

    public bool? IsApplicantMovedIn { get; set; }

    public DateTime? MovedInDate { get; set; }

    public int? MoveInUnitPropSnapShotID { get; set; }

    public string? MoveInUnitNum { get; set; }

    public DateTime? TenantAUTransferDate { get; set; }

    public string? ApplicantMovedUnit { get; set; }

    public string? NatureOfRARequests { get; set; }

    public DateTime? TenantPutOnAUTrasnferWaitLIstDate { get; set; }

    public string? _126_100_WaitListApplicantFirstName { get; set; }

    public string? _126_200_WaitListApplicantMiddleInitial { get; set; }

    public string? _126_300_WaitListApplicantLastName { get; set; }

    public DateTime? _127_100_WaitListApplicationDateTime { get; set; }

    public DateTime? _127_200_WaitListMoveInDate { get; set; }

    public int? _321_000_AccessibleUnitWaitListPosition { get; set; }

    public int? _322_000_LotteryPosition { get; set; }

    public string? _323_000_ConventionalWaitListPosition { get; set; }

    public DateTime? _324_000_WaitListMoveInDate { get; set; }

    public string? _325_000_ApplicantMovedIntoAccessbleOrConventionalUnit { get; set; }

    public DateTime? _326_000_DateTenantPlacedOnAUTransferList { get; set; }

    public string _327_000_DidTenantMakeReasonableAccommodationOrModificationForAccessibilityFeatures { get; set; } = null!;

    public string _327_100_DateTenantMakeReasonableAccommodationOrModificationForAccessibilityFeatures { get; set; } = null!;
}
