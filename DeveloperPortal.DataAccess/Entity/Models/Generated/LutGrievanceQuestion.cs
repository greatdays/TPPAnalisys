using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGrievanceQuestion
{
    public int LutGrievanceQuestionId { get; set; }

    public string? Question { get; set; }

    public string? Tooltip { get; set; }

    public bool IsSubQuestion { get; set; }

    public bool IsMandatory { get; set; }

    public string? FieldTypeValue { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? LutGrievanceTypeId { get; set; }

    public string? FieldType { get; set; }

    public virtual ICollection<AssnGrievanceTypeQuestion> AssnGrievanceTypeQuestions { get; set; } = new List<AssnGrievanceTypeQuestion>();

    public virtual ICollection<AssnGrievanceTypeSubQuestion> AssnGrievanceTypeSubQuestions { get; set; } = new List<AssnGrievanceTypeSubQuestion>();

    public virtual ICollection<LutGrievanceSubQuestion> LutGrievanceSubQuestions { get; set; } = new List<LutGrievanceSubQuestion>();

    public virtual LutGrievanceType? LutGrievanceType { get; set; }

    public virtual ICollection<QRAssnGrievanceTypeQuestion> QRAssnGrievanceTypeQuestions { get; set; } = new List<QRAssnGrievanceTypeQuestion>();

    public virtual ICollection<QRAssnGrievanceTypeSubQuestion> QRAssnGrievanceTypeSubQuestions { get; set; } = new List<QRAssnGrievanceTypeSubQuestion>();
}
