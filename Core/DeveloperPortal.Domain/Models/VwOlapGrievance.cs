using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapGrievance
{
    public int? ProjectSiteId { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public DateTime? CloseDate { get; set; }

    public string? ServiceRequestNumber { get; set; }

    public string Status { get; set; } = null!;

    public string? FileNumber { get; set; }

    public string? PropertyName { get; set; }

    public string? HouseNum { get; set; }

    public string? HouseFracNum { get; set; }

    public string? PreDirCd { get; set; }

    public string? StreetName { get; set; }

    public string? StreetTypeCd { get; set; }

    public string? PostDirCd { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? ZipSuffix { get; set; }

    public int GrievanceId { get; set; }

    public string? GrievantFirstName { get; set; }

    public string? GrievantMiddleName { get; set; }

    public string? GrievantLastName { get; set; }

    public string? GrievantPrimaryPhone { get; set; }

    public string? GrievantPrimaryLutPhoneTypeCd { get; set; }

    public string? GrievantAltPhone { get; set; }

    public string? GrievantEmail { get; set; }

    public string? GrievantAltLutPhoneTypeCd { get; set; }

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

    public bool? IsNoticeToVacateReceived { get; set; }

    public bool? IsUnlawfulDetainerReceived { get; set; }

    public bool? IsSheriffsNoticeReceived { get; set; }

    public DateTime? NoticeToVacateReceivedDate { get; set; }

    public bool? IsGivenMoveOutDate { get; set; }

    public DateTime? RequiredMoveOutDate { get; set; }

    public bool? IsUnitDenied { get; set; }

    public bool? IsUnitVacant { get; set; }

    public bool? IsUnitAccessible { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public string? GrievanceSource { get; set; }

    public string? GrievanceReferralAgency { get; set; }

    public bool? IsGrievantSatisfied { get; set; }

    public string? MilestoneName { get; set; }

    public DateTime? FirstResponseDate { get; set; }

    public string? Action { get; set; }

    public bool? IsCovered { get; set; }
}
