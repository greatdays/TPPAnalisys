using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// AcHP course for training
/// </summary>
public partial class Course
{
    /// <summary>
    /// Primary Key Identity column for the Course table
    /// </summary>
    public int CourseID { get; set; }

    /// <summary>
    /// an unquie code for the course
    /// </summary>
    public string CourseCode { get; set; } = null!;

    /// <summary>
    /// Course Name
    /// </summary>
    public string CourseName { get; set; } = null!;

    /// <summary>
    /// The detail about the course
    /// </summary>
    public string CourseDetail { get; set; } = null!;

    /// <summary>
    /// From inital design , do not use.
    /// </summary>
    public int LutAudienceCD { get; set; }

    /// <summary>
    /// Course start provide since
    /// </summary>
    public DateTime StartActiveDate { get; set; }

    /// <summary>
    /// the date retire the course
    /// </summary>
    public DateTime? EndActiveDate { get; set; }

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
    public Guid RowID { get; set; }

    public bool? IsRequiresLinkedProperties { get; set; }

    public int? LutCourseTypeID { get; set; }

    public bool? IsNoCertificateExpiration { get; set; }

    public virtual ICollection<AssnCoursePrerequisiteCourse> AssnCoursePrerequisiteCourseCourses { get; set; } = new List<AssnCoursePrerequisiteCourse>();

    public virtual ICollection<AssnCoursePrerequisiteCourse> AssnCoursePrerequisiteCoursePrerequisiteCourses { get; set; } = new List<AssnCoursePrerequisiteCourse>();

    public virtual LutCourseType? LutCourseType { get; set; }

    public virtual ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();
}
