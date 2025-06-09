using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PropSnapshotTemp
{
    public int PropSnapshotId { get; set; }

    public string IdentifierType { get; set; } = null!;

    public int? Apnid { get; set; }

    public int? ProjectId { get; set; }

    public int? ProjectSiteId { get; set; }

    public int? SiteAddressId { get; set; }

    public int? StructureId { get; set; }

    public int? LevelId { get; set; }

    public int? UnitId { get; set; }

    public int? LocationId { get; set; }

    public string? IdentifierJson { get; set; }

    public string? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
