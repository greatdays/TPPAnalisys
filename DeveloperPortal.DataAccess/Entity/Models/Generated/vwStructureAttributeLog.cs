using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwStructureAttributeLog
{
    public int ProjectId { get; set; }

    public int? PsProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? PsFileNumber { get; set; }

    public string? PsHimsnumber { get; set; }

    public string? PsPrimaryApn { get; set; }

    public string? PsSiteAddress { get; set; }

    public int StructureAttributeLogId { get; set; }

    public int StructureAttributeId { get; set; }

    public int PropSnapshotId { get; set; }

    public string? Himsapn { get; set; }

    public string? AcHpassociatedApn { get; set; }

    public string? LutVoilationChecklistId { get; set; }

    public int? BuildingPermitNumber { get; set; }

    public string? LutApplicableAccessibilityStandardId { get; set; }

    public int? NumberOfFloors { get; set; }

    public bool? Elevator { get; set; }

    public int? SharedParkingLots { get; set; }

    public bool? ParkingAvailableAtbuildingLevel { get; set; }

    public int? BuildingType { get; set; }

    public bool? AssignedResidentialParking { get; set; }

    public string? FirstBuldingPermitNumber { get; set; }

    public string? ResidentialParkingRatio { get; set; }

    public string? SeniorDesignated { get; set; }

    public string? MostRecentBuldingPermitNumber { get; set; }

    public DateOnly? DateOf1stPlanCheckSubmission { get; set; }

    public DateOnly? DateOfMostRecentTco { get; set; }

    public DateOnly? DateOmostRecentBuildingPermit { get; set; }

    public DateOnly? DateOfMostRecentPlanCheckSubmission { get; set; }

    public DateOnly? DateOfCurrentPlanCheckSubmission { get; set; }

    public DateOnly? DateOf1stTco { get; set; }

    public DateOnly? DateOfCurrentBuildingPermitNumber { get; set; }

    public string? CurrentBuldingPermitNumber { get; set; }

    public DateOnly? LadbsissuedTcodate { get; set; }

    public DateOnly? DateOfCurrentCofO { get; set; }

    public DateOnly? DateOfRetrofitPlanCheckSubmission { get; set; }

    public DateOnly? DateOfCofOpostRetrofit { get; set; }

    public DateOnly? DateOfBuildingPermitFinaled { get; set; }

    public string? DbsretrofitBuildingPermitNumber { get; set; }

    public DateOnly? DateOf1stBuildingPermit { get; set; }

    public DateOnly? DateOf1stCofO { get; set; }

    public DateOnly? DateOfMostRecentCofO { get; set; }

    public string? MobilityDesignatedUnitNumbers { get; set; }

    public string? Fha11adesignatedUnitNumbers { get; set; }

    public int? UnitDesignationTotal { get; set; }

    public string? HearingVisionDesignatedUnitNumbers { get; set; }

    public string? EnhancedAccessibilityDesignatedUnitNumbers { get; set; }

    public double? PercentageOfTotal { get; set; }

    public int? ResindentialSpaces { get; set; }

    public int? AccessibleSpaces { get; set; }

    public int? TotalResidentialParking { get; set; }

    public int? VanAccessibleSpaces { get; set; }

    public int? StandardCommercialSpaces { get; set; }

    public int? CommercialAccessibleSpaces { get; set; }

    public int? TotalCommercialParking { get; set; }

    public int? CommercialVanAccessibleSpaces { get; set; }

    public int? ElectricVehicleChargingStations { get; set; }

    public int? StandardAccessibleChargingStations { get; set; }

    public int? TotalNumberOfElectricVehicleChargingStations { get; set; }

    public int? VanAccessibleChargingStations { get; set; }

    public int? AmbulatoryChargingStations { get; set; }

    public int? StandardVisitorSpaces { get; set; }

    public int? VisitorAccessibleSpaces { get; set; }

    public int? TotalVisitorParking { get; set; }

    public int? VisitorVanAccessibleSpaces { get; set; }

    public int? CommercialElectricVanAccessibleChargingStation { get; set; }

    public int? CommercialElectricAmbulatoryChargingStation { get; set; }

    public int? TotalNumberofCommercialElectricVehicleChargingStations { get; set; }

    public int? CommercialElectricStandardAccessibleChargingStation { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? StructureId { get; set; }

    public int? LutFhastandardId { get; set; }

    public DateTime? DateOfFco { get; set; }

    public int? LutStructureTypeId { get; set; }

    public string? OtherStructureType { get; set; }

    public DateTime? DateOf1stPlanCheckSubmissionForConversionToResidential { get; set; }

    public DateTime? DateOf1stBuildingPermitForConversionToResidential { get; set; }

    public string? FirstPlanCheckSubmissionForConversionToResidential { get; set; }

    public DateTime? DateOf1stTcoforConversionToResidential { get; set; }

    public DateTime? DateOf1stCoFoforConversionToResidential { get; set; }

    public DateTime? DateOfCurrentBuildingPermitFinaled { get; set; }

    public DateOnly? ClearedByAcHpforTco { get; set; }

    public bool? RecommendedForCertification { get; set; }

    public int? LutBuildingTypeId { get; set; }

    public string? DesignatedManagerUnits { get; set; }

    public string? ModificationsGrantedByLadbsunitsBuildings { get; set; }

    public string? BuildingDescription { get; set; }

    public string? HistoricBuildingPermitNumber { get; set; }

    public DateTime? HistoricBuildingCofOdate { get; set; }

    public DateTime? HistoricBuildingPermitApplicationDate { get; set; }

    public DateTime? CurrentBuildingPermitApplicationDate { get; set; }

    public DateTime? HistoricBuildingPermitIssueDate { get; set; }

    public string? HistoricBuildingPermitResearchNotes { get; set; }

    public string? CurrentBuildingPermitResearchNotes { get; set; }

    public int? CommercialVehicleChargingStations { get; set; }

    public string? Ladbsjson { get; set; }
}
