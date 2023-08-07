using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnPropertyDistrict
{
    public int PropSnapshotId { get; set; }

    public int LutPropertyDistrictId { get; set; }

    public virtual PropSnapshot PropSnapshot { get; set; } = null!;
}
