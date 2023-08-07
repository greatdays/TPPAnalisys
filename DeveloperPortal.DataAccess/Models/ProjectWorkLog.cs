using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class ProjectWorkLog
{
    public int WorkLogId { get; set; }

    public int? ProjectId { get; set; }

    public int? ProjectSiteId { get; set; }

    public string Reason { get; set; } = null!;

    public string? WorkLog { get; set; }

    public DateTime? ResolutionDate { get; set; }

    public string? ResolutionMessage { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowId { get; set; }

    public int LutWorkLogTypeId { get; set; }

    public int? ContactIdentifierId { get; set; }

    public int? HousingAdvocateId { get; set; }

    public virtual ContactIdentifier? ContactIdentifier { get; set; }

    public virtual Organization? HousingAdvocate { get; set; }

    public virtual LutWorkLogType LutWorkLogType { get; set; } = null!;

    public virtual Project? Project { get; set; }

    public virtual ProjectSite? ProjectSite { get; set; }
}
