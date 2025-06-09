using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapQrupcomingUnitVacancy
{
    public string YearQr { get; set; } = null!;

    public string? MaxYearQr { get; set; }

    public int QuarterlyReportId { get; set; }

    public int? MaxQrId { get; set; }

    public int? ProjectId { get; set; }

    public int PropertyId { get; set; }

    public int QrupcomingUnitVacancyId { get; set; }

    public int? UnitPropSnapShotId { get; set; }

    public string? FileNumber { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyName { get; set; }

    public DateTime QrreportCreateDate { get; set; }

    public bool _1110000IsUnitBecomeVacant { get; set; }

    public string? _1111000UnitNum { get; set; }

    public bool? _1111100IsQualifiedAutl { get; set; }

    public int? _1111200CurrentUnitPropSnapShotIdForQualifiedAutl { get; set; }

    public string? _1111300IsQualifiedAutlifNo { get; set; }

    public bool? _1111400IsQualifiedAuwl { get; set; }

    public string? _1111500Auwlno { get; set; }

    public bool? _1111600IsQualifiedNonPwdinAu { get; set; }

    public int? _1111700CurrentUnitNumForQualifiedNonPwdinAu { get; set; }

    public string? _1111800IsQualifiedNonPwdinAuifNo { get; set; }

    public DateOnly? _1112000NoticeDate { get; set; }

    public DateOnly? _1113000ExpectedVacancyDate { get; set; }

    public DateOnly? _1114000ActualVacancyDate { get; set; }
}
