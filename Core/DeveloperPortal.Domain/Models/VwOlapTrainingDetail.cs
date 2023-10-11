using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapTrainingDetail
{
    public int TrainingId { get; set; }

    public int PropertyId { get; set; }

    public int ContactIdentifierId { get; set; }

    public string? ContactType { get; set; }

    public DateTime? _164100TrainingDate { get; set; }

    public string? _164200TraineeTitle { get; set; }

    public string? _164300TraineeName { get; set; }

    public string _164300TrainingCourseName { get; set; } = null!;

    public string? _164400TrainingType { get; set; }

    public string? _164500DateOfTrainingCertificate { get; set; }

    public string? _164600ExpiryDateOfTrainingCertificates { get; set; }

    public string? _164700TraineeFirstName { get; set; }

    public string? _164710TraineeMiddleName { get; set; }

    public string? _164720TraineeLastName { get; set; }

    public string? _738TrnTrainerEmail { get; set; }

    public string? _739TrnTrainerPhone { get; set; }

    public string? _740TrnTrainerProfile { get; set; }

    public string? _741TrnTrainerHireDate { get; set; }

    public string? _742TrnTrainerComments { get; set; }

    public string _743TrnCourseCourseDetails { get; set; } = null!;

    public string? _744TrnCourseTargetAudience { get; set; }

    public int? _745TrnCourseTrainers { get; set; }

    public bool _746TrnCourseOnlyAllowEnrollmentForAccountsWithLinkedProperties { get; set; }

    public string? _747TrnSessionTrainingLocation { get; set; }

    public double _748TrnSessionDuration { get; set; }

    public int _749TrnSessionCapacity { get; set; }

    public bool _750TrnSessionIsPrivate { get; set; }

    public string? _751TrnSessionInternalStaffCommentOnly { get; set; }

    public string? _752TrnSessionTrainersName { get; set; }

    public string? _753TrnSessionNotes { get; set; }

    public string? _754TrnEnrollEmailId { get; set; }

    public string? _755TrnGroupEmail { get; set; }

    public string? _756TrnGroupLinkAssociatedPropertyAddress { get; set; }

    public string _767TrnGroupLinkOnSiteManagerName { get; set; } = null!;

    public string? PropertyName { get; set; }
}
