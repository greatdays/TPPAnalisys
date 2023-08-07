using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Notice
{
    public int NoticeId { get; set; }

    public int LutNoticeTypeId { get; set; }

    public int? ContactIdentifierId { get; set; }

    public string? ServiceTrackingId { get; set; }

    public int ComplianceDays { get; set; }

    public string? MailTrackingNumber { get; set; }

    public string? RecipientName { get; set; }

    public string? MailAddressLine1 { get; set; }

    public string? MailAddressLine2 { get; set; }

    public DateTime? DatePrepared { get; set; }

    public DateTime? DatePrinted { get; set; }

    public DateTime? DateMailed { get; set; }

    public DateTime? DateComplianceDue { get; set; }

    public string? NoticeUrl { get; set; }

    public bool? IsReturned { get; set; }

    public DateTime? DateReturned { get; set; }

    public bool? IsRescind { get; set; }

    public DateTime? DateRescind { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ContactIdentifier? ContactIdentifier { get; set; }

    public virtual LutNoticeType LutNoticeType { get; set; } = null!;

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();
}
