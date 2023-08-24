using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Models.Account
{
    public class PropertyAdvancedSearchModel
    {
        public string AcHPFileNumber { get; set; }
        public string ProjectName { get; set; }
        public string PropertyName { get; set; }
        public string AcHPPropertyAddress { get; set; }
        public string SettlementAddress { get; set; }
        public string HIMS { get; set; }
        public string APNNumber { get; set; }
        public int? ProjectYearStart { get; set; }
        public int? ProjectYearEnd { get; set; }
        public string StrAPNNumber { get; set; }
        public string StrProjectYearStart { get; set; }
        public string StrProjectYearEnd { get; set; }
        public int? TypeOfProjectId { get; set; }
        public int? RegionId { get; set; }
        public string RegionName { get; set; }
        public int? NeighborhoodId { get; set; }
        public int? CouncilDistrict { get; set; }
        public dynamic CouncilDistlist { get; set; }
        public string CouncilDistrictName { get; set; }
        public string OwnersContactName { get; set; }
        public string OwnersCompanyName { get; set; }
        public string OwnersEmailAddress { get; set; }
        public string mgmtContactName { get; set; }
        public string mgmtCompanyName { get; set; }
        public string mgmtEmailAddress { get; set; }
        public int? CaseTypeId { get; set; }
        public string ServiceRequestNumber { get; set; }
        public dynamic CaseTypeIDlst { get; set; }
        public dynamic RegionIdList { get; set; }
        public dynamic neighbourhoodIdlist { get; set; }
        public string Url { get; set; }
        public short? SettlementTotalUnit { get; set; }
        public short? SettlementMobilityUnit { get; set; }
        public short? SettlementSensoryUnit { get; set; }
        public short? SettlementTotalAccessibleUnit { get; set; }
        public string Attributes { get; set; }
        public string jwtToken { get; set; }
        public List<PropertyAdvancedSearchResultModel> propertySearchResult { get; set; } = new List<PropertyAdvancedSearchResultModel>();
        // public List<ProjectSiteModel> projectSiteModel;
    }

    public class PropertyAdvancedSearchResultModel
    {
        public string AcHPFileSiteNumber { get; set; }
        public string SiteAddress { get; set; }
        public string OwnerCompanyName { get; set; }
        public string PMName { get; set; }
        public bool IsCASPReportAvailable { get; set; }
        public bool IsSelected { get; set; }
        public int CaseTypeID { get; set; }
        public string CaseType { get; set; }

        public int ProjectSiteID { get; set; }
        public int RefProjectSiteID { get; set; }
        public int ProjectID { get; set; }
        public int? SiteAddressID { get; set; }
        public string PrimaryAPN { get; set; }
        public string HIMSNumber { get; set; }
        public int? HIMSProjUniqueId { get; set; }
        public int? RegionID { get; set; }
        public string RegionName { get; set; }
        public int? NeighborhoodID { get; set; }
        public string NeighborhoodName { get; set; }
        public string CouncilDistrict { get; set; }
        public string Source { get; set; }
        public int? SourceRefID { get; set; }
        public string Status { get; set; }
        public string Attributes { get; set; }
        public bool IsDeleted { get; set; }

        public bool? IsCovered { get; set; }
        public int? TotalSiteUnit { get; set; }
        public int? MobilityUnit { get; set; }
        public int? SensoryUnit { get; set; }
        public decimal? MobilityRatio { get; set; }
        public decimal? HVRatio { get; set; }
        public string CESType { get; set; }
        public string ProjectName { get; set; }
        public string PropertyName { get; set; }

        public int PropSnapShotID { get; set; }
        public string Buildings { get; set; }
        public string Units { get; set; }
        public string NumberOfViolations { get; set; }

        public string HousingRegistryStatus { get; set; }
        public int? PropertyListingCaseID { get; set; }
        public string PropertyListingURL { get; set; }
        public string PropertyDetailsURL { get; set; }
        public string IsListed { get; set; }
    }


}
