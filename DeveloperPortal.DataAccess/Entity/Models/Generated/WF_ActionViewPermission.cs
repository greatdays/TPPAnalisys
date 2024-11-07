using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WF_ActionViewPermission
{
    public int ActionViewPermissionID { get; set; }

    public int? ActionViewID { get; set; }

    public int? RoleID { get; set; }

    public string? FieldName { get; set; }

    public bool Enabled { get; set; }

    public virtual WF_ActionView? ActionView { get; set; }

    public virtual RoleMaster? Role { get; set; }
}
