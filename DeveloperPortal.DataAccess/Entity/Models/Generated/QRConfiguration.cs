using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QRConfiguration
{
    public int QRConfigurationID { get; set; }

    public string? QRCode { get; set; }

    public int? QuarterStartDay { get; set; }

    public int? QuarterStartMonth { get; set; }

    public int? QuarterEndDay { get; set; }

    public int? QuarterEndMonth { get; set; }

    public int? QRSubmitStartDay { get; set; }

    public int? QRSubmitStartMonth { get; set; }

    public int? QRSubmitEndDay { get; set; }

    public int? QRSubmitEndMonth { get; set; }

    public int? QRStaffSubmitEndDay { get; set; }

    public int? QRStaffSubmitEndMonth { get; set; }

    public int? QRSoftSubmitDay { get; set; }

    public int? QRSoftSubmitMonth { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
