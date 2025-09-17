using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class BackupCase
{
    public int CaseId { get; set; }

    public int CaseTypeId { get; set; }

    public string? Summary { get; set; }

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public string? AssigneeId { get; set; }

    public string? AssigneeName { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? CaseNumber { get; set; }

    public int? Priority { get; set; }

    public DateOnly? StatusModifiedOn { get; set; }

    public int? MaxStatusDays { get; set; }

    public bool? IsTask { get; set; }

    public bool IsAuto { get; set; }

    public DateTime? AutoStautsModifiedOn { get; set; }

    public int? AutoMaxStatusDays { get; set; }

    public string? AutoNextAction { get; set; }

    public int? DueDays { get; set; }

    public int? AutoRemainingDays { get; set; }
}
