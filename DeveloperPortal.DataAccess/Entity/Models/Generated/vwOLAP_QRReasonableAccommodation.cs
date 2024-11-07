using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_QRReasonableAccommodation
{
    public string? RARequestType { get; set; }

    public string YearQR { get; set; } = null!;

    public string? MaxYearQR { get; set; }

    public int QuarterlyReportID { get; set; }

    public int? MaxQrID { get; set; }

    public int? ProjectID { get; set; }

    public int PropertyID { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyName { get; set; }

    public int RAQuarterReportID { get; set; }

    public int QRReasonableAccommodationID { get; set; }

    public int? ReasonableAccommodationID { get; set; }

    public DateTime QRReportCreateDate { get; set; }

    public string? FileNumber { get; set; }

    public string? UserType { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public int? UnitPropSnapShotID { get; set; }

    public string? UnitNum { get; set; }

    public string? RequestorAddress { get; set; }

    public DateTime? RequestDate { get; set; }

    public string IsTransferRequest { get; set; } = null!;

    public string IsNeedAUUnit { get; set; } = null!;

    public string IsOnAUWaitList { get; set; } = null!;

    public string IsOnAUTransferList { get; set; } = null!;

    public string? Bedrooms { get; set; }

    public string? Bathrooms { get; set; }

    public string? RequestDescription { get; set; }

    public string? DeterminationStatus { get; set; }

    public DateTime? DeterminationDate { get; set; }

    public string? DeterminationExplaination { get; set; }

    public DateTime? AnticipatedImplementationDate { get; set; }

    public DateTime? ImplementationDate { get; set; }

    public string? ImplementationNotes { get; set; }

    public string IsGrievanceProcedureProvided { get; set; } = null!;

    public string IsGrievanceField { get; set; } = null!;

    public DateTime? GrievanceDate { get; set; }

    public string? GrievanceLogNumber { get; set; }

    public string? _047_000_UnitNumberSubjectToReasonableModification { get; set; }

    public string _137_100_DateOfRequestForReasonableAccommodationOrReasonableModification { get; set; } = null!;

    public string _270_000_ReasonableAccommodationRequestThisQuarter { get; set; } = null!;

    public string? _270_000_ReasonableAccommodationID { get; set; }

    public string _271_000_ReasonableAccommodationGrantedOnReport { get; set; } = null!;

    public string _271_000_ReasonableAccommodationGrantedThisQuarter { get; set; } = null!;

    public string _271_000_ReasonableAccommodationGrantedAndPartiallyGrantedOnReport { get; set; } = null!;

    public string _271_000_ReasonableAccommodationGrantedAndPartiallyGrantedOnReportThisQuarter { get; set; } = null!;

    public string _272_000_ReasonableAccommodationDeniedOnReport { get; set; } = null!;

    public string _272_000_ReasonableAccommodationDeniedThisQuarter { get; set; } = null!;

    public string _273_000_ReasonableAccommodationPendingOnReport { get; set; } = null!;

    public string _275_000_ReasonableModificationThisQuarter { get; set; } = null!;

    public string? _275_000_ReasonableModificationID { get; set; }

    public string _276_000_ReasonableModificationGrantedOnReport { get; set; } = null!;

    public string _276_000_ReasonableModificationGrantedThisQuarter { get; set; } = null!;

    public string _276_000_ReasonableModificationGrantedAndPartiallyGrantedOnReport { get; set; } = null!;

    public string _276_000_ReasonableModificationGrantedAndPartiallyGrantedOnReportThisQuarter { get; set; } = null!;

    public string _277_000_ReasonableModificationDeniedOnReport { get; set; } = null!;

    public string _277_000_ReasonableModificationDeniedThisQuarter { get; set; } = null!;

    public string _278_000_ReasonableModificationPendingOnReport { get; set; } = null!;

    public string? _337_000_ApplicantOrTenant_RALog { get; set; }

    public string _338_000_DoTheyNeedAnAccessibleUnit_RALog { get; set; } = null!;

    public string? _339_000_RequestedUnitSizeBed_RALog { get; set; }

    public string? _339_100_RequestedUnitSizeBathroom_RALog { get; set; }

    public string? _340_000_RA_Or_RM_Request_RALog { get; set; }

    public string _341_000_DeterminationStatusPartiallyGranted_RALog { get; set; } = null!;

    public string _342_000_DateOfDetermination_RALog { get; set; } = null!;

    public string _343_000_DateOfAnticipatedImplementation_RALog { get; set; } = null!;

    public string _344_000_DateOfImplementation_RALog { get; set; } = null!;

    public string _345_000_DateOfGrievance_RALog { get; set; } = null!;

    public string _346_000_CorrespondingGrievanceNumber_RALog { get; set; } = null!;

    public string _047_110_Sub_Category___Install_New_Feature___Unit { get; set; } = null!;

    public string _047_120_Sub_Category___Modify_Existing_Feature___Unit { get; set; } = null!;

    public string _047_130_Sub_Category___Install_New_Feature___Common_Area { get; set; } = null!;

    public string _047_140_Sub_Category___Modify_Existing_Feature___Common_Area { get; set; } = null!;

    public string _047_150_Sub_Category___Other { get; set; } = null!;

    public string? _047_200_Describe_reasonable_modification_request { get; set; }

    public string? _047_300_Type_of_reasonable_accommodation { get; set; }

    public string _047_301_Sub_Category___Rent { get; set; } = null!;

    public string _047_302_Sub_Category___Alternate_Tenant_Contacts { get; set; } = null!;

    public string _047_303_Sub_Category___Document_Submission_Requirements { get; set; } = null!;

    public string _047_304_Sub_Category___Unit_Transfer { get; set; } = null!;

    public string _047_305_Sub_Category___In_Home_Support { get; set; } = null!;

    public string _047_306_Sub_Category___Accessibility_Requests___Common_Areas { get; set; } = null!;

    public string _047_307_Sub_Category___Tenant_Notices { get; set; } = null!;

    public string _047_308_Sub_Category___Accessibility_Requests___Unit { get; set; } = null!;

    public string _047_309_Sub_Category___Applications_and_Lottery { get; set; } = null!;

    public string _047_310_Sub_Category___Support_Animals { get; set; } = null!;

    public string _047_311_Sub_Category___Other { get; set; } = null!;

    public string? _047_400_Describe_reasonable_accomadation_request { get; set; }

    public DateOnly? _341_100_DateOfWithdrawal { get; set; }

    public string _341_200_ReasonForWithdrawal { get; set; } = null!;

    public string _342_100_ExplanationOfDetermination { get; set; } = null!;

    public string _343_100_ReasonForDelay { get; set; } = null!;

    public string _344_100_AnyAdditionalImplementationInformation { get; set; } = null!;

    public string _344_200_NotificationDates { get; set; } = null!;

    public string _1093_000_RequestorFirstName { get; set; } = null!;

    public string _1094_000_RequestorMiddleName { get; set; } = null!;

    public string _1095_000_RequestorLastName { get; set; } = null!;

    public string? _1096_000_TenantsCurrentUnitAddress { get; set; }

    public string _1097_000_TenantsCurrentUnitNumber { get; set; } = null!;

    public bool _1098_000_IsOnAUTransferList { get; set; }

    public string? _1099_000_ApplicantsCurrentAddress { get; set; }

    public bool _1100_000_IsOnAUWaitList { get; set; }

    public bool _1104_000_IsAdditionalInfoReq { get; set; }

    public DateOnly? _1105_000_DateForAdditionalInfo { get; set; }

    public string _1106_000_ReasonForAddVerification { get; set; } = null!;

    public DateOnly? _1107_000_DateForResponse { get; set; }

    public string _1108_000_ReasonForDelay { get; set; } = null!;
}
