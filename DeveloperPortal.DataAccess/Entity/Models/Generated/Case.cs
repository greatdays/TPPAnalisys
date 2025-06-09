using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Table holds cases.
/// </summary>
public partial class Case
{
    /// <summary>
    /// Primary key of the table
    /// </summary>
    public int CaseId { get; set; }

    /// <summary>
    /// Case Type Id
    /// </summary>
    public int CaseTypeId { get; set; }

    /// <summary>
    /// WorkLog Summary
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// WorkLog Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// User ID from IDM.
    /// </summary>
    public string? AssigneeId { get; set; }

    /// <summary>
    /// User ID from IDM.
    /// </summary>
    public string? AssigneeName { get; set; }

    /// <summary>
    /// Created By
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Created On
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Modified By
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified On
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    public int? CaseNumber { get; set; }

    public int? Priority { get; set; }

    public DateOnly? StatusModifiedOn { get; set; }

    public int? MaxStatusDays { get; set; }

    public bool? IsTask { get; set; }

    public bool IsAuto { get; set; }

    public DateTime? AutoStautsModifiedOn { get; set; }

    public int? AutoMaxStatusDays { get; set; }

    public string? AutoNextAction { get; set; }

    public int? DueDays { get; set; }

    public int? AutoRemainingDays { get; set; }

    public virtual ICollection<AcHppropertyManagementPlan> AcHppropertyManagementPlans { get; set; } = new List<AcHppropertyManagementPlan>();

    public virtual ICollection<AssnProblemCase> AssnProblemCases { get; set; } = new List<AssnProblemCase>();

    public virtual ICollection<AssnUserFavouriteCase> AssnUserFavouriteCases { get; set; } = new List<AssnUserFavouriteCase>();

    public virtual ICollection<AuditVisitDetail> AuditVisitDetails { get; set; } = new List<AuditVisitDetail>();

    public virtual ICollection<CaseLog> CaseLogs { get; set; } = new List<CaseLog>();

    public virtual CaseType CaseType { get; set; } = null!;

    public virtual ICollection<CaseWatcher> CaseWatchers { get; set; } = new List<CaseWatcher>();

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<DocumentEntity> DocumentEntities { get; set; } = new List<DocumentEntity>();

    public virtual ICollection<EnforcementMilestone> EnforcementMilestones { get; set; } = new List<EnforcementMilestone>();

    public virtual ICollection<InspectionScheduled> InspectionScheduleds { get; set; } = new List<InspectionScheduled>();

    public virtual ICollection<PolicyComplianceDetail> PolicyComplianceDetails { get; set; } = new List<PolicyComplianceDetail>();

    public virtual ICollection<ReviewPmplogSnap> ReviewPmplogSnaps { get; set; } = new List<ReviewPmplogSnap>();

    public virtual ICollection<ReviewPmplog> ReviewPmplogs { get; set; } = new List<ReviewPmplog>();

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();

    public virtual ICollection<TrainingRegistry> TrainingRegistries { get; set; } = new List<TrainingRegistry>();

    public virtual ICollection<CaseComment> Comments { get; set; } = new List<CaseComment>();
}
