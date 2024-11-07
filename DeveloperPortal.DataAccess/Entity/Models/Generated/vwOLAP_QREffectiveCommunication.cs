using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_QREffectiveCommunication
{
    public string YearQR { get; set; } = null!;

    public string? MaxYearQR { get; set; }

    public int QuarterlyReportID { get; set; }

    public int? MaxQrID { get; set; }

    public int? EffectiveCommunicationID { get; set; }

    public int QREffectiveCommunicationID { get; set; }

    public DateTime QRReportCreateDate { get; set; }

    public int? ProjectID { get; set; }

    public int PropertyID { get; set; }

    public string? Project_Name { get; set; }

    public string? Property_Name { get; set; }

    public string? FileNumber { get; set; }

    public string? UserType { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public string? RequestorAddress { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? ECRequestType { get; set; }

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

    public string _280_000_EffectiveCommunicationsThisQurter { get; set; } = null!;

    public string _281_000_EffectiveCommunicationsGrantedOnReport { get; set; } = null!;

    public string _281_000_EffectiveCommunicationsGrantedThisQurter { get; set; } = null!;

    public string _281_000_EffectiveCommunicationsGrantedAndPartiallyGrantedOnReport { get; set; } = null!;

    public string _281_000_EffectiveCommunicationsGrantedAndPartiallyGrantedOnReportThisQurter { get; set; } = null!;

    public string _282_000_EffectiveCommunicationsDeniedOnReport { get; set; } = null!;

    public string _282_000_EffectiveCommunicationsDeniedThisQurter { get; set; } = null!;

    public string _283_000_EffectiveCommunicationsPendingOnReport { get; set; } = null!;

    public string? _347_000_ApplicantOrTenant_ECLog { get; set; }

    public string? _347_100_RequestorFirstName_ECLog { get; set; }

    public string _347_200_RequestorMiddleInitial_ECLog { get; set; } = null!;

    public string? _347_300_RequestorLastName_ECLog { get; set; }

    public string? _348_000_TypeOfEffectiveCommunicationsRequest_ECLog { get; set; }

    public string? _366_000_DeterminationStatus_ECLog { get; set; }

    public string _367_000_DateOfDetermination_ECLog { get; set; } = null!;

    public string _368_000_DateOfAnticipatedImplementation_ECLog { get; set; } = null!;

    public string _369_000_DateOfImplementationCompletion_ECLog { get; set; } = null!;

    public string? _369_100_ImplementationInformation_ECLog { get; set; }

    public string _369_200_AdditionalImplementationInformation_ECLog { get; set; } = null!;

    public string _369_300_IfDenied_CheckAllThatApply_ECLog { get; set; } = null!;

    public string _370_000_DateOfGrievance_ECLog { get; set; } = null!;

    public string? _371_000_CorrespondingGrievanceNumber_ECLog { get; set; }

    public DateTime? _347_400_DateOfRequestForEffectiveCommunication { get; set; }

    public string? _347_500_TenantsCurrentUnitAddress { get; set; }

    public string _347_600_TenantsCurrentUnitNum { get; set; } = null!;

    public string? _347_700_ApplicantsAddress { get; set; }

    public DateOnly? _366_100_DateOfWithdrawal { get; set; }

    public string _366_200_ReasonForWithdrawal { get; set; } = null!;

    public string _367_100_ExplanationOfDetermination { get; set; } = null!;

    public string? _348_010_SubCategory_EffectiveCommunication { get; set; }

    public string? _348_020_SubCategory_Effective_Communication_Common_Area { get; set; }

    public string? _348_030_SubCategory_Other { get; set; }

    public string _348_100_DescriptionOfECRequest { get; set; } = null!;

    public string _1109_000_SubCategory_LanguageAccess { get; set; } = null!;

    public string _1109_100_SubCategory_LanguageAccess_Language { get; set; } = null!;
}
