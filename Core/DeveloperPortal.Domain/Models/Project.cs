using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Project
{
    public int ProjectId { get; set; }

    public int RefProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? LutProjSourceCd { get; set; }

    public int? LutProjectFundId { get; set; }

    public int? LutTypeofProjectId { get; set; }

    public string? FileGroup { get; set; }

    public string? SettlementAddress { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

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

    public virtual ICollection<AcHppropertyManagementPlan> AcHppropertyManagementPlans { get; set; } = new List<AcHppropertyManagementPlan>();

    public virtual LutProjSource? LutProjSourceCdNavigation { get; set; }

    public virtual LutProjectFund? LutProjectFund { get; set; }

    public virtual LutTypeofProject? LutTypeofProject { get; set; }

    public virtual ICollection<ProjectSite> ProjectSites { get; set; } = new List<ProjectSite>();

    public virtual ICollection<ProjectWorkLog> ProjectWorkLogs { get; set; } = new List<ProjectWorkLog>();

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
