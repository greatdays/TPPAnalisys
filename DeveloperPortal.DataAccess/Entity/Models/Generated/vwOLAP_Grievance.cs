using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_Grievance
{
    public int GrievanceID { get; set; }

    public int? PropertyId { get; set; }

    public string? Property_Name { get; set; }

    public long ServiceRequestID { get; set; }

    public string? _142_010_GrievanceIDNumber { get; set; }

    public string? _142_020_GrievantFirstName { get; set; }

    public string? _142_021_GrievantMiddleName { get; set; }

    public string? _142_022_GrievantLastName { get; set; }

    public string _142_025_DateGrievanceFiled { get; set; } = null!;

    public string _142_028_IsIncidentSpecificLocation { get; set; } = null!;

    public string? _142_030_PropertyNameSubToGrievance { get; set; }

    public string? _142_040_PropertyAcHpNumberSubToGrievance { get; set; }

    public string? _142_050_PropertyAddressSubToGrievance { get; set; }

    public int? _142_051_IncidentAddressHouseNum { get; set; }

    public string? _142_052_IncidentAddressHouseFracNum { get; set; }

    public string? _142_053_IncidentAddressLutPreDirCD { get; set; }

    public string? _142_054_IncidentAddressStreetName { get; set; }

    public string? _142_055_IncidentAddressLutStreetTypeCD { get; set; }

    public string? _142_060_UnitNoRelateToGrievance { get; set; }

    public string? _142_061_IncidentAddressCity { get; set; }

    public string? _142_062_IncidentAddressLutStateCD { get; set; }

    public int? _142_063_IncidentAddressZip { get; set; }

    public string? _142_070_DescriptionOfGrievance { get; set; }

    public string _142_080_DevelopmentCategoryForGrievance { get; set; } = null!;

    public string _142_081_IsCoveredHousingDevelopment { get; set; } = null!;

    public string _142_082_IsDisabilityRelated { get; set; } = null!;

    public string? _142_090_CityActionOnGrievance { get; set; }

    public string? _142_100_ResolutionOnGrievance { get; set; }

    public string _142_110_GrievanceOutcomeStafisfactoryOrUnsatisfactory { get; set; } = null!;

    public string _142_120_ReferralSourcesConcerningGrievance { get; set; } = null!;

    public string _142_130_StatusOnGrievance { get; set; } = null!;

    public string? _142_140_ModeOfGrievanceSubmission { get; set; }

    public string _142_150_GrievanceType { get; set; } = null!;

    public string? _142_160_GrievanceDeterminationStatus { get; set; }

    public string _142_170_DateOfGrievanceDetermination { get; set; } = null!;

    public string? _142_180_DateOfAnticipatedImplementationInResponseToGrievance { get; set; }

    public string? _142_190_DateOfImplementationInResponseToGrievance { get; set; }

    public string _143_500_IsFiledRelatedGrievance { get; set; } = null!;

    public string _144_DatesGrievancesAgainstPropertyFiledWithCity { get; set; } = null!;

    public string _144_500_RelatedGrievanceQRGrievanceLogID { get; set; } = null!;

    public string? _145_DateAcHPReviewGrivancesWithCityAgainstProperty { get; set; }

    public string _175_CityGrievancesDateOpenedAndClosed { get; set; } = null!;

    public string _175_100_CityGrievances { get; set; } = null!;

    public string? _175_200_DateCityGrievancesOpened { get; set; }

    public string? _175_300_DateCityGrievancesClosed { get; set; }

    public string? _758_Grv_Grievant_PrimaryPhoneType { get; set; }

    public string? _759_Grv_Grievant_PrimaryPhoneNumber { get; set; }

    public string? _760_Grv_Grievant_AdditonalPhoneType { get; set; }

    public string? _761_Grv_Grievant_AdditionalPhoneNumber { get; set; }

    public string? _762_Grv_Grievant_Email { get; set; }

    public string? _763_Grv_Grievant_PreferredLanguage { get; set; }

    public string _764_Grv_Grievant_PreferredMethodOfContact { get; set; } = null!;

    public string? _765_Grv_Grievant_OtherPreferredMethodOfContact { get; set; }

    public string _766_Grv_Add_POBOX { get; set; } = null!;

    public string? _767_Grv_Add_POBOXNumber { get; set; }

    public int? _767_100_GrievantAddressHouseNum { get; set; }

    public string? _767_200_GrievantAddressHouseFracNum { get; set; }

    public string? _767_300_GrievantAddressLutPreDirCD { get; set; }

    public string? _767_400_GrievantAddressStreetName { get; set; }

    public string? _767_500_GrievantAddressLutStreetTypeCD { get; set; }

    public string? _767_600_GrievantAddressUnit { get; set; }

    public string? _767_700_GrievantAddressCity { get; set; }

    public string? _767_800_GrievantAddressLutStateCD { get; set; }

    public int? _767_900_GrievantAddressZip { get; set; }

    public string _767_901_IsFileForSomeOne { get; set; } = null!;

    public string? _768_Grv_Preparer_RelationshipToPersonWhohasGrievance { get; set; }

    public string? _769_Grv_Preparer_FirstName { get; set; }

    public string? _770_Grv_Preparer_MiddleName { get; set; }

    public string? _771_Grv_Preparer_LastName { get; set; }

    public string? _773_Grv_Preparer_PrimaryPhoneNumber { get; set; }

    public string? _772_Grv_Preparer_PrimaryPhoneType { get; set; }

    public string? _775_Grv_Preparer_AdditionalPhoneNumber { get; set; }

    public string? _774_Grv_Preparer_AdditonalPhoneType { get; set; }

    public string? _776_Grv_Preparer_Email { get; set; }

    public string _777_Grv_Preparer_PreferredMethodOfContact { get; set; } = null!;

    public string? _778_Grv_Preparer_OtherPreferredMethodOfContact { get; set; }

    public string _779_Grv_PreparerAdd_POBOX { get; set; } = null!;

    public string? _780_Grv_PreparerAdd_POBOXNumber { get; set; }

    public int? _781_Grv_PreparerAdd_HouseNumber { get; set; }

    public string? _782_Grv_PreparerAdd_HouseFractionNumber { get; set; }

    public string? _783_Grv_PreparerAdd_StreetDirection { get; set; }

    public string? _784_Grv_PreparerAdd_StreetName { get; set; }

    public string? _785_Grv_PreparerAdd_StreetType { get; set; }

    public string? _785_100_PreparerAddressUnit { get; set; }

    public string? _785_200_PreparerAddressCity { get; set; }

    public string? _786_Grv_PreparerAdd_State { get; set; }

    public int? _787_Grv_PreparerAdd_ZipCode { get; set; }

    public int? _788_Grv_Location_HouseNumber { get; set; }

    public string? _789_Grv_Location_HouseFractionNumber { get; set; }

    public string? _790_Grv_Location_StreetDirection { get; set; }

    public string? _791_Grv_Location_StreetName { get; set; }

    public string? _792_Grv_Location_StreetType { get; set; }

    public string? _793_Grv_Location_UnitNumber { get; set; }

    public string? _794_Grv_Location_City { get; set; }

    public string? _795_Grv_Location_State { get; set; }

    public int? _796_Grv_Location_ZipCode { get; set; }

    public string _797_Grv_Notice_NoticeToVacateFromTheOwnerOrManager { get; set; } = null!;

    public string _798_Grv_Notice_UnlawfulDetainerSummonsfromTheCourt { get; set; } = null!;

    public string _799_Grv_Notice_SheriffNoticeToVacate { get; set; } = null!;

    public string _800_Grv_Notice_WereDateToMoveOutGiven { get; set; } = null!;

    public string _801_Grv_Notice_DateGivenToMoveOut { get; set; } = null!;

    public string _801_500_IsUnitDenied { get; set; } = null!;

    public string _802_Grv_Notice_IsItStillVacant { get; set; } = null!;

    public string _803_Grv_Notice_WasItAnAccessibleUnit { get; set; } = null!;

    public string? _804_Grv_Notice_SupportingDocuments { get; set; }

    public string _804_500_Case_Status { get; set; } = null!;

    public string? _805_Grv_Status_Assignee { get; set; }

    public string? _806_Grv_Milestone_CaseExtensionProvided { get; set; }

    public string? _807_Grv_Milestone_NoticeOfAppeal { get; set; }

    public string? _808_Grv_System_AcHPEmployeeName { get; set; }

    public string? _809_Grv_UnitNumber { get; set; }

    public string _1014_000_Does_the_grievance_relate_to_a_pending_or_prior_request_for_a_reasonable_accommodation_from_the_property_ { get; set; } = null!;

    public string? _1015_000_Type_s__of_Reasonable_Accommodation_requested_by_the_grievant { get; set; }

    public string _1016_000_Does_the_grievant_allege_their_reasonable_accommodation_request_has_not_been_processed_promptly_ { get; set; } = null!;

    public string _1017_000_Does_the_grievant_allege_the_property_has_unreasonably_requested_a_third_party_verification_ { get; set; } = null!;

    public string _1018_000_Does_the_grievant_allege_the_property_has_partially_denied_their_reasonable_accommodation_request_ { get; set; } = null!;

    public string _1019_000_Does_the_grievant_allege_the_property_has_denied_their_reasonable_accommodation_request_ { get; set; } = null!;

    public string _1020_000_Does_the_grievant_allege_there_are_other_issues_regarding_their_reasonable_accommodation_request_not_already_listed_ { get; set; } = null!;

    public string? _1021_000_Description_of_other_issues_regarding_reasonable_accommodation_request { get; set; }

    public string _1022_000_Date_of_Reasonable_Accommodation_request { get; set; } = null!;

    public string _1023_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; } = null!;

    public string _1024_000_Does_the_grievance_relate_to_a_pending_or_prior_request_for_a_reasonable_modification_from_the_property_ { get; set; } = null!;

    public string? _1025_000_Type_s__of_Reasonable_Modification_requested_by_the_grievant { get; set; }

    public string? _1026_000_Description_of_requested_feature { get; set; }

    public string _1027_000_Does_the_grievant_allege_their_reasonable_modification_has_not_been_processed_promptly_ { get; set; } = null!;

    public string _1028_000_Does_the_grievant_allege_the_property_has_unreasonably_requested_a_third_party_verification_ { get; set; } = null!;

    public string _1029_000_Does_the_grievant_allege_the_property_has_partially_denied_their_reasonable_modification_request_ { get; set; } = null!;

    public string _1030_000_Does_the_grievant_allege_the_property_has_denied_their_reasonable_modification_request_ { get; set; } = null!;

    public string _1031_000_Does_the_property_grievant_allege_there_are_other_issues_regarding_their_reasonable_modification_request_not_already_li { get; set; } = null!;

    public string? _1032_000_Explanation_of_the_other_issues_regarding_reasonable_modification_request { get; set; }

    public string _1033_000_Date_of_Reasonable_Modification_request { get; set; } = null!;

    public string _1034_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; } = null!;

    public string _1035_000_Does_the_grievance_relate_to_a_request_for_auxiliary_aids_and_or_services_for_effective_communication_from_the_property { get; set; } = null!;

    public string? _1036_000_If_yes__please_choose_all_claims_that_apply_from_the_list_of_options { get; set; }

    public string _1037_000_Date_of_effective_communication_request { get; set; } = null!;

    public string _1038_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; } = null!;

    public string _1039_000_Does_the_grievance_relate_to_the_maintenance_of_accessible_features__other_than_elevators___or_to_barriers_blocking_acc { get; set; } = null!;

    public string? _1040_000_If_yes__please_choose_all_claims_that_apply_from_the_list_of_options { get; set; }

    public string? _1041_000_Description_of_maintenance_issue { get; set; }

    public string _1042_000_Does_the_grievance_relate_to_an_elevator_ { get; set; } = null!;

    public string? _1043_000_If_yes__please_choose_all_that_apply_from_the_list_of_options { get; set; }

    public string _1044_000_Does_the_grievance_relate_to_placement_on_a_waiting_list_or_transfer_list__or_transfer_from_a_waiting_list_or_transfer_ { get; set; } = null!;

    public string? _1045_000_If_yes__please_choose_all_that_apply_from_the_list_of_options { get; set; }

    public string _1046_000_Date_of_Waiting_List_or_Unit_Transfer_request { get; set; } = null!;

    public string _1047_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; } = null!;

    public string _1048_000_Does_the_grievant_face_a_potential_eviction_from_the_property_ { get; set; } = null!;

    public string? _1049_000_If_yes__has_the_grievant_been_served_with_any_of_the_following__Please_choose_all_that_apply { get; set; }

    public string _1050_000_Date_Notice_was_served { get; set; } = null!;

    public string _1051_000_Does_the_grievance_relate_to_a_threatened__pending__or_past_eviction_ { get; set; } = null!;

    public string _1052_000_Does_the_grievance_relate_to_a_proposed__pending__or_completed_relocation_ { get; set; } = null!;

    public string? _1053_000_If_yes__please_describe { get; set; }

    public string _1054_000_Does_the_grievance_relate_to_a_proposed__pending__or_completed_retrofit_ { get; set; } = null!;

    public string? _1055_000_If_yes__please_describe { get; set; }

    public string _1056_000_Noise_complaints__choose_all_that_apply_from_the_list_of_options { get; set; } = null!;

    public string? _1057_000_If_the_noise_complaint_relates_to_noise_from_another_tenant__please_provide_that_tenant_s_name { get; set; }

    public string? _1058_000_If_the_noise_complaint_relates_to_noise_from_another_unit__please_provide_that_unit_number { get; set; }

    public string? _1059_000_If_the_noise_complaint_relates_to_noise_from_a_common_area__please_describe_the_common_area_location { get; set; }

    public string _1060_000_Does_the_grievance_relate_to_an_assistance_animal__either_a_service_animal_or_emotional_support_animal_ { get; set; } = null!;

    public string? _1061_000_If_yes__please_choose_all_claims_that_apply_from_the_list_of_options { get; set; }

    public string _1062_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; } = null!;

    public string _1063_000_Does_the_grievance_relate_to_claims_of_discrimination_or_different_treatment_from_the_property_because_the_grievant_is_ { get; set; } = null!;

    public string? _1064_000_If_yes__please_choose_all_claims_that_apply_from_the_list_of_options { get; set; }

    public string _1065_000_Does_the_grievance_relate_to_claims_of_harassment_on_the_property_ { get; set; } = null!;

    public string _1066_000_If_yes__choose_all_that_apply_from_the_list_of_options_concerning_the_claimed_harasser_s_ { get; set; } = null!;

    public string? _1067_000_If_the_claimed_harasser_is_an_employee_of_the_property__provide_names_of_the_employee_s_ { get; set; }

    public string? _1068_000_If_the_claimed_harasser_is_an_employee_of_the_property__provide_titles_of_the_employee_s_ { get; set; }

    public string? _1069_000_If_the_claimed_harasser_is_an_employee_of_the_property__and_the_name_or_title_are_unknown__please_provide_a_description { get; set; }

    public string? _1070_000_If_the_claimed_harasser_is_a_contractor_or_agent_of_the_property__provide_names_of_the_persons { get; set; }

    public string? _1071_000_If_the_claimed_harasser_is_a_contractor_or_agent_of_the_property__provide_titles_of_the_persons { get; set; }

    public string? _1072_000_If_the_claimed_harasser_is_a_contractor_or_agent_of_the_property__and_the_name_or_title_are_unknown__please_provide_a_d { get; set; }

    public string? _1073_000_If_the_claimed_harasser_is_a_tenant_or_guest__provide_names_of_the_persons { get; set; }

    public string? _1074_000_If_the_claimed_harasser_is_a_tenant_or_guest__provide_the_unit_number { get; set; }

    public string? _1075_000_If_the_claimed_harasser_is_a_tenant_or_guest__and_the_name_or_unit_number_are_unknown__please_provide_a_description_of_ { get; set; }

    public string? _1076_000_If_the_claimed_harasser_s__is_someone_other_than_an_employee__contractor__agent__tenant_or_guest__provide_as_much_ident { get; set; }

    public string _1077_000_Does_the_grievant_believe_they_are_being_harassed_because_they_are_a_member_of_a_group_protected_by_the_Fair_Housing_Po { get; set; } = null!;

    public string? _1078_000_If_yes__please_choose_all_claims_that_apply_from_the_list_of_options { get; set; }

    public string _1079_000_Does_the_grievant_allege_they_are_being_retaliated_against_by_the_property_ { get; set; } = null!;

    public string? _1080_000_If_yes__please_choose_the_options_that_best_describe_the_alleged_reason_for_the_claimed_retaliation { get; set; }

    public string? _1081_000_If_yes__please_choose_the_options_that_best_describe_the_alleged_nature_of_the_retaliatory_action { get; set; }

    public string _1082_000_Does_the_grievance_relate_to_a_rental_application_ { get; set; } = null!;

    public string? _1083_000_If_yes__please_select_the_options_that_best_describe_the_alleged_basis_for_the_grievance { get; set; }

    public string _1084_000_Date_grievant_submitted_Rental_Application { get; set; } = null!;

    public string _1085_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; } = null!;

    public string? _1086_000_Other_grievance__Describe_other_basis_for_grievance { get; set; }

    public string _1087_000_Did_the_City_Grievant_file_a_grievance_with_the_Property_related_to_the_same_issue_as_the_City_grievance___Verify_by_ch { get; set; } = null!;

    public string _1088_000_If_yes__date_of_the_property_grievance { get; set; } = null!;

    public string _1089_000_If_yes__date_the_grievance_was_listed_on_the_Quarterly_Report_Grievance_Log { get; set; } = null!;

    public string _1090_000_If_yes__date_the_grievant_received_decision_from_property { get; set; } = null!;

    public string _1091_000_Did_the_Property_follow_required_Procedures_in_response_to_any_Reasonable_Accommodation__Reasonable_Modification_or_Eff { get; set; } = null!;

    public string? _1092_000_If_no__please_explain { get; set; }

    public string? _1116_000_GrievanceSubmissionSource { get; set; }

    public string? _1117_000_LastActionDate { get; set; }

    public int? _1118_000_NumberOfDaysSinceGrievanceReceived { get; set; }

    public string _1119_000_CaseCreatedOn { get; set; } = null!;

    public string _1120_000_ReferredToAgency { get; set; } = null!;

    public string? _1121_000_CaseOpened { get; set; }

    public string? _1122_000_NoticeOfDetermination { get; set; }

    public string? _1123_000_LinkedProperties { get; set; }

    public string? _1124_000_AcHPEmployeeUsername { get; set; }

    public string? _1022_001_PrevReasonableAccmQRID { get; set; }

    public string? _1033_001_PrevReasonableModfQRID { get; set; }

    public string? _1037_001_PrevEffectiveCommQRID { get; set; }

    public string? _183_400_FiledLawsuitWithAnotherAgency { get; set; }

    public string _183_500_LawsuitFiledAgencyNames { get; set; } = null!;

    public string _183_600_LawSuitFiledDates { get; set; } = null!;
}
