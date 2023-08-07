using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class StructureUnitInformation
{
    public int Id { get; set; }

    public int? Total { get; set; }

    public int PropSnapshotId { get; set; }

    public int ProjectId { get; set; }

    public int ProjectSiteId { get; set; }

    public int StructureId { get; set; }

    public int LutunitType { get; set; }

    public int LuttotalBedroomId { get; set; }

    public bool? IsDeleted { get; set; }
}
