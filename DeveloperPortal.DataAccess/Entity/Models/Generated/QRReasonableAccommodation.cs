using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QRReasonableAccommodation
{
    public int QRReasonableAccommodationID { get; set; }

    public int? ReasonableAccommodationID { get; set; }

    public string? ReasonableAccommodationNumber { get; set; }

    public int QuarterlyReportID { get; set; }

    public int LutUserTypeID { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public int? UnitProjectSiteID { get; set; }

    public int? UnitPropSnapShotID { get; set; }

    public string? Address { get; set; }

    public DateTime? RequestDate { get; set; }

    public bool? IsTransferRequest { get; set; }

    public bool? IsNeedAUUnit { get; set; }

    public bool? IsOnAUWaitList { get; set; }

    public bool? IsOnAUTransferList { get; set; }

    public int? LutTotalBedroomsID { get; set; }

    public int? LutTotalBathroomsID { get; set; }

    public int? LutRARequestTypeID { get; set; }

    public int? LutRACategoryID { get; set; }

    public int? LutRASubCategoryID { get; set; }

    public string? RequestDescription { get; set; }

    public int? LutDeterminationStatusID { get; set; }

    public DateTime? DeterminationDate { get; set; }

    public DateTime? DateOfWithdrawal { get; set; }

    public string? ReasonForWithdrawal { get; set; }

    public string? DeterminationExplaination { get; set; }

    public bool? IsAddInfoReq { get; set; }

    public DateTime? DateForAddInfo { get; set; }

    public DateTime? DateForResponse { get; set; }

    public string? ReasonForAddVerification { get; set; }

    public DateTime? AnticipatedImplementationDate { get; set; }

    public DateTime? ImplementationDate { get; set; }

    public string? ReasonForImplementDelay { get; set; }

    public string? ReasonForDelay { get; set; }

    public string? ImplementationNotes { get; set; }

    public bool? IsGrievanceProcedureProvided { get; set; }

    public bool? IsGrievanceField { get; set; }

    public DateTime? GrievanceDate { get; set; }

    public string? GrievanceLogNumber { get; set; }

    public DateTime? NotificationDate1 { get; set; }

    public DateTime? NotificationDate2 { get; set; }

    public DateTime? NotificationDate3 { get; set; }

    public DateTime? NotificationDate4 { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutDeterminationStatus? LutDeterminationStatus { get; set; }

    public virtual LutRACategory? LutRACategory { get; set; }

    public virtual LutRARequestType? LutRARequestType { get; set; }

    public virtual LutRASubCategory? LutRASubCategory { get; set; }

    public virtual LutTotalBathroom? LutTotalBathrooms { get; set; }

    public virtual LutTotalBedroom? LutTotalBedrooms { get; set; }

    public virtual LutUserType LutUserType { get; set; } = null!;

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;

    public virtual ReasonableAccommodation? ReasonableAccommodation { get; set; }

    public virtual ProjectSite? UnitProjectSite { get; set; }

    public virtual PropSnapshot? UnitPropSnapShot { get; set; }
}
