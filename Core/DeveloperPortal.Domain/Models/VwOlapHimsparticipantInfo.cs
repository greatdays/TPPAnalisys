using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapHimsparticipantInfo
{
    public string FullProjectNumber { get; set; } = null!;

    public int ProjUniqueId { get; set; }

    public int ParticipantId { get; set; }

    public string? Address { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? FullZip { get; set; }

    public string? Csz { get; set; }

    public string? Zip1 { get; set; }

    public string? Zip2 { get; set; }

    public string? PnameAndType { get; set; }

    public string PfullNameOnly { get; set; } = null!;

    public string? LegalStatus { get; set; }

    public string? PrimaryPhoneNumber { get; set; }

    public string? SecondaryPhoneNumber { get; set; }

    public string? FaxNumber { get; set; }

    public string? ContactPerson { get; set; }

    public string? Prole { get; set; }

    public string? Pemail { get; set; }

    public string ParticipantTypeDesc { get; set; } = null!;

    public string? ApplicantBorrower { get; set; }

    public string? EscrowOrOrderNo { get; set; }

    public string TitleDescription { get; set; } = null!;
}
