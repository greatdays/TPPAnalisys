using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class TrainingSessionTrainer
{
    public int TrainingSessionId { get; set; }

    public int AssnCourseTrainerId { get; set; }

    public double PlanDuration { get; set; }

    public double? ActualDuration { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowId { get; set; }

    public virtual AssnCourseTrainer AssnCourseTrainer { get; set; } = null!;
}
