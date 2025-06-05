using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapQrautransferWaitList
{
    public string YearQr { get; set; } = null!;

    public string? MaxYearQr { get; set; }

    public int? QuarterlyReportId { get; set; }

    public DateTime QrreportCreateDate { get; set; }

    public int? ProjectId { get; set; }

    public int? PropertyId { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyName { get; set; }

    public int? AutransferWaitListId { get; set; }

    public int? QrautransferWaitListId { get; set; }

    public string? FileNumber { get; set; }

    public int? CurrentUnitPropSnapShotId { get; set; }

    public string? CurrentUnitStatus { get; set; }

    public string? CurrentUnitNumber { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? TransferRequestDate { get; set; }

    public string IsPreviousAuwaitList { get; set; } = null!;

    public DateTime? AccessibilieWaitListDate { get; set; }

    public string? UnitType { get; set; }

    public string? AccessibilityRequest { get; set; }

    public string? Bedroom { get; set; }

    public string? Bathroom { get; set; }

    public string IsTransferred { get; set; } = null!;

    public DateTime? MovedInDate { get; set; }

    public string? MoveInSiteAddress { get; set; }

    public int? MoveInUnitPropSnapShotId { get; set; }

    public string? MoveInUnitNum { get; set; }

    public string? TransferReason { get; set; }

    public DateTime? ReasonDate { get; set; }

    public string? Comment { get; set; }

    public int? MaxQrId { get; set; }

    public string? _132100TransferListTenantFirstName { get; set; }

    public string _132200TransferListTenantMiddleInitial { get; set; } = null!;

    public string? _132300TransferListTenantLastName { get; set; }

    public string _133100TransferRequestDate { get; set; } = null!;

    public string? _316000TenantCurrentUnitNumber { get; set; }

    public string _317000TenantPreviouslyOnAccessibleUnitWaitlist { get; set; } = null!;

    public string _318000DateWhenTenantPlacedOnAccessibleUnitWaitlist { get; set; } = null!;

    public string _319000DateTenantOnAutransferListMovesIntoAu { get; set; } = null!;

    public string _320000NewAuunitAddress { get; set; } = null!;

    public string _320100NewUnitNumber { get; set; } = null!;
}
