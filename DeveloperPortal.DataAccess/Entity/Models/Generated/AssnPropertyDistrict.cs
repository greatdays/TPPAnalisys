using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPropertyDistrict
{
    public int PropSnapshotID { get; set; }

    public int LutPropertyDistrictID { get; set; }

    public virtual PropSnapshot PropSnapshot { get; set; } = null!;
}
