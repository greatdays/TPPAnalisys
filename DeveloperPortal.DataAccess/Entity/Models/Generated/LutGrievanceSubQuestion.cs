using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGrievanceSubQuestion
{
    public int LutGrievanceSubQuestionId { get; set; }

    public int? LutGrievanceQuestionId { get; set; }

    public string? SubQuestion { get; set; }

    public string? FieldType { get; set; }

    public bool IsDependantField { get; set; }

    public string? DependantFieldJson { get; set; }

    public string? SubQuestionHeader { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AssnGrievanceTypeSubQuestion> AssnGrievanceTypeSubQuestions { get; set; } = new List<AssnGrievanceTypeSubQuestion>();

    public virtual LutGrievanceQuestion? LutGrievanceQuestion { get; set; }

    public virtual ICollection<QrassnGrievanceTypeSubQuestion> QrassnGrievanceTypeSubQuestions { get; set; } = new List<QrassnGrievanceTypeSubQuestion>();
}
