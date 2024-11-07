using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ImpersonatedUserActivityDetail
{
    public int ImpersonatedUserActivityDetailsId { get; set; }

    public int? ImpersonatedUserLoginDetailsId { get; set; }

    public string? ImpersonatedUserName { get; set; }

    public string? Action { get; set; }

    public string? ActionName { get; set; }

    public string? TableName { get; set; }

    public string? ProcedureName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
