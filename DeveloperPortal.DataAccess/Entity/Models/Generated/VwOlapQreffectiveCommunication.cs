using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapQreffectiveCommunication
{
    public string YearQr { get; set; } = null!;

    public string? MaxYearQr { get; set; }

    public int QuarterlyReportId { get; set; }

    public int? MaxQrId { get; set; }

    public int? EffectiveCommunicationId { get; set; }

    public int QreffectiveCommunicationId { get; set; }

    public DateTime QrreportCreateDate { get; set; }

    public int? ProjectId { get; set; }

    public int PropertyId { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyName { get; set; }

    public string? FileNumber { get; set; }

    public string? UserType { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public string? RequestorAddress { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? EcrequestType { get; set; }

    public string? RequestDescription { get; set; }

    public string? DeterminationStatus { get; set; }

    public DateTime? DeterminationDate { get; set; }

    public string? DeterminationExplaination { get; set; }

    public DateTime? AnticipatedImplementationDate { get; set; }

    public DateTime? ImplementationDate { get; set; }

    public string? ImplementationNotes { get; set; }

    public string IsGrievanceProcedureProvided { get; set; } = null!;

    public string IsGrievanceField { get; set; } = null!;

    public DateTime? GrievanceDate { get; set; }

    public string? GrievanceLogNumber { get; set; }

    public string _280000EffectiveCommunicationsThisQurter { get; set; } = null!;

    public string _281000EffectiveCommunicationsGrantedOnReport { get; set; } = null!;

    public string _281000EffectiveCommunicationsGrantedThisQurter { get; set; } = null!;

    public string _281000EffectiveCommunicationsGrantedAndPartiallyGrantedOnReport { get; set; } = null!;

    public string _281000EffectiveCommunicationsGrantedAndPartiallyGrantedOnReportThisQurter { get; set; } = null!;

    public string _282000EffectiveCommunicationsDeniedOnReport { get; set; } = null!;

    public string _282000EffectiveCommunicationsDeniedThisQurter { get; set; } = null!;

    public string _283000EffectiveCommunicationsPendingOnReport { get; set; } = null!;

    public string? _347000ApplicantOrTenantEclog { get; set; }

    public string? _347100RequestorFirstNameEclog { get; set; }

    public string _347200RequestorMiddleInitialEclog { get; set; } = null!;

    public string? _347300RequestorLastNameEclog { get; set; }

    public string? _348000TypeOfEffectiveCommunicationsRequestEclog { get; set; }

    public string? _366000DeterminationStatusEclog { get; set; }

    public string _367000DateOfDeterminationEclog { get; set; } = null!;

    public string _368000DateOfAnticipatedImplementationEclog { get; set; } = null!;

    public string _369000DateOfImplementationCompletionEclog { get; set; } = null!;

    public string? _369100ImplementationInformationEclog { get; set; }

    public string _369200AdditionalImplementationInformationEclog { get; set; } = null!;

    public string _369300IfDeniedCheckAllThatApplyEclog { get; set; } = null!;

    public string _370000DateOfGrievanceEclog { get; set; } = null!;

    public string? _371000CorrespondingGrievanceNumberEclog { get; set; }

    public DateTime? _347400DateOfRequestForEffectiveCommunication { get; set; }

    public string? _347500TenantsCurrentUnitAddress { get; set; }

    public string _347600TenantsCurrentUnitNum { get; set; } = null!;

    public string? _347700ApplicantsAddress { get; set; }

    public DateOnly? _366100DateOfWithdrawal { get; set; }

    public string _366200ReasonForWithdrawal { get; set; } = null!;

    public string _367100ExplanationOfDetermination { get; set; } = null!;

    public string? _348010SubCategoryEffectiveCommunication { get; set; }

    public string? _348020SubCategoryEffectiveCommunicationCommonArea { get; set; }

    public string? _348030SubCategoryOther { get; set; }

    public string _348100DescriptionOfEcrequest { get; set; } = null!;

    public string _1109000SubCategoryLanguageAccess { get; set; } = null!;

    public string _1109100SubCategoryLanguageAccessLanguage { get; set; } = null!;
}
