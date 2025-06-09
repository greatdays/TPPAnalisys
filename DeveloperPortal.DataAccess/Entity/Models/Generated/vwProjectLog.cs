using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwProjectLog
{
    public string? FileNumber { get; set; }

    public int? PsProjectId { get; set; }

    public string? PsFileNumber { get; set; }

    public string? PsHimsnumber { get; set; }

    public string? PsPrimaryApn { get; set; }

    public string? PsSiteAddress { get; set; }

    public int ProjectId { get; set; }

    public int RefProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? LutProjSourceCd { get; set; }

    public int? LutProjectFundId { get; set; }

    public int? LutTypeofProjectId { get; set; }

    public string? FileGroup { get; set; }

    public string? SettlementAddress { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public string? YearStart { get; set; }

    public string? YearEnd { get; set; }

    public string? Source { get; set; }

    public int? SourceRefId { get; set; }

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

    public int ProjectLogId { get; set; }
}
