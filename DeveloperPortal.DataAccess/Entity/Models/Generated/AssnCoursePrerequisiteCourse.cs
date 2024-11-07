using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnCoursePrerequisiteCourse
{
    public int AssnCourseCourseID { get; set; }

    public int CourseID { get; set; }

    public int PrerequisiteCourseID { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Course PrerequisiteCourse { get; set; } = null!;
}
