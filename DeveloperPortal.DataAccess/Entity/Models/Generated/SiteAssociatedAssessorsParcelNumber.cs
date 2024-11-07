using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SiteAssociatedAssessorsParcelNumber
{
    public int Id { get; set; }

    public string? APNNumber { get; set; }

    public bool? IsHIMS { get; set; }

    public bool? IsAcHP { get; set; }

    public int SiteID { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public int? PropSnapshotID { get; set; }

    public bool? isDeleted { get; set; }
}
