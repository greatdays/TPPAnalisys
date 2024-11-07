using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Association table between Course and Trainer
/// who is eligible to provide training for the course
/// </summary>
public partial class AssnCourseTrainer
{
    /// <summary>
    /// Primary Key Identity column for Associate table.
    /// </summary>
    public int AssnCourseTrainerID { get; set; }

    /// <summary>
    /// FK of Course table
    /// </summary>
    public int CourseID { get; set; }

    /// <summary>
    /// FK for the Trainer table
    /// </summary>
    public int? TrainerID { get; set; }

    /// <summary>
    /// Obsolete field.  Initial design system will keep trainer under Account Profile table.
    /// </summary>
    public int AccountID { get; set; }

    /// <summary>
    /// Internal comment
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// Notes for about Trainer backgroup related the particular course
    /// </summary>
    public string? TrainerCourseBackground { get; set; }

    /// <summary>
    /// 1 = Deleted relationship between trainer and course.  Default = 0
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// when was the associate record created
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Who created associate record
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Last update date for the record
    /// </summary>
    public DateTime ModifiedOn { get; set; }

    /// <summary>
    /// Last person modified for the record
    /// </summary>
    public string ModifiedBy { get; set; } = null!;

    /// <summary>
    /// Unique row ID in system
    /// </summary>
    public Guid RowID { get; set; }

    public virtual Trainer? Trainer { get; set; }

    public virtual ICollection<TrainingSessionTrainer> TrainingSessionTrainers { get; set; } = new List<TrainingSessionTrainer>();
}
