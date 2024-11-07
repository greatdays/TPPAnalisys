using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_TrainingDetail
{
    public int TrainingID { get; set; }

    public int PropertyID { get; set; }

    public int ContactIdentifierID { get; set; }

    public string? ContactType { get; set; }

    public DateTime? _164_100_TrainingDate { get; set; }

    public string? _164_200_TraineeTitle { get; set; }

    public string? _164_300_TraineeName { get; set; }

    public string _164_300_TrainingCourseName { get; set; } = null!;

    public string? _164_400_TrainingType { get; set; }

    public string? _164_500_DateOfTrainingCertificate { get; set; }

    public string? _164_600_ExpiryDateOfTrainingCertificates { get; set; }

    public string? _164_700_TraineeFirstName { get; set; }

    public string? _164_710_TraineeMiddleName { get; set; }

    public string? _164_720_TraineeLastName { get; set; }

    public string? _738_Trn_Trainer_Email { get; set; }

    public string? _739_Trn_Trainer_Phone { get; set; }

    public string? _740_Trn_Trainer_Profile { get; set; }

    public string? _741_Trn_Trainer_HireDate { get; set; }

    public string? _742_Trn_Trainer_Comments { get; set; }

    public string _743_Trn_Course_CourseDetails { get; set; } = null!;

    public string? _744_Trn_Course_TargetAudience { get; set; }

    public int? _745_Trn_Course_Trainers { get; set; }

    public bool _746_Trn_Course_OnlyAllowEnrollmentForAccountsWithLinkedProperties { get; set; }

    public string? _747_Trn_Session_TrainingLocation { get; set; }

    public double _748_Trn_Session_Duration { get; set; }

    public int _749_Trn_Session_Capacity { get; set; }

    public bool _750_Trn_Session_IsPrivate { get; set; }

    public string? _751_Trn_Session_InternalStaffCommentOnly { get; set; }

    public string? _752_Trn_Session_TrainersName { get; set; }

    public string? _753_Trn_Session_Notes { get; set; }

    public string? _754_Trn_Enroll_EmailId { get; set; }

    public string? _755_Trn_Group_Email { get; set; }

    public string? _756_Trn_Group_LinkAssociatedPropertyAddress { get; set; }

    public string _767_Trn_Group_LinkOnSiteManagerName { get; set; } = null!;

    public string? PropertyName { get; set; }
}
