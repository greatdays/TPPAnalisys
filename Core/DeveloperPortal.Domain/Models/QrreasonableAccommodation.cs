using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class QrreasonableAccommodation
{
    public int QrreasonableAccommodationId { get; set; }

    public int? ReasonableAccommodationId { get; set; }

    public string? ReasonableAccommodationNumber { get; set; }

    public int QuarterlyReportId { get; set; }

    public int LutUserTypeId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public int? UnitProjectSiteId { get; set; }

    public int? UnitPropSnapShotId { get; set; }

    public string? Address { get; set; }

    public DateTime? RequestDate { get; set; }

    public bool? IsTransferRequest { get; set; }

    public bool? IsNeedAuunit { get; set; }

    public bool? IsOnAuwaitList { get; set; }

    public bool? IsOnAutransferList { get; set; }

    public int? LutTotalBedroomsId { get; set; }

    public int? LutTotalBathroomsId { get; set; }

    public int? LutRarequestTypeId { get; set; }

    public int? LutRacategoryId { get; set; }

    public int? LutRasubCategoryId { get; set; }

    public string? RequestDescription { get; set; }

    public int? LutDeterminationStatusId { get; set; }

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

    public virtual LutRacategory? LutRacategory { get; set; }

    public virtual LutRarequestType? LutRarequestType { get; set; }

    public virtual LutRasubCategory? LutRasubCategory { get; set; }

    public virtual LutTotalBathroom? LutTotalBathrooms { get; set; }

    public virtual LutTotalBedroom? LutTotalBedrooms { get; set; }

    public virtual LutUserType LutUserType { get; set; } = null!;

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;

    public virtual ReasonableAccommodation? ReasonableAccommodation { get; set; }

    public virtual ProjectSite? UnitProjectSite { get; set; }

    public virtual PropSnapshot? UnitPropSnapShot { get; set; }
}
