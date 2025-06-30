using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Qrconfiguration
{
    public int QrconfigurationId { get; set; }

    public string? Qrcode { get; set; }

    public int? QuarterStartDay { get; set; }

    public int? QuarterStartMonth { get; set; }

    public int? QuarterEndDay { get; set; }

    public int? QuarterEndMonth { get; set; }

    public int? QrsubmitStartDay { get; set; }

    public int? QrsubmitStartMonth { get; set; }

    public int? QrsubmitEndDay { get; set; }

    public int? QrsubmitEndMonth { get; set; }

    public int? QrstaffSubmitEndDay { get; set; }

    public int? QrstaffSubmitEndMonth { get; set; }

    public int? QrsoftSubmitDay { get; set; }

    public int? QrsoftSubmitMonth { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
