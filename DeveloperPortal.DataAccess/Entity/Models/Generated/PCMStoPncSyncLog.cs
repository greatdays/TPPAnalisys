using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PCMStoPncSyncLog
{
    public int SyncLogID { get; set; }

    public string IdentifierType { get; set; } = null!;

    public string IdentifierID { get; set; } = null!;

    public string? IdentifierJSON { get; set; }

    public int? ProjectID { get; set; }

    public int? ProjectSiteID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
