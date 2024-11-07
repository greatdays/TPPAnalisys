using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Service Request table.
/// </summary>
public partial class ServiceRequest
{
    public long ServiceRequestID { get; set; }

    public int CaseID { get; set; }

    public int LutServiceRequestTypeID { get; set; }

    public string? ServiceRequestNumber { get; set; }

    public string? ServiceTrackingID { get; set; }

    public int? LutComplianceStatusID { get; set; }

    public int? LutInspectionStatusID { get; set; }

    public bool? IsLocked { get; set; }

    public long? RefServiceRequest { get; set; }

    public string? Attributes { get; set; }

    public string? ServiceRequestComments { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? LutProgramCycleID { get; set; }

    public virtual ICollection<AssnSRCAPChecklistItemStatus> AssnSRCAPChecklistItemStatuses { get; set; } = new List<AssnSRCAPChecklistItemStatus>();

    public virtual ICollection<AssnSRReviewReportItemStatus> AssnSRReviewReportItemStatuses { get; set; } = new List<AssnSRReviewReportItemStatus>();

    public virtual ICollection<AuditVisitDetail> AuditVisitDetails { get; set; } = new List<AuditVisitDetail>();

    public virtual ICollection<BackgroundCheck> BackgroundChecks { get; set; } = new List<BackgroundCheck>();

    public virtual ICollection<BidPackage> BidPackageBidPackageServiceRequests { get; set; } = new List<BidPackage>();

    public virtual ICollection<BidPackage> BidPackageSiteCaseServiceRequests { get; set; } = new List<BidPackage>();

    public virtual ICollection<CAPDetail> CAPDetails { get; set; } = new List<CAPDetail>();

    public virtual ICollection<CAPExtension> CAPExtensions { get; set; } = new List<CAPExtension>();

    public virtual ICollection<CCDetail> CCDetails { get; set; } = new List<CCDetail>();

    public virtual Case Case { get; set; } = null!;

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<CorrectionNote> CorrectionNotes { get; set; } = new List<CorrectionNote>();

    public virtual ICollection<DrawRequest> DrawRequests { get; set; } = new List<DrawRequest>();

    public virtual ICollection<EnforcementOrderReviewDetail> EnforcementOrderReviewDetails { get; set; } = new List<EnforcementOrderReviewDetail>();

    public virtual ICollection<Extension> Extensions { get; set; } = new List<Extension>();

    public virtual ICollection<HRMApplication> HRMApplications { get; set; } = new List<HRMApplication>();

    public virtual ICollection<ImportantDate> ImportantDates { get; set; } = new List<ImportantDate>();

    public virtual ICollection<InspectionScheduled> InspectionScheduleds { get; set; } = new List<InspectionScheduled>();

    public virtual ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();

    public virtual ICollection<ServiceRequest> InverseRefServiceRequestNavigation { get; set; } = new List<ServiceRequest>();

    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();

    public virtual LutComplianceStatus? LutComplianceStatus { get; set; }

    public virtual LutInspectionStatus? LutInspectionStatus { get; set; }

    public virtual LutProgramCycle? LutProgramCycle { get; set; }

    public virtual LutServiceRequestType LutServiceRequestType { get; set; } = null!;

    public virtual ICollection<NoticeOfObligation> NoticeOfObligations { get; set; } = new List<NoticeOfObligation>();

    public virtual ICollection<PMPSnap> PMPSnaps { get; set; } = new List<PMPSnap>();

    public virtual ICollection<PMP> PMPs { get; set; } = new List<PMP>();

    public virtual ICollection<PolicyComplianceDetail> PolicyComplianceDetails { get; set; } = new List<PolicyComplianceDetail>();

    public virtual ICollection<PolicyComplianceReminder> PolicyComplianceReminders { get; set; } = new List<PolicyComplianceReminder>();

    public virtual ICollection<QuarterlyReport> QuarterlyReports { get; set; } = new List<QuarterlyReport>();

    public virtual ServiceRequest? RefServiceRequestNavigation { get; set; }

    public virtual ICollection<ReviewReportDetail> ReviewReportDetails { get; set; } = new List<ReviewReportDetail>();

    public virtual ICollection<ServiceRequestContact> ServiceRequestContacts { get; set; } = new List<ServiceRequestContact>();

    public virtual ICollection<ServiceRequestGMCheckList> ServiceRequestGMCheckLists { get; set; } = new List<ServiceRequestGMCheckList>();

    public virtual ICollection<SurveyReport> SurveyReports { get; set; } = new List<SurveyReport>();

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();

    public virtual ICollection<WorkExtension> WorkExtensions { get; set; } = new List<WorkExtension>();

    public virtual ICollection<WorkLog> WorkLogs { get; set; } = new List<WorkLog>();

    public virtual ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();

    public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();
}
