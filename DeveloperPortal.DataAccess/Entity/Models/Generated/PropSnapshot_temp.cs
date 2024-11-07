using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PropSnapshot_temp
{
    public int PropSnapshotID { get; set; }

    public string IdentifierType { get; set; } = null!;

    public int? APNID { get; set; }

    public int? ProjectID { get; set; }

    public int? ProjectSiteID { get; set; }

    public int? SiteAddressID { get; set; }

    public int? StructureID { get; set; }

    public int? LevelID { get; set; }

    public int? UnitID { get; set; }

    public int? LocationID { get; set; }

    public string? IdentifierJSON { get; set; }

    public string? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
