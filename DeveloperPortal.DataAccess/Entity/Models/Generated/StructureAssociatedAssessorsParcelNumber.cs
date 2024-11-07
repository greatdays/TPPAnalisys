using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class StructureAssociatedAssessorsParcelNumber
{
    public int Id { get; set; }

    public string APNNumber { get; set; } = null!;

    public int PropSnapshotID { get; set; }

    public bool? isDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }
}
