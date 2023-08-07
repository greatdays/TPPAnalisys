using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapStructureDetail
{
    public int? ProjectSiteId { get; set; }

    public int StructurePropSnapShotId { get; set; }

    public int StructureId { get; set; }

    public DateTime? DateOf1stBuildingPermit { get; set; }

    public DateTime? DateOmostRecentBuildingPermit { get; set; }

    public DateTime? DateOfCurrentBuildingPermitNumber { get; set; }

    public DateTime? DateOf1stTco { get; set; }

    public string Elevator { get; set; } = null!;

    public int? TotalUnit { get; set; }

    public int? SrounitCnt { get; set; }

    public int? StudioUnitCnt { get; set; }

    public int? OneBrunitCnt { get; set; }

    public int? TwoBrunitCnt { get; set; }

    public int? ThreeBrunitCnt { get; set; }

    public int? FourPlusBrunitCnt { get; set; }
}
