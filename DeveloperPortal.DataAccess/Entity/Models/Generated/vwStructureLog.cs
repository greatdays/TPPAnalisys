using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwStructureLog
{
    public string? FileNumber { get; set; }

    public string? FileGroup { get; set; }

    public int? PS_ProjectId { get; set; }

    public int StructureLogID { get; set; }

    public int? StructureID { get; set; }

    public int? RefBuildingID { get; set; }

    public int APNID { get; set; }

    public int? LutStructureTypeID { get; set; }

    public string? Description { get; set; }

    public DateTime? DateBuilt { get; set; }

    public DateTime? DateDemolished { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Long { get; set; }

    public bool IsReviewRequired { get; set; }

    public string? Source { get; set; }

    public string? SourceRefID { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public bool IsDeleted { get; set; }

    public string? StructureNo { get; set; }

    public string? Label { get; set; }

    public string? ServiceTrackingID { get; set; }

    public int? TotalUnits { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? BuildingFileNumber { get; set; }
}
