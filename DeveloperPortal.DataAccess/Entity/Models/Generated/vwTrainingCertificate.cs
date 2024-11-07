using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwTrainingCertificate
{
    public int TrainingRegistryID { get; set; }

    public int TrainingSessionID { get; set; }

    public int ContactIdentifierID { get; set; }

    public int? OrganizationID { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int CourseID { get; set; }

    public string CourseName { get; set; } = null!;

    public int LutAudienceCD { get; set; }

    public string AudienceCategory { get; set; } = null!;

    public int? LutCourseTypeID { get; set; }

    public string CourseTypeName { get; set; } = null!;

    public int CaseID { get; set; }

    public string CaseStatus { get; set; } = null!;

    public int DocumentEntityID { get; set; }

    public int DocTemplateID { get; set; }

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

    public Guid? RowID { get; set; }
}
