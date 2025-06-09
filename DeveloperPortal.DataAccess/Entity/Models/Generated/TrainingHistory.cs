using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class TrainingHistory
{
    public int Id { get; set; }

    public DateTime CaptureDate { get; set; }

    public int? TrainingCourseId { get; set; }

    public int TrainingSessionId { get; set; }

    public string TrainingCode { get; set; } = null!;

    public string? TrainingType { get; set; }

    public DateTime? TrainingDate { get; set; }

    public int TrainingRegistryId { get; set; }

    public int CaseId { get; set; }

    public DateTime? TrainingRegistryCreatedOn { get; set; }

    public string? TrainingRegistryCreatedBy { get; set; }

    public string? TrainingRegistryCreatedByName { get; set; }

    public string? TrainingRegistryFirstName { get; set; }

    public string? TrainingRegistryMiddleName { get; set; }

    public string? TrainingRegistryLastName { get; set; }

    public string? TrainingRegistryName { get; set; }

    public string? TrainingRegistyEmail { get; set; }

    public int ContactIdentifierId { get; set; }

    public int ContactId { get; set; }

    public string? TraineeTitle { get; set; }

    public string? ContactIdentifierIdmuserName { get; set; }

    public string? ContactIdentifierFirstName { get; set; }

    public string? ContactIdentifierMiddleName { get; set; }

    public string? ContactIdentifierLastName { get; set; }

    public string? ContactIdentifierName { get; set; }

    public string? ContactIdentifierEmail { get; set; }

    public string? StatementNumber { get; set; }

    public DateOnly? DateOfTrainingCertificate { get; set; }

    public DateOnly? ExpirationDateOfCertificate { get; set; }

    public string? TrainerName { get; set; }

    public string? TrainerEmail { get; set; }

    public string? TrainerPhone { get; set; }

    public string? TrainerProfile { get; set; }

    public string? TrainerHireDate { get; set; }

    public string? TrainerComments { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseDetails { get; set; } = null!;

    public int CourseAudience { get; set; }

    public bool? AllowOnlyLinkedProperties { get; set; }

    public string TrainingLocation { get; set; } = null!;

    public double TrainingDuration { get; set; }

    public int Capacity { get; set; }

    public bool IsPrivate { get; set; }

    public string? Staffcomments { get; set; }

    public string? TrainingSessionNotes { get; set; }

    public string TrainingRegistryStatus { get; set; } = null!;

    public DateTime? CancelByUserDate { get; set; }

    public DateTime? CancelByHostDate { get; set; }

    public DateTime? EnrolledDate { get; set; }

    public DateTime? MarkAbsentDate { get; set; }

    public DateTime? MarkAttendDate { get; set; }

    public DateTime? GenerateCertificateDate { get; set; }

    public DateTime? EmailCertificateDate { get; set; }

    public DateTime? TransferCertificateDate { get; set; }

    public DateTime? UpdateCertificateNameDate { get; set; }

    public string? DocumentEntity { get; set; }

    public int? GroupAssnContactContactId { get; set; }

    public int? GroupContactIdentifierId { get; set; }

    public string? GroupContactFirstName { get; set; }

    public string? GroupContactMiddleName { get; set; }

    public string? GroupContactLastName { get; set; }

    public string? GroupIdmuserName { get; set; }

    public DateOnly? GroupContactLinkDate { get; set; }
}
