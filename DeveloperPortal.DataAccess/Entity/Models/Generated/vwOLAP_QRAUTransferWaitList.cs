using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_QRAUTransferWaitList
{
    public string YearQR { get; set; } = null!;

    public string? MaxYearQR { get; set; }

    public int? QuarterlyReportID { get; set; }

    public DateTime QRReportCreateDate { get; set; }

    public int? ProjectID { get; set; }

    public int? PropertyID { get; set; }

    public string? Project_name { get; set; }

    public string? Property_name { get; set; }

    public int? AUTransferWaitListID { get; set; }

    public int? QRAUTransferWaitListID { get; set; }

    public string? FileNumber { get; set; }

    public int? CurrentUnitPropSnapShotID { get; set; }

    public string? CurrentUnitStatus { get; set; }

    public string? CurrentUnitNumber { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? TransferRequestDate { get; set; }

    public string IsPreviousAUWaitList { get; set; } = null!;

    public DateTime? AccessibilieWaitListDate { get; set; }

    public string? UnitType { get; set; }

    public string? AccessibilityRequest { get; set; }

    public string? Bedroom { get; set; }

    public string? Bathroom { get; set; }

    public string IsTransferred { get; set; } = null!;

    public DateTime? MovedInDate { get; set; }

    public string? MoveInSiteAddress { get; set; }

    public int? MoveInUnitPropSnapShotID { get; set; }

    public string? MoveInUnitNum { get; set; }

    public string? TransferReason { get; set; }

    public DateTime? ReasonDate { get; set; }

    public string? Comment { get; set; }

    public int? MaxQrID { get; set; }

    public string? _132_100_TransferListTenantFirstName { get; set; }

    public string _132_200_TransferListTenantMiddleInitial { get; set; } = null!;

    public string? _132_300_TransferListTenantLastName { get; set; }

    public string _133_100_TransferRequestDate { get; set; } = null!;

    public string? _316_000_TenantCurrentUnitNumber { get; set; }

    public string _317_000_TenantPreviouslyOnAccessibleUnitWaitlist { get; set; } = null!;

    public string _318_000_DateWhenTenantPlacedOnAccessibleUnitWaitlist { get; set; } = null!;

    public string _319_000_DateTenantOnAUTransferListMovesIntoAU { get; set; } = null!;

    public string _320_000_NewAUUnitAddress { get; set; } = null!;

    public string _320_100_NewUnitNumber { get; set; } = null!;
}
