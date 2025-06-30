using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.ProjectDetail
{
    public class BuildingInformationParamModel
    {
        public List<BuildingParkingInformationModal> BuildingInformationData { get; set; }
        public int CaseId { get; set; }

    }

    public class BuildingParkingInformationModal
    {
        public string BuildingFileNumber { get; set; }
        public string BuildingNumber { get; set; }
        public int BuildingId { get; set; }
        public int CaseId { get; set; }
        public int PropSnapshotID { get; set; }
        public bool ParkingAvailableAtbuildingLevel { get; set; }
        public int? ResindentialSpaces { get; set; }
        public int? AccessibleSpaces { get; set; }
        public int? VanAccessibleSpaces { get; set; }
        public int? StandardCommercialSpaces { get; set; }
        public int? CommercialAccessibleSpaces { get; set; }
        public int? CommercialVanAccessibleSpaces { get; set; }
        public int? ElectricVehicleChargingStations { get; set; }
        public int? TotalResidentialParking { get; set; }
        public int? TotalCommercialParking { get; set; }
        public int? CommercialVehicleChargingStations { get; set; }
        public int? StandardAccessibleChargingStations { get; set; }
        public int? TotalNumberofElectricVehicleChargingStations { get; set; }
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


        public string TypeOfConstruction { get; set; }
        public string TypeOfOccupancy { get; set; }
        public string BuildingPermitNumber { get; set; }
        public string ApplicableCodes { get; set; }
        public string LutApplicableAccessibilityStandardId { get; set; }

        public int? NumberOfUnits { get; set; }
        public string NumberOfMobilityUnits { get; set; }
        public string NumberOfCommunicationUnits { get; set; }
        public int? NumberOfAdaptableUnits { get; set; }


        public bool IsElevator { get; set; }
        public int? NumberOfFloors { get; set; }
        public int? NumberOfParkings { get; set; }




    }


    public class ParkingInformation
    {
        public string ParkingData { get; set; }
        public string BuildingFileNumber { get; set; }
        public List<string> BuildingList { get; set; }
        public List<BuildingParkingInformationModal> BuildingInformationData { get; set; }

    }

    public class PermitNumberInformation
    {
        public string PermitData { get; set; }
        public string PermitNumber { get; set; }
        public List<string> PermitList { get; set; }
    }

}
