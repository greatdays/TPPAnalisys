using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class FairHousing
{
    public int FairHousingId { get; set; }

    public int ProjectSitePropSnapShotId { get; set; }

    public DateTime? QrbeginDate { get; set; }

    public DateTime? QrendDate { get; set; }

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

    public DateTime? SignDate { get; set; }

    public int? LutSignatureTitleId { get; set; }

    public bool? IsAnyChangeInRole { get; set; }

    public bool? IsAwareOfAnyFhac { get; set; }

    public string? CourtName { get; set; }

    public string? Fhorganization { get; set; }

    public string? OtherFhacfiledSource { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnFairHousingCertifyTerm> AssnFairHousingCertifyTerms { get; set; } = new List<AssnFairHousingCertifyTerm>();

    public virtual ICollection<AssnFhacfiledDate> AssnFhacfiledDates { get; set; } = new List<AssnFhacfiledDate>();

    public virtual LutSignatureTitle? LutSignatureTitle { get; set; }

    public virtual PropSnapshot ProjectSitePropSnapShot { get; set; } = null!;

    public virtual ICollection<QrfairHousing> QrfairHousings { get; set; } = new List<QrfairHousing>();
}
