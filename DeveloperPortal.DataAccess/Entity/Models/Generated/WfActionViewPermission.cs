using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WfActionViewPermission
{
    public int ActionViewPermissionId { get; set; }

    public int? ActionViewId { get; set; }

    public int? RoleId { get; set; }

    public string? FieldName { get; set; }

    public bool Enabled { get; set; }

    public virtual WfActionView? ActionView { get; set; }

    public virtual RoleMaster? Role { get; set; }
}
