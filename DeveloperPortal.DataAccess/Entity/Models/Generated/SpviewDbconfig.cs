using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SpviewDbconfig
{
    /// <summary>
    /// DBConfigID is identity column.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// This field is used to store database server name.
    /// </summary>
    public string ServerName { get; set; } = null!;

    /// <summary>
    /// This field is used to store database username.
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    /// This field is used to store database password.
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Port.
    /// </summary>
    public string? Port { get; set; }

    /// <summary>
    /// This field is used to store database name.
    /// </summary>
    public string Dbname { get; set; } = null!;

    public virtual ICollection<SpviewSpconfig> SpviewSpconfigs { get; set; } = new List<SpviewSpconfig>();
}
