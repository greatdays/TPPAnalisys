using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class NoticeOfObligation
{
    public int NoticeOfObligationID { get; set; }

    public long ServiceRequestID { get; set; }

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

    public string? PMFullName { get; set; }

    public string? PMEmail { get; set; }

    public string? NOBType { get; set; }

    public DateTime? SelfCertAdpotionDate { get; set; }

    public DateTime? RegulatoryAgreementExecDate { get; set; }

    public string? ToEMailIds { get; set; }

    public string? CCEMailIds { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string? OwnerCityStateZip { get; set; }

    public string? BestContact1Title { get; set; }

    public string? BestContact1FullName { get; set; }

    public string? BestContact1Company { get; set; }

    public string? BestContact1Address { get; set; }

    public string? BestContact1CityStateZip { get; set; }

    public string? BestContact1Email { get; set; }

    public string? BestContact2Title { get; set; }

    public string? BestContact2FullName { get; set; }

    public string? BestContact2Company { get; set; }

    public string? BestContact2Address { get; set; }

    public string? BestContact2CityStateZip { get; set; }

    public string? BestContact2Email { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
