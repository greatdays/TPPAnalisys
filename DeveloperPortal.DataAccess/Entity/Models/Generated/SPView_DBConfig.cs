using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SPView_DBConfig
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
    public string DBName { get; set; } = null!;

    public virtual ICollection<SPView_SPConfig> SPView_SPConfigs { get; set; } = new List<SPView_SPConfig>();
}
