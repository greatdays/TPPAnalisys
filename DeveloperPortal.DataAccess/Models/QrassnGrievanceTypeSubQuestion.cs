using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class QrassnGrievanceTypeSubQuestion
{
    public int QrassnGrievanceTypeSubQuestionId { get; set; }

    public int? AssnGrievanceTypeSubQuestionId { get; set; }

    public int? GrievanceLogId { get; set; }

    public int? LutGrievanceTypeId { get; set; }

    public int? LutGrievanceQuestionId { get; set; }

    public int? LutGrievanceSubQuestionId { get; set; }

    public string? EmployeOrTenantName { get; set; }

    public string? EmployeeTitleOrUnitNumber { get; set; }

    public string? EmployeeOrTenantDescription { get; set; }

    public string? FieldType { get; set; }

    public string? FieldValue { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? QrgrievanceLogId { get; set; }

    public virtual AssnGrievanceTypeSubQuestion? AssnGrievanceTypeSubQuestion { get; set; }

    public virtual GrievanceLog? GrievanceLog { get; set; }

    public virtual LutGrievanceQuestion? LutGrievanceQuestion { get; set; }

    public virtual LutGrievanceSubQuestion? LutGrievanceSubQuestion { get; set; }

    public virtual LutGrievanceType? LutGrievanceType { get; set; }

    public virtual QrgrievanceLog? QrgrievanceLog { get; set; }
}
