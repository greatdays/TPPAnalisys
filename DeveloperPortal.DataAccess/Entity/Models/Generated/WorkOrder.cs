using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WorkOrder
{
    public int WorkOrderID { get; set; }

    public long ServiceRequestID { get; set; }

    public string? ServiceTrackingID { get; set; }

    public int? PackageID { get; set; }

    public int? ContractorID { get; set; }

    public string? ContractorInstruction { get; set; }

    public decimal? EstimatedCost { get; set; }

    public decimal? TotalWOCost { get; set; }

    public DateTime? DateAward { get; set; }

    public DateTime? DateSignedOff { get; set; }

    public DateTime? DateSubmittedAcc { get; set; }

    public string? LateDay { get; set; }

    public decimal? EncumberedAmount { get; set; }

    public decimal? WOTalliedAmount { get; set; }

    public decimal? InvoiceAmount { get; set; }

    public DateTime? WCDueDate { get; set; }

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
