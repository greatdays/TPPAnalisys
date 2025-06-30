using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapConstructionDetail
{
    public int CaseId { get; set; }

    public long ServiceRequestId { get; set; }

    public int? PropSnapShotId { get; set; }

    public string Type { get; set; } = null!;

    public int? ProjectSiteId { get; set; }

    public int? ProjectId { get; set; }

    public string Status { get; set; } = null!;

    public string? Apn { get; set; }

    public string Hims { get; set; } = null!;

    public string AcHp { get; set; } = null!;

    public string ProjectName { get; set; } = null!;

    public string PropertyName { get; set; } = null!;

    public string ProjectAddress { get; set; } = null!;

    public string? _073DateNacinspectionScheduled { get; set; }

    public string? _074StartDateOfSurvey { get; set; }

    public string? _074020EndDateOfSurvey { get; set; }

    public string? _075LinktoNacinspectionReport { get; set; }

    public string? _076DateOfNacinspectionReport { get; set; }

    public string? _081ProposedRetrofitCommenceDate { get; set; }

    public DateTime? _081200NoticeToProceedWithRetrofitDate { get; set; }

    public string? _088100DateSiteRetrofitFinalAcHpinspectionApproved { get; set; }

    public string? _088200DateProjectRetrofitFinalAcHpinspectionApproved { get; set; }

    public string? _089100DateSiteAcHpfinalNewConstructionInspApproved { get; set; }

    public string? _089200DateProjectAcHpfinalNewConstructionInspApproved { get; set; }

    public string? _089300DateSiteAcHpfinalRehabInspApproved { get; set; }

    public string? _089400DateProjectAcHpfinalRehabInspApproved { get; set; }

    public string _900DateCertificationAccessibilityissues { get; set; } = null!;

    public string _901DateCertificationAccessibilityissues { get; set; } = null!;

    public string _196AssignedRcs { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public string ProjectName1 { get; set; } = null!;

    public string ProjectAddress1 { get; set; } = null!;

    public string? CreatedOn { get; set; }

    public string? ModifiedOn { get; set; }

    public string? AcHpfileProjectNumber { get; set; }

    public string? _5251DateOf1stPlanCheckSubmission { get; set; }

    public string? _5252DateOf1stBuildingPermit { get; set; }

    public int? _5253BuildingPermitNumber { get; set; }

    public string? _5254DateOf1stTco { get; set; }

    public string? _5255DateOf1stCofO { get; set; }

    public DateTime? _5265DateOf1stCoFoforConversionToResidential { get; set; }

    public string? _5271DateOfMostRecentPlanCheckSubmission { get; set; }

    public string? _5272DateOmostRecentBuildingPermit { get; set; }

    public string? _5273MostRecentBuldingPermitNumber { get; set; }

    public DateOnly? _5274DateOfMostRecentTco { get; set; }

    public DateOnly? _5275DateOfMostRecentCofO { get; set; }

    public DateOnly? _5276DateOfBuildingPermitFinaled { get; set; }

    public string? _5281DateOfCurrentPlanCheckSubmission { get; set; }

    public string? _5282DateOfCurrentBuildingPermitNumber { get; set; }

    public string? _5283CurrentBuldingPermitNumberr { get; set; }

    public DateOnly? _5284DateOfCurrentTco { get; set; }

    public DateOnly? _5285DateOfCurrentCofO { get; set; }

    public DateTime? _5286DateOfCurrentBuildingPermitFinaled { get; set; }

    public string? _5291DateOfRetrofitPlanCheckSubmission { get; set; }

    public string? _5292DateOfCurrentBuildingPermitNumber { get; set; }

    public string? _5293DbsretrofitBuildingPermitNumber { get; set; }

    public string? _5294DateOfCofOpostRetrofit { get; set; }

    public string? _5295DateOfBuildingPermitFinaled { get; set; }

    public double? _649AreainSquareFeet { get; set; }

    public string? _650Floorplantype { get; set; }

    public string _652Currentstatusofprojectcase { get; set; } = null!;

    public string _653IsParkingAvailableAtBuilding { get; set; } = null!;

    public string _654SharedparkingLots { get; set; } = null!;

    public double? _655ResidentialParkingRatio { get; set; }

    public bool? _656AssignedResidentialParking { get; set; }

    public string? _657ApplicableAccessibilityStandard { get; set; }

    public bool? _658IsthisaPreVcadevelopment { get; set; }

    public string _659TotalNumberFha11aunitsRequired { get; set; } = null!;

    public int? _660MaximumMobilityCsacount { get; set; }

    public string? _661UnitsNumbersForAllTypesMobility { get; set; }

    public string? _661UnitsNumbersForAllTypesMobility1 { get; set; }

    public int? _661UnitsNumbersForAllTypesUnitDesignation { get; set; }

    public string? _661UnitsNumbersForAllTypesHearingVision { get; set; }

    public string? _661UnitsNumbersForAllTypesEnhancedAccessibility { get; set; }

    public string _661UnitsNoForAllTypes { get; set; } = null!;

    public string? _662HudchecklistforSelection1perBuiliding { get; set; }

    public string _663IsParkingAvailableAtBuilding { get; set; } = null!;

    public int? _664BuildingType { get; set; }

    public string _665AssignedResidentialParking { get; set; } = null!;

    public string? _666ResidentialParkingRatio { get; set; }

    public int? _667TotalResidentialParking { get; set; }

    public int? _668Residentialstandardaccessibleparkingspaces { get; set; }

    public int? _669VanAccessibleSpaces { get; set; }

    public int? _670TotalResidentialParking { get; set; }

    public int? _671StandardCommercialSpaces { get; set; }

    public int? _672CommercialAccessibleSpaces { get; set; }

    public int? _673CommercialVanAccessibleSpaces { get; set; }

    public int? _674CommercialVanAccessibleSpaces { get; set; }

    public int? _675StandardVisitorSpaces { get; set; }

    public int? _676VisitorAccessibleSpaces { get; set; }

    public int? _677VisitorVanAccessibleSpaces { get; set; }

    public int? _678VisitorVanAccessibleSpaces { get; set; }

    public int? _679CommercialElectricVanAccessibleChargingStation { get; set; }

    public int? _680CommercialElectricAmbulatoryChargingStation { get; set; }

    public int? _681CommercialElectricAmbulatoryChargingStation { get; set; }

    public int? _682CommercialElectricAmbulatoryChargingStation { get; set; }

    public string? _683DateAssignedtoAcHpstaffProject { get; set; }

    public string? _684DateAcHpstampedPlansandClearedProjectinPcisProject { get; set; }

    public string? _685ProjectedProjectCompletionDateProject { get; set; }

    public string? _686PreFinalAccessibilityInspectionRequestedProject { get; set; }

    public string? _687DateAcHpissuedCorrectionsforFinalAccessibilityInspectionProject { get; set; }

    public string? _688DatemeetingwithownerProject { get; set; }

    public string? _689DateAssignedtoAcHpstaffSite { get; set; }

    public string? _690DateAcHpstampedPlansandClearedProjectinPcisSite { get; set; }

    public string? _691ProjectedRetrofitCompletionDateSite { get; set; }

    public string? _692PreFinalAccessibilityInspectionRequestedbyDeveloperOwnerSite { get; set; }

    public string? _693DateAcHpissuedCorrectionsforFinalAccessibilityInspectionSite { get; set; }

    public string? _694ProgressInspectionRequestbyDeveloperOwnerDateSite { get; set; }

    public string? _695DateAcHpprogressInspectionApprovedSite { get; set; }

    public string? _696DateAcHpissuedCorrectionsforProgressInspectionSite { get; set; }

    public string? _697RoughInspectionAccessibilityReportApprovedDateSite { get; set; }

    public string? _698DateAssignedtoAcHpstaffSubRehabProject { get; set; }

    public string? _699DateAcHpstampedPlansandClearedProjectinPcisSubRehabProject { get; set; }

    public string? _700ProjectedProjectCompletionDateSubRehabProject { get; set; }

    public string? _701PreFinalAccessibilityInspectionRequestedbyDeveloperOwnerSubRehabProject { get; set; }

    public string? _702DateAcHpissuedCorrectionsforFinalAccessibilityInspectionSubRehabProject { get; set; }

    public string? _703DateDeveloperOwnerRequestedNacinspectionSubRehabProject { get; set; }

    public string? _704DateAssignedtoAcHpstaffSubRehabSite { get; set; }

    public string? _705DateAcHpstampedPlansandClearedProjectinPcisSubRehabSite { get; set; }

    public string? _706ProjectedProjectCompletionDateSubRehabSite { get; set; }

    public string? _707PreFinalAccessibilityInspectionRequestedbyDeveloperOwnerSubRehabSite { get; set; }

    public string? _708DateAcHpissuedCorrectionsforFinalAccessibilityInspectionSubRehabSite { get; set; }

    public string? _709DateDeveloperOwnerRequestedNacinspectionSubRehabSite { get; set; }

    public string? _710DateAcHpissuedCorrectionsforDesignReviewSubRehabSite { get; set; }

    public string? _711RoughInspectionRequestedbyDeveloperOwnerSubRehabSite { get; set; }

    public string? _712RoughInspectionAccessibilityReportApprovedDateSubRehabSite { get; set; }

    public string? _810DateAssignedtoAcHpstaffNewConstructionProject { get; set; }

    public string? _811DateAcHpstampedPlansandClearedProjectinPcisNewConstructionProject { get; set; }

    public string? _812ProjectedProjectCompletionDateNewConstructionProject { get; set; }

    public string? _813PreFinalAccessibilityInspectionRequestedbyDeveloperOwnerNewConstructionProject { get; set; }

    public string? _814DateAcHpissuedCorrectionsforFinalAccessibilityInspectionNewConstructionProject { get; set; }

    public string? _815DateDeveloperOwnerRequestedNacinspectionNewConstructionProject { get; set; }

    public string? _816DateAssignedtoAcHpstaffNewConstructionProject { get; set; }

    public string? _817DateAcHpstampedPlansandClearedProjectinPcisNewConstructionProject { get; set; }

    public string? _818ProjectedProjectCompletionDateNewConstructionProject { get; set; }

    public string? _819PreFinalAccessibilityInspectionRequestedbyDeveloperOwnerNewConstructionProject { get; set; }

    public string? _820DateAcHpissuedCorrectionsforFinalAccessibilityInspectionNewConstructionProject { get; set; }

    public string? _821DateDeveloperOwnerRequestedNacinspectionNewConstructionProject { get; set; }

    public string? _822DateAcHpissuedCorrectionsforDesignReviewNewConstructionProject { get; set; }

    public string? _823RoughInspectionRequestedbyDeveloperOwnerNewConstructionProject { get; set; }

    public string? _824RoughInspectionAccessibilityReportApprovedDateNewConstructionProject { get; set; }

    public string? _160CorrectiveActionPlanIssueDate { get; set; }

    public string? _826CorrectiveActionPlanDueDate { get; set; }

    public string? _826500CorrectiveActionPlanCaseNumber { get; set; }

    public string? _827CorrectiveActionPlanReceivedDate { get; set; }

    public string? _828CorrectiveActionPlanComplete { get; set; }

    public string? _828010CorrectiveActionPlanAchievedDate { get; set; }

    public string? _829CorrectiveActionPlanExtensions { get; set; }

    public DateTime? _829400SecondExtensionEndDate { get; set; }

    public int? _829500CapnonCompliantCategoriesatDateofCapissuance { get; set; }

    public DateTime? _830ExtensionEndDate { get; set; }

    public DateOnly? _831NonComplianceCaseOpenDate { get; set; }

    public string? _832NonComplianceCaseNumber { get; set; }

    public DateOnly? _833OrderToComplyIssueDate { get; set; }

    public DateOnly? _834ComplianceDueDate { get; set; }

    public bool? _835IsComplianceAchieved { get; set; }

    public DateOnly? _835010OtccomplianceAchievedDate { get; set; }

    public DateOnly? _836DueDateForAnyExtensionToComply { get; set; }

    public string? _837SubsequentActions { get; set; }

    public string? _838ResponsibleCityStaff { get; set; }

    public DateOnly? _839DateNonComplianceCaseClosed { get; set; }

    public DateOnly? _839010EnforcementComplianceAchievedDate { get; set; }

    public string? _839500CommentsConcerningEnforcement { get; set; }

    public DateOnly? _839600DatePolicyComplianceDecertified { get; set; }

    public DateOnly? _839700DatePolicyCertificateReIssued { get; set; }

    public int? _843000TotalNumberOfNoncompliantConditions { get; set; }

    public string? _846000EstimatedTotalRemovalCost { get; set; }

    public int? _847000Region { get; set; }

    public string? _848000Facility { get; set; }

    public string? _849000AddressFromEta { get; set; }

    public string? _850000SurveyStandards { get; set; }

    public string? _851000SitePlanDrawingNumber { get; set; }

    public DateOnly? ReferredForRemovalDate { get; set; }

    public DateOnly? ReferredToCityAttorneyDate { get; set; }

    public string? Reason { get; set; }

    public DateOnly? NewOwnershipDate { get; set; }

    public string? _1126000DateTheNacissuedVerificationOfSiteAccessibilityForRetrofitUnderCsa { get; set; }

    public string? _1127000DateTheCityCertifiedSiteAccessibilityForRetrofitUnderCsa { get; set; }

    public string? _1128000DateTheNacissuedVerificationOfProjectAccessibilityForRetrofitUnderCsa { get; set; }

    public string? _1129000DateTheCityCertifiedProjectAccessibilityForRetrofitUnderCsa { get; set; }

    public string? _1130000DateTheNacissuedVerificationOfSiteAccessibilityForRehabUnderCsa { get; set; }

    public string? _1131000DateTheCityCertifiedSiteAccessibilityForRehabUnderCsa { get; set; }

    public string? _1132000DateTheNacissuedVerificationOfProjectAccessibilityForRehabUnderCsa { get; set; }

    public string? _1133000DateTheCityCertifiedProjectAccessibilityForRehabUnderCsa { get; set; }

    public string? _1134000DateTheNacissuedVerificationOfSiteAccessibilityForNewConstructionUnderCsa { get; set; }

    public string? _1135000DateTheCityCertifiedSiteAccessibilityForNewConstructionUnderCsa { get; set; }

    public string? _1136000DateTheNacissuedVerificationOfProjectAccessibilityForNewConstructionUnderCsa { get; set; }

    public string? _1137000DateTheCityCertifiedProjectAccessibilityForNewConstructionUnderCsa { get; set; }

    public string? _1138000DateTheNacissuedVerificationOfSiteAccessibilityForRetrofitUnderVca { get; set; }

    public string? _1139000DateTheCityCertifiedSiteAccessibilityForRetrofitUnderVca { get; set; }

    public string? _1140000DateTheNacissuedVerificationOfProjectAccessibilityForRetrofitUnderVca { get; set; }

    public string? _1141000DateTheCityCertifiedProjectAccessibilityForRetrofitUnderVca { get; set; }

    public string? _1142000DateTheNacissuedVerificationOfSiteAccessibilityForRehabUnderVca { get; set; }

    public string? _1143000DateTheCityCertifiedSiteAccessibilityForRehabUnderVca { get; set; }

    public string? _1144000DateTheNacissuedVerificationOfProjectAccessibilityForRehabUnderVca { get; set; }

    public string? _1145000DateTheCityCertifiedProjectAccessibilityForRehabUnderVca { get; set; }

    public string? _1146000DateTheNacissuedVerificationOfSiteAccessibilityForNewConstructionUnderVca { get; set; }

    public string? _1147000DateTheCityCertifiedSiteAccessibilityForNewConstructionUnderVca { get; set; }

    public string? _1148000DateTheNacissuedVerificationOfProjectAccessibilityForNewConstructionUnderVca { get; set; }

    public string? _1149000DateTheCityCertifiedProjectAccessibilityForNewConstructionUnderVca { get; set; }

    public string? _826700Capstatus { get; set; }

    public string? Capsummary { get; set; }

    public string? CapclosureDate { get; set; }

    public string? WithdrawReason { get; set; }
}
