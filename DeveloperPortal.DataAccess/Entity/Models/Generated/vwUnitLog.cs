using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwUnitLog
{
    public int? PsProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? PsFileNumber { get; set; }

    public string? PsHimsnumber { get; set; }

    public string? PsPrimaryApn { get; set; }

    public string? PsSiteAddress { get; set; }

    public int UnitLogId { get; set; }

    public int? UnitId { get; set; }

    public int? RefUnitId { get; set; }

    public int? SiteAddressId { get; set; }

    public int? Apnid { get; set; }

    public int? BuildingId { get; set; }

    public int? LevelId { get; set; }

    public int? ProjectId { get; set; }

    public int? ProjectSiteId { get; set; }

    public string UnitNum { get; set; } = null!;

    public string? Status { get; set; }

    public string? ServiceTrackingId { get; set; }

    public int? LutUnitAccessibiltyTypeId { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Attributes { get; set; }

    public string? Source { get; set; }
}
