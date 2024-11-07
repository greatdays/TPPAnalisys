using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QREffectiveCommunication
{
    public int QREffectiveCommunicationID { get; set; }

    public string? EffectiveCommunicationNumber { get; set; }

    public int QuarterlyReportID { get; set; }

    public int? EffectiveCommunicationID { get; set; }

    public int LutUserTypeID { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public int? UnitProjectSiteID { get; set; }

    public int? UnitPropSnapShotID { get; set; }

    public string? Address { get; set; }

    public DateTime? RequestDate { get; set; }

    public int? LutECRequestTypeID { get; set; }

    public int? LutECTypeID { get; set; }

    public int? LutLanguageTranslationID { get; set; }

    public int? LutLanguageID { get; set; }

    public string? RequestDescription { get; set; }

    public int? LutDeterminationStatusID { get; set; }

    public DateTime? DeterminationDate { get; set; }

    public DateTime? DateOfWithdrawal { get; set; }

    public string? ReasonForWithdrawal { get; set; }

    public string? DeterminationExplaination { get; set; }

    public DateTime? AnticipatedImplementationDate { get; set; }

    public DateTime? ImplementationDate { get; set; }

    public string? ReasonForImplementDelay { get; set; }

    public string? ImplementationInfo { get; set; }

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

    public virtual EffectiveCommunication? EffectiveCommunication { get; set; }

    public virtual LutDeterminationStatus? LutDeterminationStatus { get; set; }

    public virtual LutECRequestType? LutECRequestType { get; set; }

    public virtual LutECType? LutECType { get; set; }

    public virtual LutLanguage? LutLanguage { get; set; }

    public virtual LutLanguageTranslation? LutLanguageTranslation { get; set; }

    public virtual LutUserType LutUserType { get; set; } = null!;

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;

    public virtual ProjectSite? UnitProjectSite { get; set; }

    public virtual PropSnapshot? UnitPropSnapShot { get; set; }
}
