using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectWorkLog
{
    public int WorkLogID { get; set; }

    public int? ProjectID { get; set; }

    public int? ProjectSiteID { get; set; }

    public string Reason { get; set; } = null!;

    public string? WorkLog { get; set; }

    public DateTime? ResolutionDate { get; set; }

    public string? ResolutionMessage { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowID { get; set; }

    public int LutWorkLogTypeID { get; set; }

    public int? ContactIdentifierID { get; set; }

    public int? HousingAdvocateID { get; set; }

    public virtual ContactIdentifier? ContactIdentifier { get; set; }

    public virtual Organization? HousingAdvocate { get; set; }

    public virtual LutWorkLogType LutWorkLogType { get; set; } = null!;

    public virtual Project? Project { get; set; }

    public virtual ProjectSite? ProjectSite { get; set; }
}
