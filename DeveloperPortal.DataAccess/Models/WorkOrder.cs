using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class WorkOrder
{
    public int WorkOrderId { get; set; }

    public long ServiceRequestId { get; set; }

    public string? ServiceTrackingId { get; set; }

    public int? PackageId { get; set; }

    public int? ContractorId { get; set; }

    public string? ContractorInstruction { get; set; }

    public decimal? EstimatedCost { get; set; }

    public decimal? TotalWocost { get; set; }

    public DateTime? DateAward { get; set; }

    public DateTime? DateSignedOff { get; set; }

    public DateTime? DateSubmittedAcc { get; set; }

    public string? LateDay { get; set; }

    public decimal? EncumberedAmount { get; set; }

    public decimal? WotalliedAmount { get; set; }

    public decimal? InvoiceAmount { get; set; }

    public DateTime? WcdueDate { get; set; }

    public DateTime? ExtendedDueDate { get; set; }

    public DateTime? WorkCompletionDate { get; set; }

    public DateTime? InvoicingDate { get; set; }

    public DateTime? ReleasedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? WorkOrderReference { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual AssnUserContractor? Contractor { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
