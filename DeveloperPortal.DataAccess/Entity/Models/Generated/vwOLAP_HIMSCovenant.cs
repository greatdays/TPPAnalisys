using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_HIMSCovenant
{
    public string? CovenantNo { get; set; }

    public string? CovenantLink { get; set; }

    public string? FullProjectNumber { get; set; }

    public int? ProjUniqueID { get; set; }

    public string? ProjName { get; set; }

    public string? ProjectCategory { get; set; }

    public string? HousingServicesProgram { get; set; }

    public string? CovRegAgreementType { get; set; }

    public string? AgreementNumber { get; set; }

    public DateTime? DateCovRegStart { get; set; }

    public int? CovRegTermYr { get; set; }

    public DateTime? DateCovRegEnd { get; set; }

    public DateTime? DateExecute { get; set; }

    public DateTime? DateRecorded { get; set; }

    public string? AssignedTo { get; set; }

    public DateTime? DateAssignedToOMMonitor { get; set; }

    public DateTime? DateFirstAssignedToContractedMonitor { get; set; }

    public DateTime? DateAdditionalRefferral { get; set; }

    public string ReportingPeriod { get; set; } = null!;

    public int? LutOMReportMonthCD { get; set; }

    public bool IsUnitFixed { get; set; }

    public bool IsUnitFloating { get; set; }

    public string? UnitComments { get; set; }

    public bool? IsMonitored { get; set; }

    public decimal? MonitoringFlatFee { get; set; }

    public string? CalculatedMonitoringFee { get; set; }
}
