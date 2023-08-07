using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class GrievanceAppeal
{
    public int GrievanceAppealId { get; set; }

    public long ServiceRequestId { get; set; }

    public string? GrievantFirstName { get; set; }

    public string? GrievantMiddleName { get; set; }

    public string? GrievantLastName { get; set; }

    public string? GrievantPrimaryPhone { get; set; }

    public string? GrievantPrimaryLutPhoneTypeCd { get; set; }

    public string? GrievantAltPhone { get; set; }

    public string? GrievantAltLutPhoneTypeCd { get; set; }

    public string? GrievantEmail { get; set; }

    public string? GrievantLanguage { get; set; }

    public bool? IsGrievantPreferredContactEmail { get; set; }

    public bool? IsGrievantPreferredContactPhone { get; set; }

    public bool? IsGrievantPreferredContactTty { get; set; }

    public bool? IsGrievantPreferredContactUsmail { get; set; }

    public string? GrievantPreferredContactMethodOther { get; set; }

    public bool? IsGrievantAddressPobox { get; set; }

    public int? GrievantAddressHouseNum { get; set; }

    public string? GrievantAddressHouseFracNum { get; set; }

    public string? GrievantAddressLutPreDirCd { get; set; }

    public string? GrievantAddressStreetName { get; set; }

    public string? GrievantAddressLutStreetTypeCd { get; set; }

    public string? GrievantAddressUnit { get; set; }

    public string? GrievantAddressCity { get; set; }

    public string? GrievantAddressLutStateCd { get; set; }

    public int? GrievantAddressZip { get; set; }

    public bool IsFileForSomeOne { get; set; }

    public string? PreparerRelationship { get; set; }

    public string? PreparerFirstName { get; set; }

    public string? PreparerMiddleName { get; set; }

    public string? PreparerLastName { get; set; }

    public string? PreparerPrimaryPhone { get; set; }

    public string? PreparerPrimaryLutPhoneTypeCd { get; set; }

    public string? PreparerAltPhone { get; set; }

    public string? PreparerAltLutPhoneTypeCd { get; set; }

    public string? PreparerEmail { get; set; }

    public bool? IsPreparerPreferredContactEmail { get; set; }

    public bool? IsPreparerPreferredContactPhone { get; set; }

    public bool? IsPreparerPreferredContactTty { get; set; }

    public bool? IsPreparerPreferredContactUsmail { get; set; }

    public string? PreparerPreferredContactMethodOther { get; set; }

    public bool? IsPreparerAddressPobox { get; set; }

    public int? PreparerAddressHouseNum { get; set; }

    public string? PreparerAddressHouseFracNum { get; set; }

    public string? PreparerAddressLutPreDirCd { get; set; }

    public string? PreparerAddressStreetName { get; set; }

    public string? PreparerAddressLutStreetTypeCd { get; set; }

    public string? PreparerAddressUnit { get; set; }

    public string? PreparerAddressCity { get; set; }

    public string? PreparerAddressLutStateCd { get; set; }

    public int? PreparerAddressZip { get; set; }

    public bool? IsIncidentSpecificLocation { get; set; }

    public bool? IsIncidentSameAddress { get; set; }

    public string? IncidentLocationName { get; set; }

    public int? IncidentAddressHouseNum { get; set; }

    public string? IncidentAddressHouseFracNum { get; set; }

    public string? IncidentAddressLutPreDirCd { get; set; }

    public string? IncidentAddressStreetName { get; set; }

    public string? IncidentAddressLutStreetTypeCd { get; set; }

    public string? IncidentAddressUnit { get; set; }

    public string? IncidentAddressCity { get; set; }

    public string? IncidentAddressLutStateCd { get; set; }

    public int? IncidentAddressZip { get; set; }

    public string? GrievanceDescription { get; set; }

    public bool? IsNoticeOfDeterminationeReceived { get; set; }

    public DateTime? NoticeOfDeterminationReceivedDate { get; set; }

    public bool? IsGrievanceAgainstOwnerPm { get; set; }

    public bool? IsGrievanceAgainstLahd { get; set; }

    public string? GrievanceDecisionDisagreeReason { get; set; }

    public int? LutGrievanceAppealSourceId { get; set; }

    public int? AcHpemployeeId { get; set; }

    public string? AcHpemployeeUserName { get; set; }

    public string? AcHpemployeeName { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowId { get; set; }

    public string? ReferralAgencyOther { get; set; }

    public string? MilestonesResolution { get; set; }

    public virtual LutGrievanceSource? LutGrievanceAppealSource { get; set; }

    public virtual ICollection<LutGrievanceReferralAgency> LutGrievanceReferralAgencies { get; set; } = new List<LutGrievanceReferralAgency>();
}
