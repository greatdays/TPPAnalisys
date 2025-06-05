using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ReviewPmplog
{
    public int ReviewPmplogId { get; set; }

    public int? CaseId { get; set; }

    public string? Status { get; set; }

    public string? Username { get; set; }

    public string? UserFullName { get; set; }

    public string? UserEmail { get; set; }

    public bool? IsAcHpstaff { get; set; }

    public bool IsPrelimaryCertUpload { get; set; }

    public string? PrelimaryCertUploadByUserName { get; set; }

    public string? PrelimaryCertUploadByUserFullName { get; set; }

    public string? PrelimaryCertGuid { get; set; }

    public DateTime? DatePrelimaryCertificate { get; set; }

    public bool IsFinalCertUpload { get; set; }

    public string? FinalCertUploadByUserName { get; set; }

    public string? FinalCertUploadByUserFullName { get; set; }

    public string? FinalCertGuid { get; set; }

    public DateTime? DateFinalCertificate { get; set; }

    public bool IsActive { get; set; }

    public DateTime? DateAffirmativeMarketingDoc { get; set; }

    public bool? IsPreliminaryApproved { get; set; }

    public DateTime? PreliminaryApprovedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Case? Case { get; set; }
}
