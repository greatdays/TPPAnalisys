using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_QRUpcomingUnitVacancy
{
    public string YearQR { get; set; } = null!;

    public string? MaxYearQR { get; set; }

    public int QuarterlyReportID { get; set; }

    public int? MaxQrID { get; set; }

    public int? ProjectID { get; set; }

    public int PropertyID { get; set; }

    public int QRUpcomingUnitVacancyID { get; set; }

    public int? UnitPropSnapShotID { get; set; }

    public string? FileNumber { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyName { get; set; }

    public DateTime QRReportCreateDate { get; set; }

    public bool _1110_000_IsUnitBecomeVacant { get; set; }

    public string? _1111_000_UnitNum { get; set; }

    public bool? _1111_100_IsQualifiedAUTL { get; set; }

    public int? _1111_200_CurrentUnitPropSnapShotID_ForQualifiedAUTL { get; set; }

    public string? _1111_300_IsQualifiedAUTLIfNo { get; set; }

    public bool? _1111_400_IsQualifiedAUWL { get; set; }

    public string? _1111_500_AUWLNo { get; set; }

    public bool? _1111_600_IsQualifiedNonPWDInAU { get; set; }

    public int? _1111_700_CurrentUnitNum_ForQualifiedNonPWDInAU { get; set; }

    public string? _1111_800_IsQualifiedNonPWDInAUIfNo { get; set; }

    public DateOnly? _1112_000_NoticeDate { get; set; }

    public DateOnly? _1113_000_ExpectedVacancyDate { get; set; }

    public DateOnly? _1114_000_ActualVacancyDate { get; set; }
}
