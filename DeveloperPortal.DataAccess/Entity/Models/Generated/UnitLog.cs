using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class UnitLog
{
    public int UnitLogID { get; set; }

    public int? UnitID { get; set; }

    public int? RefUnitID { get; set; }

    public int? SiteAddressID { get; set; }

    public int? APNID { get; set; }

    public int? BuildingID { get; set; }

    public int? LevelID { get; set; }

    public int? ProjectID { get; set; }

    public int? ProjectSiteID { get; set; }

    public string? UnitNum { get; set; }

    public string? Status { get; set; }

    public string? ServiceTrackingID { get; set; }

    public int? LutUnitAccessibiltyTypeID { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Attributes { get; set; }

    public string? Source { get; set; }
}
