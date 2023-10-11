using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapQreffectiveCommunication
{
    public int? ProjectSiteId { get; set; }

    public int QuarterlyReportId { get; set; }

    public string? Quarter { get; set; }

    public int? Year { get; set; }

    public DateTime QrcreatedOn { get; set; }

    public DateTime? QrsubmittedOn { get; set; }

    public DateTime? QrreviwedOn { get; set; }

    public string? Action { get; set; }

    public int QreffectiveCommunicationId { get; set; }

    public string UserType { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public string? TenantCurrentUnit { get; set; }

    public string? Address { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? EcrequestType { get; set; }

    public string? RequestDescription { get; set; }

    public string? DeterminationStatus { get; set; }

    public DateTime? DeterminationDate { get; set; }

    public string? DeterminationExplaination { get; set; }

    public DateTime? AnticipatedImplementationDate { get; set; }

    public DateTime? ImplementationDate { get; set; }

    public string? ImplementationNotes { get; set; }

    public bool? IsGrievanceProcedureProvided { get; set; }

    public bool? IsGrievanceField { get; set; }

    public DateTime? GrievanceDate { get; set; }

    public string? GrievanceLogNumber { get; set; }

    public bool? Iscovered { get; set; }
}
