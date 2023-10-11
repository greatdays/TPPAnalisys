using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class GrievanceType
{
    public int GrievanceTypeId { get; set; }

    public int GrievanceId { get; set; }

    public int? LutGrievantTypeId { get; set; }

    public bool? IsReasonableAccomodation { get; set; }

    public bool? IsReasonableAccmNotProcessedPromptly { get; set; }

    public bool? IsReasonableAccmThirdPartyVerification { get; set; }

    public bool? IsReasonableAccmPartiallyGranted { get; set; }

    public bool? IsReasonableAccmDenied { get; set; }

    public bool? IsReasonableAccmOtherIssues { get; set; }

    public string? ReasonableAccmOtherIssues { get; set; }

    public DateTime? ReasonableAccmRequestDate { get; set; }

    public DateTime? ReasonableAccmNotifiedDenyDate { get; set; }

    public bool? IsReasonableModification { get; set; }

    public bool? IsReasonableModfNotProcessedPromptly { get; set; }

    public bool? IsReasonableModfThirdPartyVerification { get; set; }

    public bool? IsReasonableModfPartiallyGranted { get; set; }

    public bool? IsReasonableModfDenied { get; set; }

    public bool? IsReasonableModfOtherIssues { get; set; }

    public string? ReasonableModfOtherIssues { get; set; }

    public DateTime? ReasonableModfRequestDate { get; set; }

    public DateTime? ReasonableModfNotifiedDenyDate { get; set; }

    public bool? IsEffectiveCommunication { get; set; }

    public DateTime? EffectiveCommRequestDate { get; set; }

    public DateTime? EffectiveCommNotifiedDenyDate { get; set; }

    public bool? IsMaintenanceOfAccessibleFeatures { get; set; }

    public bool? IsElevators { get; set; }

    public bool? IsWaitingListOrUnitTransfer { get; set; }

    public DateTime? WaitingLstRequestDate { get; set; }

    public DateTime? WaitingLstNotifiedDenyDate { get; set; }

    public bool? IsPotentialEviction { get; set; }

    public DateTime? EvictionNoticeDate { get; set; }

    public bool? IsPendingOrPastEviction { get; set; }

    public bool? IsRetrofitRelocation { get; set; }

    public string? RetrofitRelocationDetails { get; set; }

    public bool? IsNoiseComplaint { get; set; }

    public bool? IsNoiseBotheringGrievant { get; set; }

    public string? NoiseTenantName { get; set; }

    public string? NoiseUnitNumberOrCommonArea { get; set; }

    public bool? IsNoiseFromGrievant { get; set; }

    public bool? IsAssistanceAnimal { get; set; }

    public DateTime? AssistanceAnimalNotifiedDenyDate { get; set; }

    public bool? IsDiscrimination { get; set; }

    public bool? IsHarassment { get; set; }

    public bool? IsHarasserEmployee { get; set; }

    public string? HarasserEmployeeName { get; set; }

    public string? HarasserEmployeeTitle { get; set; }

    public string? HarasserEmployeeDetails { get; set; }

    public bool? IsHarasserContractorOrAgent { get; set; }

    public string? HarasserAgentEmpName { get; set; }

    public string? HarasserAgentEmpTitle { get; set; }

    public string? HarasserAgentEmpDetails { get; set; }

    public bool? IsHarasserTenantOrGuest { get; set; }

    public string? HarasserTenantName { get; set; }

    public string? HarasserUnitNumber { get; set; }

    public string? HarasserTenantDetails { get; set; }

    public bool? IsHarasserOther { get; set; }

    public string? HarasserOtherDetails { get; set; }

    public bool? IsHarassmentProtectedGroup { get; set; }

    public bool? IsRetaliation { get; set; }

    public bool? IsRentalApplication { get; set; }

    public DateTime? RentalAppSubmitDate { get; set; }

    public DateTime? RentalAppNotifiedDenyDate { get; set; }

    public bool? IsOtherBasis { get; set; }

    public string? OtherBasisDetails { get; set; }

    public bool? IsSameIssueFiledWithProperty { get; set; }

    public DateTime? PropertyGrievanceDate { get; set; }

    public DateTime? QrgrievanceLogDate { get; set; }

    public DateTime? PropertyDecisionDate { get; set; }

    public bool? IsPropertyFollowedProcedures { get; set; }

    public string? PropertyFollowedProceduresDetails { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowId { get; set; }

    public bool? IsMaintenanceRelatedToDisability { get; set; }

    public string? MaintenanceRelatedToDisabilityDetails { get; set; }

    public bool? IsLanguageAccess { get; set; }

    public string? LanguageAccessDetails { get; set; }

    public string? ReasonableAccmQrid { get; set; }

    public bool? IsUnknownReasonableAccmQrid { get; set; }

    public string? ReasonableModfQrid { get; set; }

    public bool? IsUnknownReasonableModfQrid { get; set; }

    public string? EffectiveCommQrid { get; set; }

    public bool? IsUnknownEffectiveCommQrid { get; set; }

    public string? GrievantTypeOther { get; set; }

    public virtual ICollection<AssnGrievanceTypeMultiSelectOption> AssnGrievanceTypeMultiSelectOptions { get; set; } = new List<AssnGrievanceTypeMultiSelectOption>();

    public virtual Grievance Grievance { get; set; } = null!;

    public virtual LutGrievantType? LutGrievantType { get; set; }
}
