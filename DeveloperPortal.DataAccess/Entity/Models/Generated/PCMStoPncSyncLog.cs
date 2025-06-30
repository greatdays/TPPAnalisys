using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PcmstoPncSyncLog
{
    public int SyncLogId { get; set; }

    public string IdentifierType { get; set; } = null!;

    public string IdentifierId { get; set; } = null!;

    public string? IdentifierJson { get; set; }

    public int? ProjectId { get; set; }

    public int? ProjectSiteId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
