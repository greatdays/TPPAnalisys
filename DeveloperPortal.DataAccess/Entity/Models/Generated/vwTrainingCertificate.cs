using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwTrainingCertificate
{
    public int TrainingRegistryId { get; set; }

    public int TrainingSessionId { get; set; }

    public int ContactIdentifierId { get; set; }

    public int? OrganizationId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int LutAudienceCd { get; set; }

    public string AudienceCategory { get; set; } = null!;

    public int? LutCourseTypeId { get; set; }

    public string CourseTypeName { get; set; } = null!;

    public int CaseId { get; set; }

    public string CaseStatus { get; set; } = null!;

    public int DocumentEntityId { get; set; }

    public int DocTemplateId { get; set; }

    public string? DocumentNum { get; set; }

    public string? CertName { get; set; }

    public string? CertDescription { get; set; }

    public string? CertStNo { get; set; }

    public DateOnly? CertStDate { get; set; }

    public DateOnly? CertExpDate { get; set; }

    public string? CertTrainingCode { get; set; }

    public bool IsCurrent { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public Guid? RowId { get; set; }
}
