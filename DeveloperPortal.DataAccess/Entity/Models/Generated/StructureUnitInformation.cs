using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class StructureUnitInformation
{
    public int ID { get; set; }

    public int? Total { get; set; }

    public int PropSnapshotID { get; set; }

    public int ProjectId { get; set; }

    public int ProjectSiteId { get; set; }

    public int StructureId { get; set; }

    public int LUTUnitType { get; set; }

    public int LUTTotalBedroomID { get; set; }

    public bool? IsDeleted { get; set; }
}
