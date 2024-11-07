using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_QRGrievanceLog
{
    public int? GrievanceLogID { get; set; }

    public int? QRGrievanceLogID { get; set; }

    public string YearQR { get; set; } = null!;

    public string? MaxYearQR { get; set; }

    public int QuarterlyReportID { get; set; }

    public int? MaxQrID { get; set; }

    public DateTime QRReportCreateDate { get; set; }

    public string? FileNumber { get; set; }

    public string IsReasonableAccommodation { get; set; } = null!;

    public string IsEffectiveCommunication { get; set; } = null!;

    public string IsFairHousingComplaint { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public int? UnitPropSnapShotID { get; set; }

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

    public string IsHUDCompliantFiled { get; set; } = null!;

    public string IsHCIDLACompliantFiled { get; set; } = null!;

    public string _328_000_GrievanceRelatedToReasonableAccommodation_GLog { get; set; } = null!;

    public string _329_000_GrievanceRelatedToEffectiveCommunication_GLog { get; set; } = null!;

    public string _330_000_GrievanceRelatedToFairHousing_GLog { get; set; } = null!;

    public string _331_000_IsGrievantApplicant_GLog { get; set; } = null!;

    public string _332_000_IsGrievantTenant_GLog { get; set; } = null!;

    public string? _333_000_GrievanceLogDeterminationStatus_GLog { get; set; }

    public string? _334_000_DescriptionOfGrievance_GLog { get; set; }

    public string _335_000_DateOfAnticipatedImplementation_GLog { get; set; } = null!;

    public string _336_000_DateOfImplementationCompletion_GLog { get; set; } = null!;

    public string? _500_000_GrievanceLogNumber { get; set; }

    public string? _501_000_GrievantFirstName_GLog { get; set; }

    public string _502_000_GrievantMiddleInitial_GLog { get; set; } = null!;

    public string? _503_000_Grievant_Last_Name_GLog { get; set; }

    public string _504_000_DateGrievanceFiled_GLog { get; set; } = null!;

    public string? _505_000_PropertyNameSubjectToGrievance_GLog { get; set; }

    public string? _506_000_PropertyAcHPNumberSubjectToGrievance_GLog { get; set; }

    public string? _507_000_PropertyAddressSubjectToGrievance_GLog { get; set; }

    public string _508_000_IfApplicable_UnitNumberRelevantToGrievance_GLog { get; set; } = null!;

    public string? _509_000_DescriptionOfGrievance_GLog { get; set; }

    public string? _510_000_DevelopmentCategoryForGrievance_GLog { get; set; }

    public string? _512_000_ResolutionOfGrievance_GLog { get; set; }

    public string? _515_000_GrievanceLogDeterminationStatus_GLog { get; set; }

    public string _517_000_Property_GrievanceType { get; set; } = null!;

    public string? _518_000_GrievanceLogDeterminationStatus_GLog { get; set; }

    public string _519_000_GrievanceLogDeterminationDate_GLog { get; set; } = null!;

    public string _520_000_GrievanceLogAnticipatedDate_GLog { get; set; } = null!;

    public string _521_000_GrievanceLogImplementationDate_GLog { get; set; } = null!;

    public string _522_000_GrievanceLogAnyComplaintsFiled_GLog { get; set; } = null!;

    public string _522_100_GrievanceLogIsFairHousingComplaintFiled_GLog { get; set; } = null!;

    public string _522_100_GrievanceLogIsHUDCompliantFiled_GLog { get; set; } = null!;

    public string _522_100_GrievanceLogIIsHCIDLACompliantFiled_GLog { get; set; } = null!;

    public string _511_000_City_PropertyActionOn_Grievance { get; set; } = null!;

    public string? _900_000_Does_the_grievance_relate_to_a_pending_or_prior_request_for_a_reasonable_accommodation_from_the_property_ { get; set; }

    public string? _901_000_Type_s__of_Reasonable_Accommodation_requested_by_the_grievant { get; set; }

    public string? _902_000_Does_the_grievant_allege_their_reasonable_accommodation_request_has_not_been_processed_promptly_ { get; set; }

    public string? _903_000_Does_the_grievant_allege_the_property_has_unreasonably_requested_a_third_party_verification_ { get; set; }

    public string? _904_000_Does_the_grievant_allege_the_property_has_partially_denied_their_reasonable_accommodation_request_ { get; set; }

    public string? _905_000_Does_the_grievant_allege_the_property_has_denied_their_reasonable_accommodation_request_ { get; set; }

    public string? _906_000_Does_the_grievant_allege_there_are_other_issues_regarding_their_reasonable_accommodation_request_not_already_listed_ { get; set; }

    public string? _907_000_Description_of_other_issues_regarding_reasonable_accommodation_request { get; set; }

    public string? _908_000_Date_of_Reasonable_Accommodation_request { get; set; }

    public string? _909_000_Date_request_was_listed_on_the_Quarterly_Report_Reasonable_Accommodation_log { get; set; }

    public string? _910_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; }

    public string? _911_000_Does_the_grievance_relate_to_a_pending_or_prior_request_for_a_reasonable_modification_from_the_property_ { get; set; }

    public string? _912_000_Type_s__of_Reasonable_Modification_requested_by_the_grievant { get; set; }

    public string? _913_000_Description_of_requested_feature { get; set; }

    public string? _914_000_Does_the_grievant_allege_their_reasonable_modification_has_not_been_processed_promptly_ { get; set; }

    public string? _915_000_Does_the_grievant_allege_the_property_has_unreasonably_requested_a_third_party_verification_ { get; set; }

    public string? _916_000_Does_the_grievant_allege_the_property_has_partially_denied_their_reasonable_modification_request_ { get; set; }

    public string? _917_000_Does_the_grievant_allege_the_property_has_denied_their_reasonable_modification_request_ { get; set; }

    public string? _918_000_Does_the_property_grievant_allege_there_are_other_issues_regarding_their_reasonable_modification_request_not_already_lis { get; set; }

    public string? _919_000_Explanation_of_the_other_issues_regarding_reasonable_modification_request { get; set; }

    public string? _920_000_Date_of_Reasonable_Modification_request { get; set; }

    public string? _921_000_Date_request_was_listed_on_the_Quarterly_Report_Reasonable_Modification_log { get; set; }

    public string? _922_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; }

    public string? _923_000_Does_the_grievance_relate_to_a_request_for_auxiliary_aids_and_or_services_for_effective_communication_from_the_property_ { get; set; }

    public string? _924_000_If_yes__please_choose_all_claims_that_apply_from_the_list_of_options { get; set; }

    public string? _925_000_Date_of_effective_communication_request { get; set; }

    public string? _926_000_Date_request_was_listed_on_the_Quarterly_Report_Effective_Communication_log { get; set; }

    public string? _927_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; }

    public string? _928_000_Does_the_grievance_relate_to_the_maintenance_of_accessible_features__other_than_elevators___or_to_barriers_blocking_acce { get; set; }

    public string? _929_000_If_yes__please_choose_all_claims_that_apply_from_the_list_of_options { get; set; }

    public string? _929_500_Description_of_maintenance_issue { get; set; }

    public string? _930_000_Does_the_grievance_relate_to_an_elevator_ { get; set; }

    public string? _931_000_If_yes__please_choose_all_that_apply_from_the_list_of_options { get; set; }

    public string? _932_000_Does_the_grievance_relate_to_placement_on_a_waiting_list_or_transfer_list__or_transfer_from_a_waiting_list_or_transfer_l { get; set; }

    public string? _933_000_If_yes__please_choose_all_that_apply_from_the_list_of_options { get; set; }

    public string? _934_000_Date_of_Waiting_List_or_Unit_Transfer_request { get; set; }

    public string? _935_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; }

    public string? _936_000_Does_the_grievant_face_a_potential_eviction_from_the_property_ { get; set; }

    public string? _937_000_If_yes__has_the_grievant_been_served_with_any_of_the_following__Please_choose_all_that_apply { get; set; }

    public string? _938_000_Date_Notice_was_served { get; set; }

    public string? _939_000_Does_the_grievance_relate_to_a_threatened__pending__or_past_eviction_ { get; set; }

    public string? _940_000_Does_the_grievance_relate_to_a_proposed__pending__or_completed_relocation_ { get; set; }

    public string? _941_000_If_yes__please_describe { get; set; }

    public string? _942_000_Does_the_grievance_relate_to_a_proposed__pending__or_completed_retrofit_ { get; set; }

    public string? _943_000_If_yes__please_describe { get; set; }

    public string? _944_000_Noise_complaints__choose_all_that_apply_from_the_list_of_options { get; set; }

    public string? _945_000_If_the_noise_complaint_relates_to_noise_from_another_tenant__please_provide_that_tenant_s_name { get; set; }

    public string? _945_100_If_the_noise_complaint_relates_to_noise_from_another_unit__please_provide_that_unit_number { get; set; }

    public string? _945_200_If_the_noise_complaint_relates_to_noise_from_a_common_area__please_describe_the_common_area_location { get; set; }

    public string? _946_000_Does_the_grievance_relate_to_an_assistance_animal__either_a_service_animal_or_emotional_support_animal_ { get; set; }

    public string? _947_000_If_yes__please_choose_all_claims_that_apply_from_the_list_of_options { get; set; }

    public string? _948_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; }

    public string? _949_000_Does_the_grievance_relate_to_claims_of_discrimination_or_different_treatment_from_the_property_because_the_grievant_is_a { get; set; }

    public string? _950_000_If_yes__please_choose_all_claims_that_apply_from_the_list_of_options { get; set; }

    public string? _951_000_Does_the_grievance_relate_to_claims_of_harassment_on_the_property_ { get; set; }

    public string? _952_000_If_yes__choose_all_that_apply_from_the_list_of_options_concerning_the_claimed_harasser_s_ { get; set; }

    public string? _953_000_If_the_claimed_harasser_is_an_employee_of_the_property__provide_names_of_the_employee_s_ { get; set; }

    public string? _954_000_If_the_claimed_harasser_is_an_employee_of_the_property__provide_titles_of_the_employee_s_ { get; set; }

    public string? _955_000_If_the_claimed_harasser_is_an_employee_of_the_property__and_the_name_or_title_are_unknown__please_provide_a_description_ { get; set; }

    public string? _956_000_If_the_claimed_harasser_is_a_contractor_or_agent_of_the_property__provide_names_of_the_persons { get; set; }

    public string? _957_000_If_the_claimed_harasser_is_a_contractor_or_agent_of_the_property__provide_titles_of_the_persons { get; set; }

    public string? _958_000_If_the_claimed_harasser_is_a_contractor_or_agent_of_the_property__and_the_name_or_title_are_unknown__please_provide_a_de { get; set; }

    public string? _959_000_If_the_claimed_harasser_is_a_tenant_or_guest__provide_names_of_the_persons { get; set; }

    public string? _960_000_If_the_claimed_harasser_is_a_tenant_or_guest__provide_the_unit_number { get; set; }

    public string? _961_000_If_the_claimed_harasser_is_a_tenant_or_guest__and_the_name_or_unit_number_are_unknown__please_provide_a_description_of_t { get; set; }

    public string? _962_000_If_the_claimed_harasser_s__is_someone_other_than_an_employee__contractor__agent__tenant_or_guest__provide_as_much_identi { get; set; }

    public string? _963_000_Does_the_grievant_believe_they_are_being_harassed_because_they_are_a_member_of_a_group_protected_by_the_Fair_Housing_Pol { get; set; }

    public string? _964_000_If_yes__please_choose_all_claims_that_apply_from_the_list_of_options { get; set; }

    public string? _965_000_Does_the_grievant_allege_they_are_being_retaliated_against_by_the_property_ { get; set; }

    public string? _966_000_If_yes__please_choose_the_options_that_best_describe_the_alleged_reason_for_the_claimed_retaliation { get; set; }

    public string? _967_000_If_yes__please_choose_the_options_that_best_describe_the_alleged_nature_of_the_retaliatory_action { get; set; }

    public string? _968_000_Does_the_grievance_relate_to_a_rental_application_ { get; set; }

    public string? _969_000_If_yes__please_select_the_options_that_best_describe_the_alleged_basis_for_the_grievance { get; set; }

    public string? _970_000_Date_grievant_submitted_Rental_Application { get; set; }

    public string? _971_000_Date_grievant_was_notified_of_denial__partial_denial__or_delay { get; set; }

    public string? _972_000_Other_grievance__Describe_other_basis_for_grievance { get; set; }

    public string _973_000_PropertyGrievanceDeterminationStatus { get; set; } = null!;

    public string _974_000_PendingStatusDescription { get; set; } = null!;

    public bool _975_000_IsRecordsRequested { get; set; }

    public DateOnly? _976_000_RecordsRequestDate { get; set; }

    public bool _977_000_IsRecordsProvided { get; set; }

    public DateOnly? _978_000_PropertyGrievancePending_If_Yes_RecordsProvidedDate { get; set; }

    public DateOnly? _979_000_PropertyGrievancePending_If_No_RecordsProvidedDate { get; set; }

    public bool _980_000_IsMeetingRequested { get; set; }

    public DateOnly? _981_000_MeetingRequestDate { get; set; }

    public bool _982_000_IsMeetingScheduled { get; set; }

    public DateOnly? _983_000_MeetingScheduledDate { get; set; }

    public string _984_000_MeetingManagerName { get; set; } = null!;

    public string _985_000_MeetingManagerTitle { get; set; } = null!;

    public bool _986_000_IsAssistanceProvided { get; set; }

    public bool? _987_000_IsDecisionReceived { get; set; }

    public DateTime? _988_000_DecisionProvidedDate { get; set; }

    public DateTime? _989_000_DeterminationDateForPropertyGrievance_Granted { get; set; }

    public string _990_000_ExplanationOfDeterminationForPropertyGrievance_Granted { get; set; } = null!;

    public DateTime? _991_000_DateOfAnticipatedImplementationForPropertyGrievance_Granted { get; set; }

    public string _992_000_ImplementationDelayReasonForPropertyGrievance_Granted { get; set; } = null!;

    public bool? _993_000_IsDecisionReceivedForPropertyGrievance_Granted { get; set; }

    public DateOnly? _994_000_DecisionProvidedDateForPropertyGrievance_Granted { get; set; }

    public DateTime? _995_000_DeterminationDateForPropertyGrievance_Partially_Granted { get; set; }

    public string _996_000_ExplanationOfDeterminationForPropertyGrievance_Partially_Granted { get; set; } = null!;

    public DateTime? _997_000_DateOfAnticipatedImplementationForPropertyGrievance_Partially_Granted { get; set; }

    public string _998_000_ImplementationDelayReasonForPropertyGrievance_Partially_Granted { get; set; } = null!;

    public bool? _999_000_IsDecisionReceivedForPropertyGrievance_Partially_Granted { get; set; }

    public DateOnly? _1000_000_DecisionProvidedDateForPropertyGrievance_Partially_Granted { get; set; }

    public string _1001_000_FinalDeterminationPersonName_Partially_Granted { get; set; } = null!;

    public string _1002_000_FinalDeterminationPersonTitle_Partially_Granted { get; set; } = null!;

    public string _1003_000_FinalDeterminationPersonPhone_Partially_Granted { get; set; } = null!;

    public DateTime? _1004_000_DeterminationDateForPropertyGrievance_Denied { get; set; }

    public string _1005_000_ExplanationOfDeterminationForPropertyGrievance_Denied { get; set; } = null!;

    public bool? _1006_000_IsDecisionReceivedForPropertyGrievance_Denied { get; set; }

    public DateTime? _1007_000_DecisionProvidedDateForPropertyGrievance_Denied { get; set; }

    public string _1008_000_FinalDeterminationPersonName { get; set; } = null!;

    public string _1009_00_FinalDeterminationPersonTitle { get; set; } = null!;

    public string _1010_000_FinalDeterminationPersonPhone { get; set; } = null!;

    public DateOnly? _1011_000_WithdrawalDate { get; set; }

    public string _1012_000_WithdrawalReason { get; set; } = null!;

    public string _1013_000_GrievanceSubmitType { get; set; } = null!;
}
