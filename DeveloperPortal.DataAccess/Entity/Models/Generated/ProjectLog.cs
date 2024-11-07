using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectLog
{
    public int ProjectID { get; set; }

    public int RefProjectID { get; set; }

    public string? ProjectName { get; set; }

    public string? LutProjSourceCD { get; set; }

    public int? LutProjectFundID { get; set; }

    public int? LutTypeofProjectID { get; set; }

    public string? FileGroup { get; set; }

    public string? SettlementAddress { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public string? YearStart { get; set; }

    public string? YearEnd { get; set; }

    public string? Source { get; set; }

    public int? SourceRefID { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public bool IsDeleted { get; set; }

    public short? SettlementTotalUnit { get; set; }

    public short? SettlementMobilityUnit { get; set; }

    public short? SettlementSensoryUnit { get; set; }

    public short? SettlementTotalAccessibleUnit { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int ProjectLogID { get; set; }
}
