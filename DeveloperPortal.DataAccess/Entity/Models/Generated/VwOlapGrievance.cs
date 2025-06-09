using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapGrievance
{
    public int GrievanceId { get; set; }

    public int? PropertyId { get; set; }

    public string? PropertyName { get; set; }

    public long ServiceRequestId { get; set; }

    public string? _142010GrievanceIdnumber { get; set; }

    public string? _142020GrievantFirstName { get; set; }

    public string? _142021GrievantMiddleName { get; set; }

    public string? _142022GrievantLastName { get; set; }

    public string _142025DateGrievanceFiled { get; set; } = null!;

    public string _142028IsIncidentSpecificLocation { get; set; } = null!;

    public string? _142030PropertyNameSubToGrievance { get; set; }

    public string? _142040PropertyAcHpNumberSubToGrievance { get; set; }

    public string? _142050PropertyAddressSubToGrievance { get; set; }

    public int? _142051IncidentAddressHouseNum { get; set; }

    public string? _142052IncidentAddressHouseFracNum { get; set; }

    public string? _142053IncidentAddressLutPreDirCd { get; set; }

    public string? _142054IncidentAddressStreetName { get; set; }

    public string? _142055IncidentAddressLutStreetTypeCd { get; set; }

    public string? _142060UnitNoRelateToGrievance { get; set; }

    public string? _142061IncidentAddressCity { get; set; }

    public string? _142062IncidentAddressLutStateCd { get; set; }

    public int? _142063IncidentAddressZip { get; set; }

    public string? _142070DescriptionOfGrievance { get; set; }

    public string _142080DevelopmentCategoryForGrievance { get; set; } = null!;

    public string _142081IsCoveredHousingDevelopment { get; set; } = null!;

    public string _142082IsDisabilityRelated { get; set; } = null!;

    public string? _142090CityActionOnGrievance { get; set; }

    public string? _142100ResolutionOnGrievance { get; set; }

    public string _142110GrievanceOutcomeStafisfactoryOrUnsatisfactory { get; set; } = null!;

    public string _142120ReferralSourcesConcerningGrievance { get; set; } = null!;

    public string _142130StatusOnGrievance { get; set; } = null!;

    public string? _142140ModeOfGrievanceSubmission { get; set; }

    public string _142150GrievanceType { get; set; } = null!;

    public string? _142160GrievanceDeterminationStatus { get; set; }

    public string _142170DateOfGrievanceDetermination { get; set; } = null!;

    public string? _142180DateOfAnticipatedImplementationInResponseToGrievance { get; set; }

    public string? _142190DateOfImplementationInResponseToGrievance { get; set; }

    public string _143500IsFiledRelatedGrievance { get; set; } = null!;

    public string _144DatesGrievancesAgainstPropertyFiledWithCity { get; set; } = null!;

    public string _144500RelatedGrievanceQrgrievanceLogId { get; set; } = null!;

    public string? _145DateAcHpreviewGrivancesWithCityAgainstProperty { get; set; }

    public string _175CityGrievancesDateOpenedAndClosed { get; set; } = null!;

    public string _175100CityGrievances { get; set; } = null!;

    public string? _175200DateCityGrievancesOpened { get; set; }

    public string? _175300DateCityGrievancesClosed { get; set; }

    public string? _758GrvGrievantPrimaryPhoneType { get; set; }

    public string? _759GrvGrievantPrimaryPhoneNumber { get; set; }

    public string? _760GrvGrievantAdditonalPhoneType { get; set; }

    public string? _761GrvGrievantAdditionalPhoneNumber { get; set; }

    public string? _762GrvGrievantEmail { get; set; }

    public string? _763GrvGrievantPreferredLanguage { get; set; }

    public string _764GrvGrievantPreferredMethodOfContact { get; set; } = null!;

    public string? _765GrvGrievantOtherPreferredMethodOfContact { get; set; }

    public string _766GrvAddPobox { get; set; } = null!;

    public string? _767GrvAddPoboxnumber { get; set; }

    public int? _767100GrievantAddressHouseNum { get; set; }

    public string? _767200GrievantAddressHouseFracNum { get; set; }

    public string? _767300GrievantAddressLutPreDirCd { get; set; }

    public string? _767400GrievantAddressStreetName { get; set; }

    public string? _767500GrievantAddressLutStreetTypeCd { get; set; }

    public string? _767600GrievantAddressUnit { get; set; }

    public string? _767700GrievantAddressCity { get; set; }

    public string? _767800GrievantAddressLutStateCd { get; set; }

    public int? _767900GrievantAddressZip { get; set; }

    public string _767901IsFileForSomeOne { get; set; } = null!;

    public string? _768GrvPreparerRelationshipToPersonWhohasGrievance { get; set; }

    public string? _769GrvPreparerFirstName { get; set; }

    public string? _770GrvPreparerMiddleName { get; set; }

    public string? _771GrvPreparerLastName { get; set; }

    public string? _773GrvPreparerPrimaryPhoneNumber { get; set; }

    public string? _772GrvPreparerPrimaryPhoneType { get; set; }

    public string? _775GrvPreparerAdditionalPhoneNumber { get; set; }

    public string? _774GrvPreparerAdditonalPhoneType { get; set; }

    public string? _776GrvPreparerEmail { get; set; }

    public string _777GrvPreparerPreferredMethodOfContact { get; set; } = null!;

    public string? _778GrvPreparerOtherPreferredMethodOfContact { get; set; }

    public string _779GrvPreparerAddPobox { get; set; } = null!;

    public string? _780GrvPreparerAddPoboxnumber { get; set; }

    public int? _781GrvPreparerAddHouseNumber { get; set; }

    public string? _782GrvPreparerAddHouseFractionNumber { get; set; }

    public string? _783GrvPreparerAddStreetDirection { get; set; }

    public string? _784GrvPreparerAddStreetName { get; set; }

    public string? _785GrvPreparerAddStreetType { get; set; }

    public string? _785100PreparerAddressUnit { get; set; }

    public string? _785200PreparerAddressCity { get; set; }

    public string? _786GrvPreparerAddState { get; set; }

    public int? _787GrvPreparerAddZipCode { get; set; }

    public int? _788GrvLocationHouseNumber { get; set; }

    public string? _789GrvLocationHouseFractionNumber { get; set; }

    public string? _790GrvLocationStreetDirection { get; set; }

    public string? _791GrvLocationStreetName { get; set; }

    public string? _792GrvLocationStreetType { get; set; }

    public string? _793GrvLocationUnitNumber { get; set; }

    public string? _794GrvLocationCity { get; set; }

    public string? _795GrvLocationState { get; set; }

    public int? _796GrvLocationZipCode { get; set; }

    public string _797GrvNoticeNoticeToVacateFromTheOwnerOrManager { get; set; } = null!;

    public string _798GrvNoticeUnlawfulDetainerSummonsfromTheCourt { get; set; } = null!;

    public string _799GrvNoticeSheriffNoticeToVacate { get; set; } = null!;

    public string _800GrvNoticeWereDateToMoveOutGiven { get; set; } = null!;

    public string _801GrvNoticeDateGivenToMoveOut { get; set; } = null!;

    public string _801500IsUnitDenied { get; set; } = null!;

    public string _802GrvNoticeIsItStillVacant { get; set; } = null!;

    public string _803GrvNoticeWasItAnAccessibleUnit { get; set; } = null!;

    public string? _804GrvNoticeSupportingDocuments { get; set; }

    public string _804500CaseStatus { get; set; } = null!;

    public string? _805GrvStatusAssignee { get; set; }

    public string? _806GrvMilestoneCaseExtensionProvided { get; set; }

    public string? _807GrvMilestoneNoticeOfAppeal { get; set; }

    public string? _808GrvSystemAcHpemployeeName { get; set; }

    public string? _809GrvUnitNumber { get; set; }

    public string _1014000DoesTheGrievanceRelateToAPendingOrPriorRequestForAReasonableAccommodationFromTheProperty { get; set; } = null!;

    public string? _1015000TypeSOfReasonableAccommodationRequestedByTheGrievant { get; set; }

    public string _1016000DoesTheGrievantAllegeTheirReasonableAccommodationRequestHasNotBeenProcessedPromptly { get; set; } = null!;

    public string _1017000DoesTheGrievantAllegeThePropertyHasUnreasonablyRequestedAThirdPartyVerification { get; set; } = null!;

    public string _1018000DoesTheGrievantAllegeThePropertyHasPartiallyDeniedTheirReasonableAccommodationRequest { get; set; } = null!;

    public string _1019000DoesTheGrievantAllegeThePropertyHasDeniedTheirReasonableAccommodationRequest { get; set; } = null!;

    public string _1020000DoesTheGrievantAllegeThereAreOtherIssuesRegardingTheirReasonableAccommodationRequestNotAlreadyListed { get; set; } = null!;

    public string? _1021000DescriptionOfOtherIssuesRegardingReasonableAccommodationRequest { get; set; }

    public string _1022000DateOfReasonableAccommodationRequest { get; set; } = null!;

    public string _1023000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; } = null!;

    public string _1024000DoesTheGrievanceRelateToAPendingOrPriorRequestForAReasonableModificationFromTheProperty { get; set; } = null!;

    public string? _1025000TypeSOfReasonableModificationRequestedByTheGrievant { get; set; }

    public string? _1026000DescriptionOfRequestedFeature { get; set; }

    public string _1027000DoesTheGrievantAllegeTheirReasonableModificationHasNotBeenProcessedPromptly { get; set; } = null!;

    public string _1028000DoesTheGrievantAllegeThePropertyHasUnreasonablyRequestedAThirdPartyVerification { get; set; } = null!;

    public string _1029000DoesTheGrievantAllegeThePropertyHasPartiallyDeniedTheirReasonableModificationRequest { get; set; } = null!;

    public string _1030000DoesTheGrievantAllegeThePropertyHasDeniedTheirReasonableModificationRequest { get; set; } = null!;

    public string _1031000DoesThePropertyGrievantAllegeThereAreOtherIssuesRegardingTheirReasonableModificationRequestNotAlreadyLi { get; set; } = null!;

    public string? _1032000ExplanationOfTheOtherIssuesRegardingReasonableModificationRequest { get; set; }

    public string _1033000DateOfReasonableModificationRequest { get; set; } = null!;

    public string _1034000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; } = null!;

    public string _1035000DoesTheGrievanceRelateToARequestForAuxiliaryAidsAndOrServicesForEffectiveCommunicationFromTheProperty { get; set; } = null!;

    public string? _1036000IfYesPleaseChooseAllClaimsThatApplyFromTheListOfOptions { get; set; }

    public string _1037000DateOfEffectiveCommunicationRequest { get; set; } = null!;

    public string _1038000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; } = null!;

    public string _1039000DoesTheGrievanceRelateToTheMaintenanceOfAccessibleFeaturesOtherThanElevatorsOrToBarriersBlockingAcc { get; set; } = null!;

    public string? _1040000IfYesPleaseChooseAllClaimsThatApplyFromTheListOfOptions { get; set; }

    public string? _1041000DescriptionOfMaintenanceIssue { get; set; }

    public string _1042000DoesTheGrievanceRelateToAnElevator { get; set; } = null!;

    public string? _1043000IfYesPleaseChooseAllThatApplyFromTheListOfOptions { get; set; }

    public string _1044000DoesTheGrievanceRelateToPlacementOnAWaitingListOrTransferListOrTransferFromAWaitingListOrTransfer { get; set; } = null!;

    public string? _1045000IfYesPleaseChooseAllThatApplyFromTheListOfOptions { get; set; }

    public string _1046000DateOfWaitingListOrUnitTransferRequest { get; set; } = null!;

    public string _1047000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; } = null!;

    public string _1048000DoesTheGrievantFaceAPotentialEvictionFromTheProperty { get; set; } = null!;

    public string? _1049000IfYesHasTheGrievantBeenServedWithAnyOfTheFollowingPleaseChooseAllThatApply { get; set; }

    public string _1050000DateNoticeWasServed { get; set; } = null!;

    public string _1051000DoesTheGrievanceRelateToAThreatenedPendingOrPastEviction { get; set; } = null!;

    public string _1052000DoesTheGrievanceRelateToAProposedPendingOrCompletedRelocation { get; set; } = null!;

    public string? _1053000IfYesPleaseDescribe { get; set; }

    public string _1054000DoesTheGrievanceRelateToAProposedPendingOrCompletedRetrofit { get; set; } = null!;

    public string? _1055000IfYesPleaseDescribe { get; set; }

    public string _1056000NoiseComplaintsChooseAllThatApplyFromTheListOfOptions { get; set; } = null!;

    public string? _1057000IfTheNoiseComplaintRelatesToNoiseFromAnotherTenantPleaseProvideThatTenantSName { get; set; }

    public string? _1058000IfTheNoiseComplaintRelatesToNoiseFromAnotherUnitPleaseProvideThatUnitNumber { get; set; }

    public string? _1059000IfTheNoiseComplaintRelatesToNoiseFromACommonAreaPleaseDescribeTheCommonAreaLocation { get; set; }

    public string _1060000DoesTheGrievanceRelateToAnAssistanceAnimalEitherAServiceAnimalOrEmotionalSupportAnimal { get; set; } = null!;

    public string? _1061000IfYesPleaseChooseAllClaimsThatApplyFromTheListOfOptions { get; set; }

    public string _1062000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; } = null!;

    public string _1063000DoesTheGrievanceRelateToClaimsOfDiscriminationOrDifferentTreatmentFromThePropertyBecauseTheGrievantIs { get; set; } = null!;

    public string? _1064000IfYesPleaseChooseAllClaimsThatApplyFromTheListOfOptions { get; set; }

    public string _1065000DoesTheGrievanceRelateToClaimsOfHarassmentOnTheProperty { get; set; } = null!;

    public string _1066000IfYesChooseAllThatApplyFromTheListOfOptionsConcerningTheClaimedHarasserS { get; set; } = null!;

    public string? _1067000IfTheClaimedHarasserIsAnEmployeeOfThePropertyProvideNamesOfTheEmployeeS { get; set; }

    public string? _1068000IfTheClaimedHarasserIsAnEmployeeOfThePropertyProvideTitlesOfTheEmployeeS { get; set; }

    public string? _1069000IfTheClaimedHarasserIsAnEmployeeOfThePropertyAndTheNameOrTitleAreUnknownPleaseProvideADescription { get; set; }

    public string? _1070000IfTheClaimedHarasserIsAContractorOrAgentOfThePropertyProvideNamesOfThePersons { get; set; }

    public string? _1071000IfTheClaimedHarasserIsAContractorOrAgentOfThePropertyProvideTitlesOfThePersons { get; set; }

    public string? _1072000IfTheClaimedHarasserIsAContractorOrAgentOfThePropertyAndTheNameOrTitleAreUnknownPleaseProvideAD { get; set; }

    public string? _1073000IfTheClaimedHarasserIsATenantOrGuestProvideNamesOfThePersons { get; set; }

    public string? _1074000IfTheClaimedHarasserIsATenantOrGuestProvideTheUnitNumber { get; set; }

    public string? _1075000IfTheClaimedHarasserIsATenantOrGuestAndTheNameOrUnitNumberAreUnknownPleaseProvideADescriptionOf { get; set; }

    public string? _1076000IfTheClaimedHarasserSIsSomeoneOtherThanAnEmployeeContractorAgentTenantOrGuestProvideAsMuchIdent { get; set; }

    public string _1077000DoesTheGrievantBelieveTheyAreBeingHarassedBecauseTheyAreAMemberOfAGroupProtectedByTheFairHousingPo { get; set; } = null!;

    public string? _1078000IfYesPleaseChooseAllClaimsThatApplyFromTheListOfOptions { get; set; }

    public string _1079000DoesTheGrievantAllegeTheyAreBeingRetaliatedAgainstByTheProperty { get; set; } = null!;

    public string? _1080000IfYesPleaseChooseTheOptionsThatBestDescribeTheAllegedReasonForTheClaimedRetaliation { get; set; }

    public string? _1081000IfYesPleaseChooseTheOptionsThatBestDescribeTheAllegedNatureOfTheRetaliatoryAction { get; set; }

    public string _1082000DoesTheGrievanceRelateToARentalApplication { get; set; } = null!;

    public string? _1083000IfYesPleaseSelectTheOptionsThatBestDescribeTheAllegedBasisForTheGrievance { get; set; }

    public string _1084000DateGrievantSubmittedRentalApplication { get; set; } = null!;

    public string _1085000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; } = null!;

    public string? _1086000OtherGrievanceDescribeOtherBasisForGrievance { get; set; }

    public string _1087000DidTheCityGrievantFileAGrievanceWithThePropertyRelatedToTheSameIssueAsTheCityGrievanceVerifyByCh { get; set; } = null!;

    public string _1088000IfYesDateOfThePropertyGrievance { get; set; } = null!;

    public string _1089000IfYesDateTheGrievanceWasListedOnTheQuarterlyReportGrievanceLog { get; set; } = null!;

    public string _1090000IfYesDateTheGrievantReceivedDecisionFromProperty { get; set; } = null!;

    public string _1091000DidThePropertyFollowRequiredProceduresInResponseToAnyReasonableAccommodationReasonableModificationOrEff { get; set; } = null!;

    public string? _1092000IfNoPleaseExplain { get; set; }

    public string? _1116000GrievanceSubmissionSource { get; set; }

    public string? _1117000LastActionDate { get; set; }

    public int? _1118000NumberOfDaysSinceGrievanceReceived { get; set; }

    public string _1119000CaseCreatedOn { get; set; } = null!;

    public string _1120000ReferredToAgency { get; set; } = null!;

    public string? _1121000CaseOpened { get; set; }

    public string? _1122000NoticeOfDetermination { get; set; }

    public string? _1123000LinkedProperties { get; set; }

    public string? _1124000AcHpemployeeUsername { get; set; }

    public string? _1022001PrevReasonableAccmQrid { get; set; }

    public string? _1033001PrevReasonableModfQrid { get; set; }

    public string? _1037001PrevEffectiveCommQrid { get; set; }

    public string? _183400FiledLawsuitWithAnotherAgency { get; set; }

    public string _183500LawsuitFiledAgencyNames { get; set; } = null!;

    public string _183600LawSuitFiledDates { get; set; } = null!;
}
