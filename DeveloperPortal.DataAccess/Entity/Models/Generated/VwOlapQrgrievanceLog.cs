using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapQrgrievanceLog
{
    public int? GrievanceLogId { get; set; }

    public int? QrgrievanceLogId { get; set; }

    public string YearQr { get; set; } = null!;

    public string? MaxYearQr { get; set; }

    public int QuarterlyReportId { get; set; }

    public int? MaxQrId { get; set; }

    public DateTime QrreportCreateDate { get; set; }

    public string? FileNumber { get; set; }

    public string IsReasonableAccommodation { get; set; } = null!;

    public string IsEffectiveCommunication { get; set; } = null!;

    public string IsFairHousingComplaint { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public int? UnitPropSnapShotId { get; set; }

    public string? UnitNumber { get; set; }

    public string? ApplicantAddress { get; set; }

    public DateTime? GrievanceDate { get; set; }

    public string? GrievanceDetail { get; set; }

    public string? DeterminationStatus { get; set; }

    public DateTime? DeterminationDate { get; set; }

    public string? DeterminationDetail { get; set; }

    public DateTime? AnticipatedDate { get; set; }

    public DateTime? ImplementationDate { get; set; }

    public string? ImplementationInformation { get; set; }

    public string IsFairHousingComplaintFiled { get; set; } = null!;

    public string IsHudcompliantFiled { get; set; } = null!;

    public string IsHcidlacompliantFiled { get; set; } = null!;

    public string _328000GrievanceRelatedToReasonableAccommodationGlog { get; set; } = null!;

    public string _329000GrievanceRelatedToEffectiveCommunicationGlog { get; set; } = null!;

    public string _330000GrievanceRelatedToFairHousingGlog { get; set; } = null!;

    public string _331000IsGrievantApplicantGlog { get; set; } = null!;

    public string _332000IsGrievantTenantGlog { get; set; } = null!;

    public string? _333000GrievanceLogDeterminationStatusGlog { get; set; }

    public string? _334000DescriptionOfGrievanceGlog { get; set; }

    public string _335000DateOfAnticipatedImplementationGlog { get; set; } = null!;

    public string _336000DateOfImplementationCompletionGlog { get; set; } = null!;

    public string? _500000GrievanceLogNumber { get; set; }

    public string? _501000GrievantFirstNameGlog { get; set; }

    public string _502000GrievantMiddleInitialGlog { get; set; } = null!;

    public string? _503000GrievantLastNameGlog { get; set; }

    public string _504000DateGrievanceFiledGlog { get; set; } = null!;

    public string? _505000PropertyNameSubjectToGrievanceGlog { get; set; }

    public string? _506000PropertyAcHpnumberSubjectToGrievanceGlog { get; set; }

    public string? _507000PropertyAddressSubjectToGrievanceGlog { get; set; }

    public string _508000IfApplicableUnitNumberRelevantToGrievanceGlog { get; set; } = null!;

    public string? _509000DescriptionOfGrievanceGlog { get; set; }

    public string? _510000DevelopmentCategoryForGrievanceGlog { get; set; }

    public string? _512000ResolutionOfGrievanceGlog { get; set; }

    public string? _515000GrievanceLogDeterminationStatusGlog { get; set; }

    public string _517000PropertyGrievanceType { get; set; } = null!;

    public string? _518000GrievanceLogDeterminationStatusGlog { get; set; }

    public string _519000GrievanceLogDeterminationDateGlog { get; set; } = null!;

    public string _520000GrievanceLogAnticipatedDateGlog { get; set; } = null!;

    public string _521000GrievanceLogImplementationDateGlog { get; set; } = null!;

    public string _522000GrievanceLogAnyComplaintsFiledGlog { get; set; } = null!;

    public string _522100GrievanceLogIsFairHousingComplaintFiledGlog { get; set; } = null!;

    public string _522100GrievanceLogIsHudcompliantFiledGlog { get; set; } = null!;

    public string _522100GrievanceLogIisHcidlacompliantFiledGlog { get; set; } = null!;

    public string _511000CityPropertyActionOnGrievance { get; set; } = null!;

    public string? _900000DoesTheGrievanceRelateToAPendingOrPriorRequestForAReasonableAccommodationFromTheProperty { get; set; }

    public string? _901000TypeSOfReasonableAccommodationRequestedByTheGrievant { get; set; }

    public string? _902000DoesTheGrievantAllegeTheirReasonableAccommodationRequestHasNotBeenProcessedPromptly { get; set; }

    public string? _903000DoesTheGrievantAllegeThePropertyHasUnreasonablyRequestedAThirdPartyVerification { get; set; }

    public string? _904000DoesTheGrievantAllegeThePropertyHasPartiallyDeniedTheirReasonableAccommodationRequest { get; set; }

    public string? _905000DoesTheGrievantAllegeThePropertyHasDeniedTheirReasonableAccommodationRequest { get; set; }

    public string? _906000DoesTheGrievantAllegeThereAreOtherIssuesRegardingTheirReasonableAccommodationRequestNotAlreadyListed { get; set; }

    public string? _907000DescriptionOfOtherIssuesRegardingReasonableAccommodationRequest { get; set; }

    public string? _908000DateOfReasonableAccommodationRequest { get; set; }

    public string? _909000DateRequestWasListedOnTheQuarterlyReportReasonableAccommodationLog { get; set; }

    public string? _910000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; }

    public string? _911000DoesTheGrievanceRelateToAPendingOrPriorRequestForAReasonableModificationFromTheProperty { get; set; }

    public string? _912000TypeSOfReasonableModificationRequestedByTheGrievant { get; set; }

    public string? _913000DescriptionOfRequestedFeature { get; set; }

    public string? _914000DoesTheGrievantAllegeTheirReasonableModificationHasNotBeenProcessedPromptly { get; set; }

    public string? _915000DoesTheGrievantAllegeThePropertyHasUnreasonablyRequestedAThirdPartyVerification { get; set; }

    public string? _916000DoesTheGrievantAllegeThePropertyHasPartiallyDeniedTheirReasonableModificationRequest { get; set; }

    public string? _917000DoesTheGrievantAllegeThePropertyHasDeniedTheirReasonableModificationRequest { get; set; }

    public string? _918000DoesThePropertyGrievantAllegeThereAreOtherIssuesRegardingTheirReasonableModificationRequestNotAlreadyLis { get; set; }

    public string? _919000ExplanationOfTheOtherIssuesRegardingReasonableModificationRequest { get; set; }

    public string? _920000DateOfReasonableModificationRequest { get; set; }

    public string? _921000DateRequestWasListedOnTheQuarterlyReportReasonableModificationLog { get; set; }

    public string? _922000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; }

    public string? _923000DoesTheGrievanceRelateToARequestForAuxiliaryAidsAndOrServicesForEffectiveCommunicationFromTheProperty { get; set; }

    public string? _924000IfYesPleaseChooseAllClaimsThatApplyFromTheListOfOptions { get; set; }

    public string? _925000DateOfEffectiveCommunicationRequest { get; set; }

    public string? _926000DateRequestWasListedOnTheQuarterlyReportEffectiveCommunicationLog { get; set; }

    public string? _927000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; }

    public string? _928000DoesTheGrievanceRelateToTheMaintenanceOfAccessibleFeaturesOtherThanElevatorsOrToBarriersBlockingAcce { get; set; }

    public string? _929000IfYesPleaseChooseAllClaimsThatApplyFromTheListOfOptions { get; set; }

    public string? _929500DescriptionOfMaintenanceIssue { get; set; }

    public string? _930000DoesTheGrievanceRelateToAnElevator { get; set; }

    public string? _931000IfYesPleaseChooseAllThatApplyFromTheListOfOptions { get; set; }

    public string? _932000DoesTheGrievanceRelateToPlacementOnAWaitingListOrTransferListOrTransferFromAWaitingListOrTransferL { get; set; }

    public string? _933000IfYesPleaseChooseAllThatApplyFromTheListOfOptions { get; set; }

    public string? _934000DateOfWaitingListOrUnitTransferRequest { get; set; }

    public string? _935000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; }

    public string? _936000DoesTheGrievantFaceAPotentialEvictionFromTheProperty { get; set; }

    public string? _937000IfYesHasTheGrievantBeenServedWithAnyOfTheFollowingPleaseChooseAllThatApply { get; set; }

    public string? _938000DateNoticeWasServed { get; set; }

    public string? _939000DoesTheGrievanceRelateToAThreatenedPendingOrPastEviction { get; set; }

    public string? _940000DoesTheGrievanceRelateToAProposedPendingOrCompletedRelocation { get; set; }

    public string? _941000IfYesPleaseDescribe { get; set; }

    public string? _942000DoesTheGrievanceRelateToAProposedPendingOrCompletedRetrofit { get; set; }

    public string? _943000IfYesPleaseDescribe { get; set; }

    public string? _944000NoiseComplaintsChooseAllThatApplyFromTheListOfOptions { get; set; }

    public string? _945000IfTheNoiseComplaintRelatesToNoiseFromAnotherTenantPleaseProvideThatTenantSName { get; set; }

    public string? _945100IfTheNoiseComplaintRelatesToNoiseFromAnotherUnitPleaseProvideThatUnitNumber { get; set; }

    public string? _945200IfTheNoiseComplaintRelatesToNoiseFromACommonAreaPleaseDescribeTheCommonAreaLocation { get; set; }

    public string? _946000DoesTheGrievanceRelateToAnAssistanceAnimalEitherAServiceAnimalOrEmotionalSupportAnimal { get; set; }

    public string? _947000IfYesPleaseChooseAllClaimsThatApplyFromTheListOfOptions { get; set; }

    public string? _948000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; }

    public string? _949000DoesTheGrievanceRelateToClaimsOfDiscriminationOrDifferentTreatmentFromThePropertyBecauseTheGrievantIsA { get; set; }

    public string? _950000IfYesPleaseChooseAllClaimsThatApplyFromTheListOfOptions { get; set; }

    public string? _951000DoesTheGrievanceRelateToClaimsOfHarassmentOnTheProperty { get; set; }

    public string? _952000IfYesChooseAllThatApplyFromTheListOfOptionsConcerningTheClaimedHarasserS { get; set; }

    public string? _953000IfTheClaimedHarasserIsAnEmployeeOfThePropertyProvideNamesOfTheEmployeeS { get; set; }

    public string? _954000IfTheClaimedHarasserIsAnEmployeeOfThePropertyProvideTitlesOfTheEmployeeS { get; set; }

    public string? _955000IfTheClaimedHarasserIsAnEmployeeOfThePropertyAndTheNameOrTitleAreUnknownPleaseProvideADescription { get; set; }

    public string? _956000IfTheClaimedHarasserIsAContractorOrAgentOfThePropertyProvideNamesOfThePersons { get; set; }

    public string? _957000IfTheClaimedHarasserIsAContractorOrAgentOfThePropertyProvideTitlesOfThePersons { get; set; }

    public string? _958000IfTheClaimedHarasserIsAContractorOrAgentOfThePropertyAndTheNameOrTitleAreUnknownPleaseProvideADe { get; set; }

    public string? _959000IfTheClaimedHarasserIsATenantOrGuestProvideNamesOfThePersons { get; set; }

    public string? _960000IfTheClaimedHarasserIsATenantOrGuestProvideTheUnitNumber { get; set; }

    public string? _961000IfTheClaimedHarasserIsATenantOrGuestAndTheNameOrUnitNumberAreUnknownPleaseProvideADescriptionOfT { get; set; }

    public string? _962000IfTheClaimedHarasserSIsSomeoneOtherThanAnEmployeeContractorAgentTenantOrGuestProvideAsMuchIdenti { get; set; }

    public string? _963000DoesTheGrievantBelieveTheyAreBeingHarassedBecauseTheyAreAMemberOfAGroupProtectedByTheFairHousingPol { get; set; }

    public string? _964000IfYesPleaseChooseAllClaimsThatApplyFromTheListOfOptions { get; set; }

    public string? _965000DoesTheGrievantAllegeTheyAreBeingRetaliatedAgainstByTheProperty { get; set; }

    public string? _966000IfYesPleaseChooseTheOptionsThatBestDescribeTheAllegedReasonForTheClaimedRetaliation { get; set; }

    public string? _967000IfYesPleaseChooseTheOptionsThatBestDescribeTheAllegedNatureOfTheRetaliatoryAction { get; set; }

    public string? _968000DoesTheGrievanceRelateToARentalApplication { get; set; }

    public string? _969000IfYesPleaseSelectTheOptionsThatBestDescribeTheAllegedBasisForTheGrievance { get; set; }

    public string? _970000DateGrievantSubmittedRentalApplication { get; set; }

    public string? _971000DateGrievantWasNotifiedOfDenialPartialDenialOrDelay { get; set; }

    public string? _972000OtherGrievanceDescribeOtherBasisForGrievance { get; set; }

    public string _973000PropertyGrievanceDeterminationStatus { get; set; } = null!;

    public string _974000PendingStatusDescription { get; set; } = null!;

    public bool _975000IsRecordsRequested { get; set; }

    public DateOnly? _976000RecordsRequestDate { get; set; }

    public bool _977000IsRecordsProvided { get; set; }

    public DateOnly? _978000PropertyGrievancePendingIfYesRecordsProvidedDate { get; set; }

    public DateOnly? _979000PropertyGrievancePendingIfNoRecordsProvidedDate { get; set; }

    public bool _980000IsMeetingRequested { get; set; }

    public DateOnly? _981000MeetingRequestDate { get; set; }

    public bool _982000IsMeetingScheduled { get; set; }

    public DateOnly? _983000MeetingScheduledDate { get; set; }

    public string _984000MeetingManagerName { get; set; } = null!;

    public string _985000MeetingManagerTitle { get; set; } = null!;

    public bool _986000IsAssistanceProvided { get; set; }

    public bool? _987000IsDecisionReceived { get; set; }

    public DateTime? _988000DecisionProvidedDate { get; set; }

    public DateTime? _989000DeterminationDateForPropertyGrievanceGranted { get; set; }

    public string _990000ExplanationOfDeterminationForPropertyGrievanceGranted { get; set; } = null!;

    public DateTime? _991000DateOfAnticipatedImplementationForPropertyGrievanceGranted { get; set; }

    public string _992000ImplementationDelayReasonForPropertyGrievanceGranted { get; set; } = null!;

    public bool? _993000IsDecisionReceivedForPropertyGrievanceGranted { get; set; }

    public DateOnly? _994000DecisionProvidedDateForPropertyGrievanceGranted { get; set; }

    public DateTime? _995000DeterminationDateForPropertyGrievancePartiallyGranted { get; set; }

    public string _996000ExplanationOfDeterminationForPropertyGrievancePartiallyGranted { get; set; } = null!;

    public DateTime? _997000DateOfAnticipatedImplementationForPropertyGrievancePartiallyGranted { get; set; }

    public string _998000ImplementationDelayReasonForPropertyGrievancePartiallyGranted { get; set; } = null!;

    public bool? _999000IsDecisionReceivedForPropertyGrievancePartiallyGranted { get; set; }

    public DateOnly? _1000000DecisionProvidedDateForPropertyGrievancePartiallyGranted { get; set; }

    public string _1001000FinalDeterminationPersonNamePartiallyGranted { get; set; } = null!;

    public string _1002000FinalDeterminationPersonTitlePartiallyGranted { get; set; } = null!;

    public string _1003000FinalDeterminationPersonPhonePartiallyGranted { get; set; } = null!;

    public DateTime? _1004000DeterminationDateForPropertyGrievanceDenied { get; set; }

    public string _1005000ExplanationOfDeterminationForPropertyGrievanceDenied { get; set; } = null!;

    public bool? _1006000IsDecisionReceivedForPropertyGrievanceDenied { get; set; }

    public DateTime? _1007000DecisionProvidedDateForPropertyGrievanceDenied { get; set; }

    public string _1008000FinalDeterminationPersonName { get; set; } = null!;

    public string _100900FinalDeterminationPersonTitle { get; set; } = null!;

    public string _1010000FinalDeterminationPersonPhone { get; set; } = null!;

    public DateOnly? _1011000WithdrawalDate { get; set; }

    public string _1012000WithdrawalReason { get; set; } = null!;

    public string _1013000GrievanceSubmitType { get; set; } = null!;
}
