using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// Training information
/// </summary>
public partial class Trainer
{
    /// <summary>
    /// Primary Key Identity column for the Trainer table
    /// </summary>
    public int TrainerId { get; set; }

    /// <summary>
    /// trainer first name
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// trainer middle name
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// trainer last name
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// trainer email addresss
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// trainer phone number
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// trainer profile, some information about the trainer
    /// </summary>
    public string? Profile { get; set; }

    /// <summary>
    /// date start work for provide training service
    /// </summary>
    public DateTime HireDate { get; set; }

    /// <summary>
    /// internal notes related to trainer
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// if 0, trainer wont be assign to train session anymore
    /// </summary>
    public bool? IsActive { get; set; }

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

    public virtual ICollection<AssnCourseTrainer> AssnCourseTrainers { get; set; } = new List<AssnCourseTrainer>();
}
