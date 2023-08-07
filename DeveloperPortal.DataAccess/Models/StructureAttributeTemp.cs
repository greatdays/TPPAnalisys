using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class StructureAttributeTemp
{
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

    public DateTime? DateOf1stPlanCheckSubmission { get; set; }

    public DateTime? DateOfMostRecentTco { get; set; }

    public DateTime? DateOmostRecentBuildingPermit { get; set; }

    public DateTime? DateOfMostRecentPlanCheckSubmission { get; set; }

    public DateTime? DateOfCurrentPlanCheckSubmission { get; set; }

    public DateTime? DateOf1stTco { get; set; }

    public DateTime? DateOfCurrentBuildingPermitNumber { get; set; }

    public string? CurrentBuldingPermitNumber { get; set; }

    public DateTime? DateOfCurrentTco { get; set; }

    public DateTime? DateOfCurrentCofO { get; set; }

    public DateTime? DateOfRetrofitPlanCheckSubmission { get; set; }

    public DateTime? DateOfCofOpostRetrofit { get; set; }

    public DateTime? DateOfBuildingPermitFinaled { get; set; }

    public string? DbsretrofitBuildingPermitNumber { get; set; }

    public DateTime? DateOf1stBuildingPermit { get; set; }

    public DateTime? DateOf1stCofO { get; set; }

    public DateTime? DateOfMostRecentCofO { get; set; }

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
}
