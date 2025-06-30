using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SiteAssociatedAssessorsParcelNumber
{
    public int Id { get; set; }

    public string? Apnnumber { get; set; }

    public bool? IsHims { get; set; }

    public bool? IsAcHp { get; set; }

    public int SiteId { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public int? PropSnapshotId { get; set; }

    public bool? IsDeleted { get; set; }
}
