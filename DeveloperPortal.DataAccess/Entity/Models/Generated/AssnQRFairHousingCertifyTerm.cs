using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnQrfairHousingCertifyTerm
{
    public int AssnQrfairHousingCertifyTermsId { get; set; }

    public int QrfairHousingId { get; set; }

    public int LutQrcertifyTermsId { get; set; }

    public bool IsAccepted { get; set; }

    public virtual LutQrcertifyTerm LutQrcertifyTerms { get; set; } = null!;

    public virtual QrfairHousing QrfairHousing { get; set; } = null!;
}
