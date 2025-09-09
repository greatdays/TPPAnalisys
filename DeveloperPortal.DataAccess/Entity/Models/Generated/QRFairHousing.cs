using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QrfairHousing
{
    public int QrfairHousingId { get; set; }

    public int? FairHousingId { get; set; }

    public int QuarterlyReportId { get; set; }

    public DateOnly? QrbeginDate { get; set; }

    public DateOnly? QrendDate { get; set; }

    public string? PropertyName { get; set; }

    public string? SiteAddress { get; set; }

    public string? Pmname { get; set; }

    public string? PhoneType { get; set; }

    public string? Pmphone { get; set; }

    public string? Pmemail { get; set; }

    public int? TotalFullyAccessibleMobilityUnit { get; set; }

    public int? TotalFullyAccessibleHvunit { get; set; }

    public int? TotalVacantAuthisQuarter { get; set; }

    public int? TotalTenantsOccupiedAuwithoutNeed { get; set; }

    public string? LegalOwnerName { get; set; }

    public string? OwnerAddress { get; set; }

    public string? OwnerPhone { get; set; }

    public string? OwnerEmail { get; set; }

    public string? SignerName { get; set; }

    public DateOnly? SignDate { get; set; }

    public int? LutSignatureTitleId { get; set; }

    public bool? IsAnyChangeInRole { get; set; }

    public bool? IsAnyChangeInFiveReqRoles { get; set; }

    public bool? IsOpmrequiredNewPropMgmtStaffToCreateAahraccount { get; set; }

    public DateOnly? AccountNlinkPropertyDate { get; set; }

    public bool? IsOpmrequiredNewPropMgmtStaffToAttendAnnualFh { get; set; }

    public DateOnly? TrainingAttendedDate { get; set; }

    public bool? IsAwareOfAnyFhac { get; set; }

    public string? CourtName { get; set; }

    public string? Fhorganization { get; set; }

    public string? OtherFhacfiledSource { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnQrfairHousingCertifyTerm> AssnQrfairHousingCertifyTerms { get; set; } = new List<AssnQrfairHousingCertifyTerm>();

    public virtual ICollection<AssnQrfhacfiledDate> AssnQrfhacfiledDates { get; set; } = new List<AssnQrfhacfiledDate>();

    public virtual FairHousing? FairHousing { get; set; }

    public virtual LutSignatureTitle? LutSignatureTitle { get; set; }

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;
}
