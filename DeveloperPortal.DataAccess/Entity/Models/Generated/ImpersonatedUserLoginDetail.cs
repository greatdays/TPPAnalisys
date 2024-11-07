using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ImpersonatedUserLoginDetail
{
    public int ImpersonatedUserLoginDetailsId { get; set; }

    public string ImpersonatedFromUserName { get; set; } = null!;

    public string? ImpersonatedUserName { get; set; }

    public DateTime? ImpersonatedUserLoginTime { get; set; }

    public DateTime? ImpersonatedUserLogoutTime { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
