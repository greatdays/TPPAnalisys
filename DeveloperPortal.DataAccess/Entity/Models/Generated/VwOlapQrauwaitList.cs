using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapQrauwaitList
{
    public string YearQr { get; set; } = null!;

    public string? MaxYearQr { get; set; }

    public int? QuarterlyReportId { get; set; }

    public int? MaxQrId { get; set; }

    public DateTime QrreportCreateDate { get; set; }

    public int? ProjectId { get; set; }

    public int? PropertyId { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyName { get; set; }

    public int? QrauwaitListId { get; set; }

    public int? AuwaitListId { get; set; }

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

    public int? MoveInUnitPropSnapShotId { get; set; }

    public string? MoveInUnitNum { get; set; }

    public DateTime? TenantAutransferDate { get; set; }

    public string? ApplicantMovedUnit { get; set; }

    public string? NatureOfRarequests { get; set; }

    public DateTime? TenantPutOnAutrasnferWaitListDate { get; set; }

    public string? _126100WaitListApplicantFirstName { get; set; }

    public string? _126200WaitListApplicantMiddleInitial { get; set; }

    public string? _126300WaitListApplicantLastName { get; set; }

    public DateTime? _127100WaitListApplicationDateTime { get; set; }

    public DateTime? _127200WaitListMoveInDate { get; set; }

    public int? _321000AccessibleUnitWaitListPosition { get; set; }

    public int? _322000LotteryPosition { get; set; }

    public string? _323000ConventionalWaitListPosition { get; set; }

    public DateTime? _324000WaitListMoveInDate { get; set; }

    public string? _325000ApplicantMovedIntoAccessbleOrConventionalUnit { get; set; }

    public DateTime? _326000DateTenantPlacedOnAutransferList { get; set; }

    public string _327000DidTenantMakeReasonableAccommodationOrModificationForAccessibilityFeatures { get; set; } = null!;

    public string _327100DateTenantMakeReasonableAccommodationOrModificationForAccessibilityFeatures { get; set; } = null!;
}
