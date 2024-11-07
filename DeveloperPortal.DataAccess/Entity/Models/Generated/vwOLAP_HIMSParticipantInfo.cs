using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_HIMSParticipantInfo
{
    public string FullProjectNumber { get; set; } = null!;

    public int ProjUniqueID { get; set; }

    public int ParticipantID { get; set; }

    public string? address { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? FullZip { get; set; }

    public string? CSZ { get; set; }

    public string? Zip1 { get; set; }

    public string? Zip2 { get; set; }

    public string? PNameAndType { get; set; }

    public string PFullNameOnly { get; set; } = null!;

    public string? LegalStatus { get; set; }

    public string? PrimaryPhoneNumber { get; set; }

    public string? SecondaryPhoneNumber { get; set; }

    public string? FaxNumber { get; set; }

    public string? ContactPerson { get; set; }

    public string? PRole { get; set; }

    public string? PEmail { get; set; }

    public string ParticipantTypeDesc { get; set; } = null!;

    public string? ApplicantBorrower { get; set; }

    public string? EscrowOrOrderNo { get; set; }

    public string TitleDescription { get; set; } = null!;
}
