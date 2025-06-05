using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGrievanceType
{
    public int LutGrievanceTypeId { get; set; }

    public string? GrievanceType { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnGrievanceTypeQuestion> AssnGrievanceTypeQuestions { get; set; } = new List<AssnGrievanceTypeQuestion>();

    public virtual ICollection<AssnGrievanceTypeSubQuestion> AssnGrievanceTypeSubQuestions { get; set; } = new List<AssnGrievanceTypeSubQuestion>();

    public virtual ICollection<LutGrievanceQuestion> LutGrievanceQuestions { get; set; } = new List<LutGrievanceQuestion>();

    public virtual ICollection<QrassnGrievanceTypeQuestion> QrassnGrievanceTypeQuestions { get; set; } = new List<QrassnGrievanceTypeQuestion>();

    public virtual ICollection<QrassnGrievanceTypeSubQuestion> QrassnGrievanceTypeSubQuestions { get; set; } = new List<QrassnGrievanceTypeSubQuestion>();
}
