using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Lupbldg
{
    public long Apn { get; set; }

    public int BldgSeqNbr { get; set; }

    public bool FlgDeleted { get; set; }

    public short? BuiltYr { get; set; }

    public string? BldgSubPartNbr { get; set; }

    public string? BldgDsgnTypCd { get; set; }

    public string? BldgClassShpTxt { get; set; }

    public short? UnitCnt { get; set; }

    public short? BathCnt { get; set; }

    public short? BedrmCnt { get; set; }

    public int? SqareFeet { get; set; }

    public short? BldgChgYr { get; set; }

    public int? UnitCostMainAmt { get; set; }

    public int? RcnMainAmt { get; set; }

    public string? LupSysUserId { get; set; }

    public DateTime? LupTimestmp { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public byte[] Timestamp { get; set; } = null!;

    public Guid RowId { get; set; }
}
