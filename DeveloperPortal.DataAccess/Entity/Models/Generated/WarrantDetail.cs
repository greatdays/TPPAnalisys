using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WarrantDetail
{
    public int WarrantDetailId { get; set; }

    public int? InspectionId { get; set; }

    public DateTime? WarrantRequestedOn { get; set; }

    public string? ContactName { get; set; }

    public int? ReminderDays { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Inspection? Inspection { get; set; }
}
