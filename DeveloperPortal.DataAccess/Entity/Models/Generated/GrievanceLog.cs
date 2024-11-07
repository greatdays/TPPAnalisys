using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class GrievanceLog
{
    public int GrievanceLogID { get; set; }

    public string? GrievanceLogNumber { get; set; }

    public int? ProjSitePropSnapShotID { get; set; }

    public bool IsReasonableAccommodation { get; set; }

    public bool IsEffectiveCommunication { get; set; }

    public bool IsFairHousingComplaint { get; set; }

    public int LutUserTypeID { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? ApplicantAddress { get; set; }

    public int? UnitProjectSiteID { get; set; }

    public int? UnitPropSnapShotID { get; set; }

    public DateTime? GrievanceDate { get; set; }

    public string? GrievanceDetail { get; set; }

    public int? LutGrievanceStatusID { get; set; }

    public string? PropertyAction { get; set; }

    public DateTime? DeterminationDate { get; set; }

    public int? LutDeterminationStatusID { get; set; }

    public int? LutDevelopmentCategoryID { get; set; }

    public string? DeterminationDetail { get; set; }

    public DateTime? AnticipatedDate { get; set; }

    public DateTime? ImplementationDate { get; set; }

    public string? ImplementationInformation { get; set; }

    public bool IsFairHousingComplaintFiled { get; set; }

    public bool IsHUDCompliantFiled { get; set; }

    public bool IsHCIDLACompliantFiled { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? PendingStatusDescription { get; set; }

    public bool? IsRecordsRequested { get; set; }

    public DateTime? RecordsRequestDate { get; set; }

    public bool? IsRecordsProvided { get; set; }

    public DateTime? RecordsProvidedDate { get; set; }

    public bool? IsMeetingRequested { get; set; }

    public DateTime? MeetingRequestDate { get; set; }

    public bool? IsMeetingScheduled { get; set; }

    public DateTime? MeetingScheduledDate { get; set; }

    public string? MeetingManagerName { get; set; }

    public string? MeetingManagerTitle { get; set; }

    public bool? IsAssistanceProvided { get; set; }

    public bool? IsDecisionReceived { get; set; }

    public bool? IsDecisionPending { get; set; }

    public DateTime? DecisionPendingDate { get; set; }

    public string? ImplementationDelayReason { get; set; }

    public bool? IsDecisionProvided { get; set; }

    public DateTime? DecisionProvidedDate { get; set; }

    public string? FinalDeterminationName { get; set; }

    public int? LutFinalDeterminationTitleID { get; set; }

    public string? FinalDeterminationTitleOther { get; set; }

    public string? FinalDeterminationPhone { get; set; }

    public DateTime? WithdrawalDate { get; set; }

    public string? WithdrawalReason { get; set; }

    public int? LutGrievanceSubmitTypeID { get; set; }

    public virtual ICollection<AssnGrievanceTypeQuestion> AssnGrievanceTypeQuestions { get; set; } = new List<AssnGrievanceTypeQuestion>();

    public virtual ICollection<AssnGrievanceTypeSubQuestion> AssnGrievanceTypeSubQuestions { get; set; } = new List<AssnGrievanceTypeSubQuestion>();

    public virtual LutGrievanceDeterminationStatus? LutDeterminationStatus { get; set; }

    public virtual LutDevelopmentCategory? LutDevelopmentCategory { get; set; }

    public virtual LutGrievanceDeterminationTitle? LutFinalDeterminationTitle { get; set; }

    public virtual LutGrievanceStatus? LutGrievanceStatus { get; set; }

    public virtual LutGrievanceSubmitType? LutGrievanceSubmitType { get; set; }

    public virtual LutUserType LutUserType { get; set; } = null!;

    public virtual PropSnapshot? ProjSitePropSnapShot { get; set; }

    public virtual ICollection<QRAssnGrievanceTypeQuestion> QRAssnGrievanceTypeQuestions { get; set; } = new List<QRAssnGrievanceTypeQuestion>();

    public virtual ICollection<QRAssnGrievanceTypeSubQuestion> QRAssnGrievanceTypeSubQuestions { get; set; } = new List<QRAssnGrievanceTypeSubQuestion>();

    public virtual ProjectSite? UnitProjectSite { get; set; }

    public virtual PropSnapshot? UnitPropSnapShot { get; set; }
}
