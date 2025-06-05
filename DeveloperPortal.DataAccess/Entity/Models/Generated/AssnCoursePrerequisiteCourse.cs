using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnCoursePrerequisiteCourse
{
    public int AssnCourseCourseId { get; set; }

    public int CourseId { get; set; }

    public int PrerequisiteCourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Course PrerequisiteCourse { get; set; } = null!;
}
