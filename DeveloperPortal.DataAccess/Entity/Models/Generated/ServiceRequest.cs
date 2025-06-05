using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Service Request table.
/// </summary>
public partial class ServiceRequest
{
    public long ServiceRequestId { get; set; }

    public int CaseId { get; set; }

    public int LutServiceRequestTypeId { get; set; }

    public string? ServiceRequestNumber { get; set; }

    public string? ServiceTrackingId { get; set; }

    public int? LutComplianceStatusId { get; set; }

    public int? LutInspectionStatusId { get; set; }

    public bool? IsLocked { get; set; }

    public long? RefServiceRequest { get; set; }

    public string? Attributes { get; set; }

    public string? ServiceRequestComments { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? LutProgramCycleId { get; set; }

    public virtual ICollection<AssnSrcapchecklistItemStatus> AssnSrcapchecklistItemStatuses { get; set; } = new List<AssnSrcapchecklistItemStatus>();

    public virtual ICollection<AssnSrreviewReportItemStatus> AssnSrreviewReportItemStatuses { get; set; } = new List<AssnSrreviewReportItemStatus>();

    public virtual ICollection<AuditVisitDetail> AuditVisitDetails { get; set; } = new List<AuditVisitDetail>();

    public virtual ICollection<BackgroundCheck> BackgroundChecks { get; set; } = new List<BackgroundCheck>();

    public virtual ICollection<BidPackage> BidPackageBidPackageServiceRequests { get; set; } = new List<BidPackage>();

    public virtual ICollection<BidPackage> BidPackageSiteCaseServiceRequests { get; set; } = new List<BidPackage>();

    public virtual ICollection<Capdetail> Capdetails { get; set; } = new List<Capdetail>();

    public virtual ICollection<Capextension> Capextensions { get; set; } = new List<Capextension>();

    public virtual Case Case { get; set; } = null!;

    public virtual ICollection<Ccdetail> Ccdetails { get; set; } = new List<Ccdetail>();

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<CorrectionNote> CorrectionNotes { get; set; } = new List<CorrectionNote>();

    public virtual ICollection<DrawRequest> DrawRequests { get; set; } = new List<DrawRequest>();

    public virtual ICollection<EnforcementOrderReviewDetail> EnforcementOrderReviewDetails { get; set; } = new List<EnforcementOrderReviewDetail>();

    public virtual ICollection<Extension> Extensions { get; set; } = new List<Extension>();

    public virtual ICollection<Hrmapplication> Hrmapplications { get; set; } = new List<Hrmapplication>();

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

    public virtual ICollection<Pmp> Pmps { get; set; } = new List<Pmp>();

    public virtual ICollection<Pmpsnap> Pmpsnaps { get; set; } = new List<Pmpsnap>();

    public virtual ICollection<PolicyComplianceDetail> PolicyComplianceDetails { get; set; } = new List<PolicyComplianceDetail>();

    public virtual ICollection<PolicyComplianceReminder> PolicyComplianceReminders { get; set; } = new List<PolicyComplianceReminder>();

    public virtual ICollection<QuarterlyReport> QuarterlyReports { get; set; } = new List<QuarterlyReport>();

    public virtual ServiceRequest? RefServiceRequestNavigation { get; set; }

    public virtual ICollection<ReviewReportDetail> ReviewReportDetails { get; set; } = new List<ReviewReportDetail>();

    public virtual ICollection<ServiceRequestContact> ServiceRequestContacts { get; set; } = new List<ServiceRequestContact>();

    public virtual ICollection<ServiceRequestGmcheckList> ServiceRequestGmcheckLists { get; set; } = new List<ServiceRequestGmcheckList>();

    public virtual ICollection<SurveyReport> SurveyReports { get; set; } = new List<SurveyReport>();

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();

    public virtual ICollection<WorkExtension> WorkExtensions { get; set; } = new List<WorkExtension>();

    public virtual ICollection<WorkLog> WorkLogs { get; set; } = new List<WorkLog>();

    public virtual ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();

    public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();
}
