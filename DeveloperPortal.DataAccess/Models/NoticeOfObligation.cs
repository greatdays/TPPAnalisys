using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class NoticeOfObligation
{
    public int NoticeOfObligationId { get; set; }

    public long ServiceRequestId { get; set; }

    public DateTime NocDate { get; set; }

    public string? OwnerTitle { get; set; }

    public string? OwnerFullName { get; set; }

    public string? OwnerCompany { get; set; }

    public string? OwnerAddress { get; set; }

    public string? OwnerEmail { get; set; }

    public string? LupamTitle { get; set; }

    public string? LupamFullName { get; set; }

    public string? LupamCompany { get; set; }

    public string? LupamAddress { get; set; }

    public string? LupamEmail { get; set; }

    public string? PmfullName { get; set; }

    public string? Pmemail { get; set; }

    public string? Nobtype { get; set; }

    public DateTime? SelfCertAdpotionDate { get; set; }

    public DateTime? RegulatoryAgreementExecDate { get; set; }

    public string? ToEmailIds { get; set; }

    public string? CcemailIds { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
