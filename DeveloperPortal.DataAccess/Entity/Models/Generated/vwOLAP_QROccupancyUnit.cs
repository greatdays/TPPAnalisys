using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_QROccupancyUnit
{
    public string YearQR { get; set; } = null!;

    public string? MaxYearQR { get; set; }

    public int? QuarterlyReportID { get; set; }

    public DateTime QRReportCreateDate { get; set; }

    public int? ProjectID { get; set; }

    public int PropertyID { get; set; }

    public int? MaxQrID { get; set; }

    public int QROccupancyUnitID { get; set; }

    public int? UnitPropSnapShotID { get; set; }

    public string? FileNumber { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyName { get; set; }

    public string? UnitNum { get; set; }

    public string? Address { get; set; }

    public string? UnitHouseNum { get; set; }

    public string UnitHouseFracNum { get; set; } = null!;

    public string UnitLutPreDirCD { get; set; } = null!;

    public string UnitStreetName { get; set; } = null!;

    public string UnitLutStreetTypeCD { get; set; } = null!;

    public string UnitPostDirCD { get; set; } = null!;

    public string UnitCity { get; set; } = null!;

    public string UnitLutStateCD { get; set; } = null!;

    public string UnitZip { get; set; } = null!;

    public string? UnitType { get; set; }

    public string? Bedroom { get; set; }

    public string? Bathroom { get; set; }

    public string? AMI { get; set; }

    public string ProgramEligibility___PSH { get; set; } = null!;

    public bool? IsCESUnit { get; set; }

    public string IsOccupied { get; set; } = null!;

    public string? PreviousLiveInProperty { get; set; }

    public string? PreviousUnitNum { get; set; }

    public string RelocationDate { get; set; } = null!;

    public string? QualifiedTenantCurrentUnitNumber { get; set; }

    public string? QualifiedTenantCurrentUnitAddress { get; set; }

    public string IsAvailabeFromAUTransferList { get; set; } = null!;

    public string IsAvailableFromAUWaitList { get; set; } = null!;

    public string? AUWaitListPosition { get; set; }

    public bool? IsStartTargetedMarket { get; set; }

    public string ReferralRequestDate { get; set; } = null!;

    public string? AgencyName { get; set; }

    public bool? IsReferralRequested { get; set; }

    public string? ReferralRecipientEmail { get; set; }

    public string? ReferralRecipientPhone { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public string MoveInDate { get; set; } = null!;

    public string MoveOutDate { get; set; } = null!;

    public string? TenantSelectedFrom { get; set; }

    public string IsOccupiedWithNeeded { get; set; } = null!;

    public string LeaseAddendumExecutedDate { get; set; } = null!;

    public string LeaseAddendumExpirationDate { get; set; } = null!;

    public string? OccupancyReason { get; set; }

    public string? OtherOccupancyReason { get; set; }

    public string? _056_100_NameOfCurrentTenant { get; set; }

    public string _056_101_FirstNameOfCurrentTenant { get; set; } = null!;

    public string _056_102_MiddleInitialOfCurrentTenant { get; set; } = null!;

    public string _056_103_LastNameOfCurrentTenant { get; set; } = null!;

    public string _056_110_IsOccupiedByPWD_WhoNeedsTheFeatures { get; set; } = null!;

    public string _056_120_IsLeaseAddendum { get; set; } = null!;

    public string _056_130_BeginningDateMostCurrentAddendum { get; set; } = null!;

    public string _056_131_DoesTheLeaseAddendumHaveExpirationDate { get; set; } = null!;

    public string _056_135_ExpirationDateMostCurrentAddendum { get; set; } = null!;

    public string? _056_240_TenantSelectedFrom { get; set; }

    public string? _226_000_NumberOfVacantAccessibleUnits { get; set; }

    public string? _226_100_NumberOfVacantHVUnits { get; set; }

    public string? _226_200_NumberOfVacantAccessibleUnits { get; set; }

    public string _373_000_Move_InDate { get; set; } = null!;

    public string? _374_000_TenantSelectedFrom { get; set; }
}
