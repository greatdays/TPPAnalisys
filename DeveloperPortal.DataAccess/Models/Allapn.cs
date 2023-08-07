using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Allapn
{
    public long Apn { get; set; }

    public string PropDesc { get; set; } = null!;

    public string? UseCode { get; set; }

    public bool FlgDeleted { get; set; }

    public bool FlgObsolete { get; set; }

    public string? LutModReasonCd { get; set; }

    public string? LutModVerifiedCd { get; set; }

    public string? ModComment { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public byte[] Timestamp { get; set; } = null!;

    public Guid RowId { get; set; }

    public string? LutResidHotelTypeCd { get; set; }

    public bool? FlgAdaptiveReuse { get; set; }

    public bool? FlgGroundLease { get; set; }

    public int? RsoUnitCount { get; set; }

    public int? ScepUnitCount { get; set; }

    public DateTime? DateRhdetermination { get; set; }

    public DateTime? DateEllisDetermination { get; set; }

    public string? LutEllisTypeCd { get; set; }

    public short? RhtransientUnitCnt { get; set; }

    public short? RhunitCnt { get; set; }
}
