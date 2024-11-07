using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QRFairHousing
{
    public int QRFairHousingID { get; set; }

    public int? FairHousingID { get; set; }

    public int QuarterlyReportID { get; set; }

    public DateOnly? QRBeginDate { get; set; }

    public DateOnly? QREndDate { get; set; }

    public string? PropertyName { get; set; }

    public string? SiteAddress { get; set; }

    public string? PMName { get; set; }

    public string? PhoneType { get; set; }

    public string? PMPhone { get; set; }

    public string? PMEmail { get; set; }

    public int? TotalFullyAccessibleMobilityUnit { get; set; }

    public int? TotalFullyAccessibleHVUnit { get; set; }

    public int? TotalVacantAUThisQuarter { get; set; }

    public int? TotalTenantsOccupiedAUWithoutNeed { get; set; }

    public string? LegalOwnerName { get; set; }

    public string? OwnerAddress { get; set; }

    public string? OwnerPhone { get; set; }

    public string? OwnerEmail { get; set; }

    public string? SignerName { get; set; }

    public DateOnly? SignDate { get; set; }

    public int? LutSignatureTitleID { get; set; }

    public bool? IsAnyChangeInRole { get; set; }

    public bool? IsAwareOfAnyFHAC { get; set; }

    public string? CourtName { get; set; }

    public string? FHOrganization { get; set; }

    public string? OtherFHACFiledSource { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnQRFHACFiledDate> AssnQRFHACFiledDates { get; set; } = new List<AssnQRFHACFiledDate>();

    public virtual ICollection<AssnQRFairHousingCertifyTerm> AssnQRFairHousingCertifyTerms { get; set; } = new List<AssnQRFairHousingCertifyTerm>();

    public virtual FairHousing? FairHousing { get; set; }

    public virtual LutSignatureTitle? LutSignatureTitle { get; set; }

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;
}
