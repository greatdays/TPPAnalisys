using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnUserFavouriteCase
{
    public string UserName { get; set; } = null!;

    public int CaseId { get; set; }

    public virtual Case Case { get; set; } = null!;
}
