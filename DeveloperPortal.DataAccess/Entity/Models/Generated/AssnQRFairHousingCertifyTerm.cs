using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnQRFairHousingCertifyTerm
{
    public int AssnQRFairHousingCertifyTermsID { get; set; }

    public int QRFairHousingID { get; set; }

    public int LutQRCertifyTermsID { get; set; }

    public bool IsAccepted { get; set; }

    public virtual LutQRCertifyTerm LutQRCertifyTerms { get; set; } = null!;

    public virtual QRFairHousing QRFairHousing { get; set; } = null!;
}
