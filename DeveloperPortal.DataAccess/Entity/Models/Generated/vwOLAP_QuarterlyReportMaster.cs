using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_QuarterlyReportMaster
{
    public int? ProjectID { get; set; }

    public int PropertyID { get; set; }

    public string? Project_Name { get; set; }

    public string? Property_Name { get; set; }

    public string? Quarter { get; set; }

    public int? Year { get; set; }

    public string YearQR { get; set; } = null!;

    public string? MaxYearQR { get; set; }

    public int QuarterlyReportID { get; set; }

    public int? MaxQrID { get; set; }

    public string? FileNumber { get; set; }

    public int? PropSnapShotID { get; set; }

    public long? ServiceRequestID { get; set; }

    public int? TotalSubmission { get; set; }

    public int? LastQRReport { get; set; }

    public int? FirstQRReport { get; set; }

    public int CaseID { get; set; }

    public string CaseStatus { get; set; } = null!;

    public int? SubmittedCaseLogID { get; set; }

    public string? SubmitAction { get; set; }

    public string? SubmitFromStatus { get; set; }

    public string? SubmitToStatus { get; set; }

    public DateTime? SubmittedOn { get; set; }

    public string? SubmittedBy { get; set; }

    public int? ReviewedCaseLogID { get; set; }

    public string? ReviewAction { get; set; }

    public string? ReviewFromStatus { get; set; }

    public string? ReviewToStatus { get; set; }

    public DateTime? ReviewedOn { get; set; }

    public string? ReviewedBy { get; set; }

    public string? QuarterlyReportIDStatus { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? FirstSubmittedOn { get; set; }

    public string? FirstSubmittedBy { get; set; }

    public DateTime? FirstReviewedOn { get; set; }

    public string? FirstReviewedBy { get; set; }

    public DateTime? LastSubmittedOn { get; set; }

    public string? LastSubmittedBy { get; set; }

    public int? NumberReportReviewed { get; set; }

    public int? LastQRReviewReportID { get; set; }

    public DateTime? LastReviewOn { get; set; }

    public string? LastReviewBy { get; set; }

    public string FinalReviewDate { get; set; } = null!;

    public int? QRFairHousingID { get; set; }

    public DateOnly? QRBeginDate { get; set; }

    public DateOnly? QREndDate { get; set; }

    public string? QRPropertyName { get; set; }

    public string? Property_Address { get; set; }

    public string? PMName { get; set; }

    public string? PMPhone { get; set; }

    public string? PMEmail { get; set; }

    public int? TotalFullyAccessibleMobilityUnit { get; set; }

    public int? TotalFullyAccessibleHVUnit { get; set; }

    public int? TotalVacantAUThisQuarter { get; set; }

    public int? TotalTenantsOccupiedAUWithoutNeed { get; set; }

    public string? LegalOwnerName { get; set; }

    public string? OwnerAddress { get; set; }

    public string? OwnerEmail { get; set; }

    public string? OwnerPhone { get; set; }

    public string? SignerName { get; set; }

    public string? Title____Regional_Manager_or_Property_Manager_ { get; set; }

    public DateOnly? SignDate { get; set; }

    public string? Accepted_Statement_1 { get; set; }

    public string? Accepted_Statement_2 { get; set; }

    public string? Accepted_Statement_3 { get; set; }

    public string? Accepted_Statement_4 { get; set; }

    public string? Accepted_Statement_5 { get; set; }

    public string? Accepted_Statement_6 { get; set; }

    public string? Accepted_Statement_7 { get; set; }

    public string? Accepted_Statement_8 { get; set; }

    public string? Accepted_Statement_9 { get; set; }

    public string? Accepted_Statement_10 { get; set; }

    public string? Accepted_Statement_11 { get; set; }

    public string? Accepted_Statement_12 { get; set; }

    public string? Accepted_Statement_13 { get; set; }

    public string? Accepted_Statement_14 { get; set; }

    public string? Accepted_Statement_15 { get; set; }

    public string? Accepted_Statement_16 { get; set; }

    public string _114_000_DatesOfSubsequentAuMarketing { get; set; } = null!;

    public string _135_000_DateOfCompletionReviewQuarterlyReport { get; set; } = null!;

    public string? _143_000_DateAcHPReviewGrievancesFiledWithProperty { get; set; }

    public DateTime? _152_000_DateOfSubmissionQuarterlyReport { get; set; }

    public string _154_000_QuarterlyReportQuarter { get; set; } = null!;

    public string? _155_000_QuarterlyReportStatus { get; set; }

    public DateTime? _156_000_DatesAcHPReviewofQuarterlyReportCompleted { get; set; }
}
