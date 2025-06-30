using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapQuarterlyReportMaster
{
    public int? ProjectId { get; set; }

    public int PropertyId { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyName { get; set; }

    public string? Quarter { get; set; }

    public int? Year { get; set; }

    public string YearQr { get; set; } = null!;

    public string? MaxYearQr { get; set; }

    public int QuarterlyReportId { get; set; }

    public int? MaxQrId { get; set; }

    public string? FileNumber { get; set; }

    public int? PropSnapShotId { get; set; }

    public long? ServiceRequestId { get; set; }

    public int? TotalSubmission { get; set; }

    public int? LastQrreport { get; set; }

    public int? FirstQrreport { get; set; }

    public int CaseId { get; set; }

    public string CaseStatus { get; set; } = null!;

    public int? SubmittedCaseLogId { get; set; }

    public string? SubmitAction { get; set; }

    public string? SubmitFromStatus { get; set; }

    public string? SubmitToStatus { get; set; }

    public DateTime? SubmittedOn { get; set; }

    public string? SubmittedBy { get; set; }

    public int? ReviewedCaseLogId { get; set; }

    public string? ReviewAction { get; set; }

    public string? ReviewFromStatus { get; set; }

    public string? ReviewToStatus { get; set; }

    public DateTime? ReviewedOn { get; set; }

    public string? ReviewedBy { get; set; }

    public string? QuarterlyReportIdstatus { get; set; }

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

    public int? LastQrreviewReportId { get; set; }

    public DateTime? LastReviewOn { get; set; }

    public string? LastReviewBy { get; set; }

    public string FinalReviewDate { get; set; } = null!;

    public int? QrfairHousingId { get; set; }

    public DateOnly? QrbeginDate { get; set; }

    public DateOnly? QrendDate { get; set; }

    public string? QrpropertyName { get; set; }

    public string? PropertyAddress { get; set; }

    public string? Pmname { get; set; }

    public string? Pmphone { get; set; }

    public string? Pmemail { get; set; }

    public int? TotalFullyAccessibleMobilityUnit { get; set; }

    public int? TotalFullyAccessibleHvunit { get; set; }

    public int? TotalVacantAuthisQuarter { get; set; }

    public int? TotalTenantsOccupiedAuwithoutNeed { get; set; }

    public string? LegalOwnerName { get; set; }

    public string? OwnerAddress { get; set; }

    public string? OwnerEmail { get; set; }

    public string? OwnerPhone { get; set; }

    public string? SignerName { get; set; }

    public string? TitleRegionalManagerOrPropertyManager { get; set; }

    public DateOnly? SignDate { get; set; }

    public string? AcceptedStatement1 { get; set; }

    public string? AcceptedStatement2 { get; set; }

    public string? AcceptedStatement3 { get; set; }

    public string? AcceptedStatement4 { get; set; }

    public string? AcceptedStatement5 { get; set; }

    public string? AcceptedStatement6 { get; set; }

    public string? AcceptedStatement7 { get; set; }

    public string? AcceptedStatement8 { get; set; }

    public string? AcceptedStatement9 { get; set; }

    public string? AcceptedStatement10 { get; set; }

    public string? AcceptedStatement11 { get; set; }

    public string? AcceptedStatement12 { get; set; }

    public string? AcceptedStatement13 { get; set; }

    public string? AcceptedStatement14 { get; set; }

    public string? AcceptedStatement15 { get; set; }

    public string? AcceptedStatement16 { get; set; }

    public string _114000DatesOfSubsequentAuMarketing { get; set; } = null!;

    public string _135000DateOfCompletionReviewQuarterlyReport { get; set; } = null!;

    public string? _143000DateAcHpreviewGrievancesFiledWithProperty { get; set; }

    public DateTime? _152000DateOfSubmissionQuarterlyReport { get; set; }

    public string _154000QuarterlyReportQuarter { get; set; } = null!;

    public string? _155000QuarterlyReportStatus { get; set; }

    public DateTime? _156000DatesAcHpreviewofQuarterlyReportCompleted { get; set; }
}
