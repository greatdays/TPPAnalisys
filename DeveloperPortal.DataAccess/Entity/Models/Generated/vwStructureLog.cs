using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwStructureLog
{
    public int ProjectId { get; set; }

    public int? PsProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? PsFileNumber { get; set; }

    public string? PsHimsnumber { get; set; }

    public string? PsPrimaryApn { get; set; }

    public string? PsSiteAddress { get; set; }

    public int StructureLogId { get; set; }

    public int? StructureId { get; set; }

    public int? RefBuildingId { get; set; }

    public int Apnid { get; set; }

    public int? LutStructureTypeId { get; set; }

    public string? Description { get; set; }

    public DateTime? DateBuilt { get; set; }

    public DateTime? DateDemolished { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Long { get; set; }

    public bool IsReviewRequired { get; set; }

    public string? Source { get; set; }

    public string? SourceRefId { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public bool IsDeleted { get; set; }

    public string StructureNo { get; set; } = null!;

    public string? Label { get; set; }

    public string? ServiceTrackingId { get; set; }

    public int? TotalUnits { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string BuildingFileNumber { get; set; } = null!;
}
