using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Training Session
/// </summary>
public partial class TrainingSession
{
    /// <summary>
    /// Primary Key Identity column for the TrainingSession table
    /// </summary>
    public int TrainingSessionId { get; set; }

    /// <summary>
    /// Course for the training session
    /// </summary>
    public int CourseId { get; set; }

    /// <summary>
    /// human readable code for the training session
    /// </summary>
    public string TrainingCode { get; set; } = null!;

    /// <summary>
    /// location hosted the training
    /// </summary>
    public string TrainingLocation { get; set; } = null!;

    /// <summary>
    /// schedule date and time for the training session
    /// </summary>
    public DateTime? ScheduleDate { get; set; }

    /// <summary>
    /// Duration for the training session
    /// </summary>
    public double Duration { get; set; }

    /// <summary>
    /// Start enrollment date
    /// </summary>
    public DateTime? StartEnrollDate { get; set; }

    /// <summary>
    /// End enrollment date
    /// </summary>
    public DateTime? EndEnrollDate { get; set; }

    /// <summary>
    /// max capacity for the training session
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// status for the training session
    /// </summary>
    public int LutTrainingSessionStatusId { get; set; }

    /// <summary>
    /// 1 = reserve for private
    /// </summary>
    public bool IsPrivate { get; set; }

    /// <summary>
    /// internal comment
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// additional information related to the training session
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// 1 = the training session mark as deleted in system.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Created by date
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Created by Who
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Last modifed date
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Last modified by
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Unique ID in System
    /// </summary>
    public Guid RowId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual LutTrainingSessionStatus LutTrainingSessionStatus { get; set; } = null!;

    public virtual ICollection<TrainingRegistry> TrainingRegistries { get; set; } = new List<TrainingRegistry>();
}
