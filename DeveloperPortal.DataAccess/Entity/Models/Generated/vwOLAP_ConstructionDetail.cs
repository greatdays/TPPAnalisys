using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_ConstructionDetail
{
    public int CaseID { get; set; }

    public long ServiceRequestID { get; set; }

    public int? PropSnapShotID { get; set; }

    public string Type { get; set; } = null!;

    public int? ProjectSiteId { get; set; }

    public int? ProjectId { get; set; }

    public string Status { get; set; } = null!;

    public string? APN_ { get; set; }

    public string HIMS__ { get; set; } = null!;

    public string AcHP__ { get; set; } = null!;

    public string Project_Name { get; set; } = null!;

    public string Property_Name { get; set; } = null!;

    public string Project_Address { get; set; } = null!;

    public string? _073_DateNACInspectionScheduled { get; set; }

    public string? _074_StartDateOfSurvey { get; set; }

    public string? _074_020_EndDateOfSurvey { get; set; }

    public string? _075_LinktoNACInspectionReport { get; set; }

    public string? _076_DateOfNACInspectionReport { get; set; }

    public string? _081_ProposedRetrofitCommenceDate { get; set; }

    public DateTime? _081_200_NoticeToProceedWithRetrofitDate { get; set; }

    public string? _088_100_DateSiteRetrofitFinalAcHPInspectionApproved { get; set; }

    public string? _088_200_DateProjectRetrofitFinalAcHPInspectionApproved { get; set; }

    public string? _089_100_DateSiteAcHPFinalNewConstructionInspApproved { get; set; }

    public string? _089_200_DateProjectAcHPFinalNewConstructionInspApproved { get; set; }

    public string? _089_300_DateSiteAcHPFinalRehabInspApproved { get; set; }

    public string? _089_400_DateProjectAcHPFinalRehabInspApproved { get; set; }

    public string _90_0_DateCertificationAccessibilityissues { get; set; } = null!;

    public string _90_1_DateCertificationAccessibilityissues { get; set; } = null!;

    public string _196_AssignedRCS { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public string ProjectName { get; set; } = null!;

    public string ProjectAddress { get; set; } = null!;

    public string? CreatedOn { get; set; }

    public string? ModifiedOn { get; set; }

    public string? AcHPFileProjectNumber { get; set; }

    public string? _525_1_DateOf1stPlanCheckSubmission { get; set; }

    public string? _525_2_DateOf1stBuildingPermit { get; set; }

    public int? _525_3_BuildingPermitNumber { get; set; }

    public string? _525_4_DateOf1stTCO { get; set; }

    public string? _525_5_DateOf1stCofO { get; set; }

    public DateTime? _526_5__DateOf1stCoFOForConversionToResidential { get; set; }

    public string? _527_1_DateOfMostRecentPlanCheckSubmission { get; set; }

    public string? _527_2_DateOMostRecentBuildingPermit { get; set; }

    public string? _527_3_MostRecentBuldingPermitNumber { get; set; }

    public DateOnly? _527_4_DateOfMostRecentTCO { get; set; }

    public DateOnly? _527_5_DateOfMostRecentCofO { get; set; }

    public DateOnly? _527_6_DateOfBuildingPermitFinaled { get; set; }

    public string? _528_1_DateOfCurrentPlanCheckSubmission { get; set; }

    public string? _528_2_DateOfCurrentBuildingPermitNumber { get; set; }

    public string? _528_3_CurrentBuldingPermitNumberr { get; set; }

    public DateOnly? _528_4_DateOfCurrentTCO { get; set; }

    public DateOnly? _528_5_DateOfCurrentCofO { get; set; }

    public DateTime? _528_6_DateOfCurrentBuildingPermitFinaled { get; set; }

    public string? _529_1_DateOfRetrofitPlanCheckSubmission { get; set; }

    public string? _529_2_DateOfCurrentBuildingPermitNumber { get; set; }

    public string? _529_3_DBSRetrofitBuildingPermitNumber { get; set; }

    public string? _529_4_DateOfCofOPostRetrofit { get; set; }

    public string? _529_5_DateOfBuildingPermitFinaled { get; set; }

    public double? _649_AreainSquareFeet { get; set; }

    public string? _650_Floorplantype { get; set; }

    public string _652_Currentstatusofprojectcase { get; set; } = null!;

    public string _653_IsParkingAvailableAtBuilding { get; set; } = null!;

    public string _654_SharedparkingLots { get; set; } = null!;

    public double? _655_ResidentialParkingRatio { get; set; }

    public bool? _656_AssignedResidentialParking { get; set; }

    public string? _657_ApplicableAccessibilityStandard { get; set; }

    public bool? _658_IsthisaPreVCAdevelopment { get; set; }

    public string _659_TotalNumber_FHA11AUnitsRequired { get; set; } = null!;

    public int? _660_MaximumMobilityCSACount { get; set; }

    public string? _661_UnitsNumbersForAllTypes_Mobility { get; set; }

    public string? _661_UnitsNumbersForAllTypes_Mobility_ { get; set; }

    public int? _661_UnitsNumbersForAllTypes_UnitDesignation { get; set; }

    public string? _661_UnitsNumbersForAllTypes_HearingVision { get; set; }

    public string? _661_UnitsNumbersForAllTypes_EnhancedAccessibility { get; set; }

    public string _661_UnitsNoForAllTypes { get; set; } = null!;

    public string? _662_HUDChecklistforSelection1perBuiliding { get; set; }

    public string _663_IsParkingAvailableAtBuilding { get; set; } = null!;

    public int? _664_BuildingType { get; set; }

    public string _665_AssignedResidentialParking { get; set; } = null!;

    public string? _666_ResidentialParkingRatio { get; set; }

    public int? _667_TotalResidentialParking { get; set; }

    public int? _668_Residentialstandardaccessibleparkingspaces { get; set; }

    public int? _669_VanAccessibleSpaces { get; set; }

    public int? _670_TotalResidentialParking { get; set; }

    public int? _671_StandardCommercialSpaces { get; set; }

    public int? _672_CommercialAccessibleSpaces { get; set; }

    public int? _673_CommercialVanAccessibleSpaces { get; set; }

    public int? _674_CommercialVanAccessibleSpaces { get; set; }

    public int? _675_StandardVisitorSpaces { get; set; }

    public int? _676_VisitorAccessibleSpaces { get; set; }

    public int? _677_VisitorVanAccessibleSpaces { get; set; }

    public int? _678_VisitorVanAccessibleSpaces { get; set; }

    public int? _679_CommercialElectricVanAccessibleChargingStation { get; set; }

    public int? _680_CommercialElectricAmbulatoryChargingStation { get; set; }

    public int? _681_CommercialElectricAmbulatoryChargingStation { get; set; }

    public int? _682_CommercialElectricAmbulatoryChargingStation { get; set; }

    public string? _683_DateAssignedtoAcHPStaff_Project { get; set; }

    public string? _684_DateAcHPStampedPlansandClearedProjectinPCIS_Project { get; set; }

    public string? _685_ProjectedProjectCompletionDate_Project { get; set; }

    public string? _686_Pre_FinalAccessibilityInspectionRequested_Project { get; set; }

    public string? _687_DateAcHPIssuedCorrectionsforFinalAccessibilityInspection_Project { get; set; }

    public string? _688_Datemeetingwithowner_Project { get; set; }

    public string? _689_DateAssignedtoAcHPStaff_Site { get; set; }

    public string? _690_DateAcHPStampedPlansandClearedProjectinPCIS_Site { get; set; }

    public string? _691_ProjectedRetrofitCompletionDate_Site { get; set; }

    public string? _692_Pre_FinalAccessibilityInspectionRequestedbyDeveloperOwner_Site { get; set; }

    public string? _693_DateAcHPIssuedCorrectionsforFinalAccessibilityInspection_Site { get; set; }

    public string? _694_ProgressInspectionRequestbyDeveloperOwnerDate_Site { get; set; }

    public string? _695_DateAcHPProgressInspectionApproved_Site { get; set; }

    public string? _696_DateAcHPIssuedCorrectionsforProgressInspection_Site { get; set; }

    public string? _697_RoughInspectionAccessibilityReportApprovedDate_Site { get; set; }

    public string? _698_DateAssignedtoAcHPStaff_SubRehabProject { get; set; }

    public string? _699_DateAcHPStampedPlansandClearedProjectinPCIS_SubRehabProject { get; set; }

    public string? _700_ProjectedProjectCompletionDate_SubRehabProject { get; set; }

    public string? _701_Pre_FinalAccessibilityInspectionRequestedbyDeveloperOwner_SubRehabProject { get; set; }

    public string? _702_DateAcHPIssuedCorrectionsforFinalAccessibility_Inspection_SubRehabProject { get; set; }

    public string? _703_DateDeveloperOwnerRequestedNACInspection_SubRehabProject { get; set; }

    public string? _704_DateAssignedtoAcHPStaff_SubRehabSite { get; set; }

    public string? _705_DateAcHPStampedPlansandClearedProjectinPCIS_SubRehabSite { get; set; }

    public string? _706_ProjectedProjectCompletionDate_SubRehabSite { get; set; }

    public string? _707_Pre_FinalAccessibilityInspectionRequestedbyDeveloperOwner_SubRehabSite { get; set; }

    public string? _708_DateAcHPIssuedCorrectionsforFinalAccessibilityInspection_SubRehabSite { get; set; }

    public string? _709_DateDeveloperOwnerRequestedNACInspection_SubRehabSite { get; set; }

    public string? _710_DateAcHPIssuedCorrectionsforDesignReview_SubRehabSite { get; set; }

    public string? _711_RoughInspectionRequestedbyDeveloperOwner_SubRehabSite { get; set; }

    public string? _712_RoughInspectionAccessibilityReportApprovedDate_SubRehabSite { get; set; }

    public string? _810_DateAssignedtoAcHPStaff_NewConstructionProject { get; set; }

    public string? _811_DateAcHPStampedPlansandClearedProjectinPCIS_NewConstructionProject { get; set; }

    public string? _812_ProjectedProjectCompletionDate_NewConstructionProject { get; set; }

    public string? _813_Pre_FinalAccessibilityInspectionRequestedbyDeveloperOwner_NewConstructionProject { get; set; }

    public string? _814_DateAcHPIssuedCorrectionsforFinalAccessibilityInspection_NewConstructionProject { get; set; }

    public string? _815_DateDeveloperOwnerRequestedNACInspection_NewConstructionProject { get; set; }

    public string? _816_DateAssignedtoAcHPStaff_NewConstructionProject { get; set; }

    public string? _817_DateAcHPStampedPlansandClearedProjectinPCIS_NewConstructionProject { get; set; }

    public string? _818_ProjectedProjectCompletionDate_NewConstructionProject { get; set; }

    public string? _819_Pre_FinalAccessibilityInspectionRequestedbyDeveloperOwner_NewConstructionProject { get; set; }

    public string? _820_DateAcHPIssuedCorrectionsforFinalAccessibilityInspection_NewConstructionProject { get; set; }

    public string? _821_DateDeveloperOwnerRequestedNACInspection_NewConstructionProject { get; set; }

    public string? _822_DateAcHPIssuedCorrectionsforDesignReview_NewConstructionProject { get; set; }

    public string? _823_RoughInspectionRequestedbyDeveloperOwner_NewConstructionProject { get; set; }

    public string? _824_RoughInspectionAccessibilityReportApprovedDate_NewConstructionProject { get; set; }

    public string? _160_CorrectiveActionPlanIssueDate { get; set; }

    public string? _826_CorrectiveActionPlanDueDate { get; set; }

    public string? _826_500_CorrectiveActionPlanCaseNumber { get; set; }

    public string? _827_CorrectiveActionPlanReceivedDate { get; set; }

    public string? _828_CorrectiveActionPlanComplete { get; set; }

    public string? _828_010_CorrectiveActionPlanAchievedDate { get; set; }

    public string? _829_CorrectiveActionPlanExtensions { get; set; }

    public DateTime? _829_400_SecondExtensionEndDate { get; set; }

    public int? _829_500_CAPNon_CompliantCategoriesatDateofCAPIssuance { get; set; }

    public DateTime? _830_ExtensionEndDate { get; set; }

    public DateOnly? _831_Non_ComplianceCaseOpenDate { get; set; }

    public string? _832_Non_ComplianceCaseNumber { get; set; }

    public DateOnly? _833_OrderToComplyIssueDate { get; set; }

    public DateOnly? _834_ComplianceDueDate { get; set; }

    public bool? _835_IsComplianceAchieved { get; set; }

    public DateOnly? _835_010_OTCComplianceAchievedDate { get; set; }

    public DateOnly? _836_DueDateForAnyExtensionToComply { get; set; }

    public string? _837_SubsequentActions { get; set; }

    public string? _838_ResponsibleCityStaff { get; set; }

    public DateOnly? _839_DateNon_ComplianceCaseClosed { get; set; }

    public DateOnly? _839_010_EnforcementComplianceAchievedDate { get; set; }

    public string? _839_500_CommentsConcerningEnforcement { get; set; }

    public DateOnly? _839_600_DatePolicyComplianceDecertified { get; set; }

    public DateOnly? _839_700_DatePolicyCertificateReIssued { get; set; }

    public int? _843_000_TotalNumberOfNoncompliantConditions { get; set; }

    public string? _846_000_EstimatedTotalRemovalCost { get; set; }

    public int? _847_000_Region { get; set; }

    public string? _848_000_Facility { get; set; }

    public string? _849_000_AddressFromETA { get; set; }

    public string? _850_000_SurveyStandards { get; set; }

    public string? _851_000_SitePlanDrawingNumber { get; set; }

    public DateOnly? ReferredForRemovalDate { get; set; }

    public DateOnly? ReferredToCityAttorneyDate { get; set; }

    public DateOnly? NewOwnershipDate { get; set; }

    public string? _1126_000_DateTheNACIssuedVerificationOfSiteAccessibilityForRetrofitUnderCSA { get; set; }

    public string? _1127_000_DateTheCityCertifiedSiteAccessibilityForRetrofitUnderCSA { get; set; }

    public string? _1128_000_DateTheNACIssuedVerificationOfProjectAccessibilityForRetrofitUnderCSA { get; set; }

    public string? _1129_000_DateTheCityCertifiedProjectAccessibilityForRetrofitUnderCSA { get; set; }

    public string? _1130_000_DateTheNACIssuedVerificationOfSiteAccessibilityForRehabUnderCSA { get; set; }

    public string? _1131_000_DateTheCityCertifiedSiteAccessibilityForRehabUnderCSA { get; set; }

    public string? _1132_000_DateTheNACIssuedVerificationOfProjectAccessibilityForRehabUnderCSA { get; set; }

    public string? _1133_000_DateTheCityCertifiedProjectAccessibilityForRehabUnderCSA { get; set; }

    public string? _1134_000_DateTheNACIssuedVerificationOfSiteAccessibilityForNewConstructionUnderCSA { get; set; }

    public string? _1135_000_DateTheCityCertifiedSiteAccessibilityForNewConstructionUnderCSA { get; set; }

    public string? _1136_000_DateTheNACIssuedVerificationOfProjectAccessibilityForNewConstructionUnderCSA { get; set; }

    public string? _1137_000_DateTheCityCertifiedProjectAccessibilityForNewConstructionUnderCSA { get; set; }

    public string? _1138_000_DateTheNACIssuedVerificationOfSiteAccessibilityForRetrofitUnderVCA { get; set; }

    public string? _1139_000_DateTheCityCertifiedSiteAccessibilityForRetrofitUnderVCA { get; set; }

    public string? _1140_000_DateTheNACIssuedVerificationOfProjectAccessibilityForRetrofitUnderVCA { get; set; }

    public string? _1141_000_DateTheCityCertifiedProjectAccessibilityForRetrofitUnderVCA { get; set; }

    public string? _1142_000_DateTheNACIssuedVerificationOfSiteAccessibilityForRehabUnderVCA { get; set; }

    public string? _1143_000_DateTheCityCertifiedSiteAccessibilityForRehabUnderVCA { get; set; }

    public string? _1144_000_DateTheNACIssuedVerificationOfProjectAccessibilityForRehabUnderVCA { get; set; }

    public string? _1145_000_DateTheCityCertifiedProjectAccessibilityForRehabUnderVCA { get; set; }

    public string? _1146_000_DateTheNACIssuedVerificationOfSiteAccessibilityForNewConstructionUnderVCA { get; set; }

    public string? _1147_000_DateTheCityCertifiedSiteAccessibilityForNewConstructionUnderVCA { get; set; }

    public string? _1148_000_DateTheNACIssuedVerificationOfProjectAccessibilityForNewConstructionUnderVCA { get; set; }

    public string? _1149_000_DateTheCityCertifiedProjectAccessibilityForNewConstructionUnderVCA { get; set; }

    public string? _826_700_CAPStatus { get; set; }

    public string? CAPSummary { get; set; }

    public string? CAPClosureDate { get; set; }

    public string? WithdrawReason { get; set; }
}
