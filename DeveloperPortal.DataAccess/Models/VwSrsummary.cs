using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwSrsummary
{
    public long ServiceRequestId { get; set; }

    public int CaseId { get; set; }

    public int CaseTypeId { get; set; }

    public string? CaseNo { get; set; }

    public string CaseType { get; set; } = null!;

    public string? Apn { get; set; }

    public string? ProjectName { get; set; }

    public int RefProjectId { get; set; }

    public int RefProjectSiteId { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Assignee { get; set; }

    public string IdentifierType { get; set; } = null!;

    public string? ProjSource { get; set; }

    public string? ProjectFund { get; set; }

    public string? TypeofProject { get; set; }

    public string? YearStart { get; set; }

    public string? AcHpfileProjectNumber { get; set; }

    public string? PrimaryApn { get; set; }

    public string? Himsnumber { get; set; }

    public string Region { get; set; } = null!;

    public string Neighborhood { get; set; } = null!;

    public string? CouncilDistrict { get; set; }

    public string? FullAddress { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
