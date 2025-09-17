using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Tppuser
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime CreatedOn { get; set; }

    public string Provider { get; set; } = null!;

    public virtual ICollection<TpprefreshToken> TpprefreshTokens { get; set; } = new List<TpprefreshToken>();
}
