using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapQrreasonableAccommodation
{
    public string? RarequestType { get; set; }

    public string YearQr { get; set; } = null!;

    public string? MaxYearQr { get; set; }

    public int QuarterlyReportId { get; set; }

    public int? MaxQrId { get; set; }

    public int? ProjectId { get; set; }

    public int PropertyId { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyName { get; set; }

    public int RaquarterReportId { get; set; }

    public int QrreasonableAccommodationId { get; set; }

    public int? ReasonableAccommodationId { get; set; }

    public DateTime QrreportCreateDate { get; set; }

    public string? FileNumber { get; set; }

    public string? UserType { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public int? UnitPropSnapShotId { get; set; }

    public string? UnitNum { get; set; }

    public string? RequestorAddress { get; set; }

    public DateTime? RequestDate { get; set; }

    public string IsTransferRequest { get; set; } = null!;

    public string IsNeedAuunit { get; set; } = null!;

    public string IsOnAuwaitList { get; set; } = null!;

    public string IsOnAutransferList { get; set; } = null!;

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

    public string? _047000UnitNumberSubjectToReasonableModification { get; set; }

    public string _137100DateOfRequestForReasonableAccommodationOrReasonableModification { get; set; } = null!;

    public string _270000ReasonableAccommodationRequestThisQuarter { get; set; } = null!;

    public string? _270000ReasonableAccommodationId { get; set; }

    public string _271000ReasonableAccommodationGrantedOnReport { get; set; } = null!;

    public string _271000ReasonableAccommodationGrantedThisQuarter { get; set; } = null!;

    public string _271000ReasonableAccommodationGrantedAndPartiallyGrantedOnReport { get; set; } = null!;

    public string _271000ReasonableAccommodationGrantedAndPartiallyGrantedOnReportThisQuarter { get; set; } = null!;

    public string _272000ReasonableAccommodationDeniedOnReport { get; set; } = null!;

    public string _272000ReasonableAccommodationDeniedThisQuarter { get; set; } = null!;

    public string _273000ReasonableAccommodationPendingOnReport { get; set; } = null!;

    public string _275000ReasonableModificationThisQuarter { get; set; } = null!;

    public string? _275000ReasonableModificationId { get; set; }

    public string _276000ReasonableModificationGrantedOnReport { get; set; } = null!;

    public string _276000ReasonableModificationGrantedThisQuarter { get; set; } = null!;

    public string _276000ReasonableModificationGrantedAndPartiallyGrantedOnReport { get; set; } = null!;

    public string _276000ReasonableModificationGrantedAndPartiallyGrantedOnReportThisQuarter { get; set; } = null!;

    public string _277000ReasonableModificationDeniedOnReport { get; set; } = null!;

    public string _277000ReasonableModificationDeniedThisQuarter { get; set; } = null!;

    public string _278000ReasonableModificationPendingOnReport { get; set; } = null!;

    public string? _337000ApplicantOrTenantRalog { get; set; }

    public string _338000DoTheyNeedAnAccessibleUnitRalog { get; set; } = null!;

    public string? _339000RequestedUnitSizeBedRalog { get; set; }

    public string? _339100RequestedUnitSizeBathroomRalog { get; set; }

    public string? _340000RaOrRmRequestRalog { get; set; }

    public string _341000DeterminationStatusPartiallyGrantedRalog { get; set; } = null!;

    public string _342000DateOfDeterminationRalog { get; set; } = null!;

    public string _343000DateOfAnticipatedImplementationRalog { get; set; } = null!;

    public string _344000DateOfImplementationRalog { get; set; } = null!;

    public string _345000DateOfGrievanceRalog { get; set; } = null!;

    public string _346000CorrespondingGrievanceNumberRalog { get; set; } = null!;

    public string _047110SubCategoryInstallNewFeatureUnit { get; set; } = null!;

    public string _047120SubCategoryModifyExistingFeatureUnit { get; set; } = null!;

    public string _047130SubCategoryInstallNewFeatureCommonArea { get; set; } = null!;

    public string _047140SubCategoryModifyExistingFeatureCommonArea { get; set; } = null!;

    public string _047150SubCategoryOther { get; set; } = null!;

    public string? _047200DescribeReasonableModificationRequest { get; set; }

    public string? _047300TypeOfReasonableAccommodation { get; set; }

    public string _047301SubCategoryRent { get; set; } = null!;

    public string _047302SubCategoryAlternateTenantContacts { get; set; } = null!;

    public string _047303SubCategoryDocumentSubmissionRequirements { get; set; } = null!;

    public string _047304SubCategoryUnitTransfer { get; set; } = null!;

    public string _047305SubCategoryInHomeSupport { get; set; } = null!;

    public string _047306SubCategoryAccessibilityRequestsCommonAreas { get; set; } = null!;

    public string _047307SubCategoryTenantNotices { get; set; } = null!;

    public string _047308SubCategoryAccessibilityRequestsUnit { get; set; } = null!;

    public string _047309SubCategoryApplicationsAndLottery { get; set; } = null!;

    public string _047310SubCategorySupportAnimals { get; set; } = null!;

    public string _047311SubCategoryOther { get; set; } = null!;

    public string? _047400DescribeReasonableAccomadationRequest { get; set; }

    public DateOnly? _341100DateOfWithdrawal { get; set; }

    public string _341200ReasonForWithdrawal { get; set; } = null!;

    public string _342100ExplanationOfDetermination { get; set; } = null!;

    public string _343100ReasonForDelay { get; set; } = null!;

    public string _344100AnyAdditionalImplementationInformation { get; set; } = null!;

    public string _344200NotificationDates { get; set; } = null!;

    public string _1093000RequestorFirstName { get; set; } = null!;

    public string _1094000RequestorMiddleName { get; set; } = null!;

    public string _1095000RequestorLastName { get; set; } = null!;

    public string? _1096000TenantsCurrentUnitAddress { get; set; }

    public string _1097000TenantsCurrentUnitNumber { get; set; } = null!;

    public bool _1098000IsOnAutransferList { get; set; }

    public string? _1099000ApplicantsCurrentAddress { get; set; }

    public bool _1100000IsOnAuwaitList { get; set; }

    public bool _1104000IsAdditionalInfoReq { get; set; }

    public DateOnly? _1105000DateForAdditionalInfo { get; set; }

    public string _1106000ReasonForAddVerification { get; set; } = null!;

    public DateOnly? _1107000DateForResponse { get; set; }

    public string _1108000ReasonForDelay { get; set; } = null!;
}
