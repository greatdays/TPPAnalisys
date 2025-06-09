using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwHcidaahpapplicationUser
{
    public string FullName { get; set; } = null!;

    public int UserId { get; set; }

    public string? EmployeeId { get; set; }

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }

    public string? EmployeeTitle { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsFirstTimeLogin { get; set; }

    public bool? IsLocked { get; set; }

    public int? UnsuccessfulLoginAttempt { get; set; }

    public string? MiddleName { get; set; }

    public string? IdmuserName { get; set; }
}
