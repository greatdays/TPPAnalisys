using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// Lookup table for training session status
/// </summary>
public partial class LutTrainingSessionStatus
{
    /// <summary>
    /// Primary Key Identity column for the LutTrainingSessionStatus table
    /// </summary>
    public int LutTrainingSessionStatusId { get; set; }

    /// <summary>
    /// Training session status
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// 1 = the course mark as deleted in system.
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
    /// Last Modifed date
    /// </summary>
    public DateTime ModifiedOn { get; set; }

    /// <summary>
    /// Last modified by
    /// </summary>
    public string ModifiedBy { get; set; } = null!;

    /// <summary>
    /// Unique ID in System
    /// </summary>
    public Guid RowId { get; set; }

    public virtual ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();
}
