using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class NotificationSource
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public string Host { get; set; } = null!;

    public int Port { get; set; }

    public string CredentialName { get; set; } = null!;

    public string CredentialPwd { get; set; } = null!;

    public string FromEmailId { get; set; } = null!;

    public bool? EnableSsl { get; set; }
}
