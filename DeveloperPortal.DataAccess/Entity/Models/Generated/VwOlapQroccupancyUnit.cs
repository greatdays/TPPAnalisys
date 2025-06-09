using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapQroccupancyUnit
{
    public string YearQr { get; set; } = null!;

    public string? MaxYearQr { get; set; }

    public int? QuarterlyReportId { get; set; }

    public DateTime QrreportCreateDate { get; set; }

    public int? ProjectId { get; set; }

    public int PropertyId { get; set; }

    public int? MaxQrId { get; set; }

    public int QroccupancyUnitId { get; set; }

    public int? UnitPropSnapShotId { get; set; }

    public string? FileNumber { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyName { get; set; }

    public string? UnitNum { get; set; }

    public string? Address { get; set; }

    public string? UnitHouseNum { get; set; }

    public string UnitHouseFracNum { get; set; } = null!;

    public string UnitLutPreDirCd { get; set; } = null!;

    public string UnitStreetName { get; set; } = null!;

    public string UnitLutStreetTypeCd { get; set; } = null!;

    public string UnitPostDirCd { get; set; } = null!;

    public string UnitCity { get; set; } = null!;

    public string UnitLutStateCd { get; set; } = null!;

    public string UnitZip { get; set; } = null!;

    public string? UnitType { get; set; }

    public string? Bedroom { get; set; }

    public string? Bathroom { get; set; }

    public string? Ami { get; set; }

    public string ProgramEligibilityPsh { get; set; } = null!;

    public bool? IsCesunit { get; set; }

    public string IsOccupied { get; set; } = null!;

    public string? PreviousLiveInProperty { get; set; }

    public string? PreviousUnitNum { get; set; }

    public string RelocationDate { get; set; } = null!;

    public string? QualifiedTenantCurrentUnitNumber { get; set; }

    public string? QualifiedTenantCurrentUnitAddress { get; set; }

    public string IsAvailabeFromAutransferList { get; set; } = null!;

    public string IsAvailableFromAuwaitList { get; set; } = null!;

    public string? AuwaitListPosition { get; set; }

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

    public string? _056100NameOfCurrentTenant { get; set; }

    public string _056101FirstNameOfCurrentTenant { get; set; } = null!;

    public string _056102MiddleInitialOfCurrentTenant { get; set; } = null!;

    public string _056103LastNameOfCurrentTenant { get; set; } = null!;

    public string _056110IsOccupiedByPwdWhoNeedsTheFeatures { get; set; } = null!;

    public string _056120IsLeaseAddendum { get; set; } = null!;

    public string _056130BeginningDateMostCurrentAddendum { get; set; } = null!;

    public string _056131DoesTheLeaseAddendumHaveExpirationDate { get; set; } = null!;

    public string _056135ExpirationDateMostCurrentAddendum { get; set; } = null!;

    public string? _056240TenantSelectedFrom { get; set; }

    public string? _226000NumberOfVacantAccessibleUnits { get; set; }

    public string? _226100NumberOfVacantHvunits { get; set; }

    public string? _226200NumberOfVacantAccessibleUnits { get; set; }

    public string _373000MoveInDate { get; set; } = null!;

    public string? _374000TenantSelectedFrom { get; set; }
}
