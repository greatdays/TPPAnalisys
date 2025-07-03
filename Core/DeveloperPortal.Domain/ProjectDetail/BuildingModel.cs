using ComCon.DataAccess.Attributes;
using ComCon.PropertySnapshot.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.ProjectDetail
{
    public class BuildingModel
    {
        //[Required(ErrorMessageResourceType = typeof(ComplianceMatrixResource), ErrorMessageResourceName = "msgBuildingNameReq")]
        //[Display(ResourceType = typeof(ComplianceMatrixResource), Name = "lblBuildingName")]
        public string BuildingName { get; set; }
        //[Required(ErrorMessageResourceType = typeof(ComplianceMatrixResource), ErrorMessageResourceName = "msgBuildingAddressReq")]
        //[Display(ResourceType = typeof(ComplianceMatrixResource), Name = "lblBuildingAddress")]
        public int? BuildingAddressID { get; set; }
        public int siteAddressId { get; set; }
        
        //[RequiredIf("NumberOfUnitRequired", "Required", ErrorMessageResourceType = typeof(ComplianceMatrixResource), ErrorMessageResourceName = "msgNumberofUnitsReq")]
        //[Display(ResourceType = typeof(ComplianceMatrixResource), Name = "lblNumberofUnits")]
        public int? NumberofUnits { get; set; }
        public string BuildingAddress { get; set; }
        public int BuildingID { get; set; }
        public string BuildingFileNumber { get; set; }
        public List<SelectListItem> BuildingAddressList { get; set; }
        public int? ProjectSiteId { get; set; }
        public int ProjectId { get; set; }
        public int APNId { get; set; }
        public List<UnitModel> UnitModel { get; set; }
        //public StructureAttribute StructureAttribute { get; set; }
        public List<SelectListItem> LutStructureType { get; set; }
        public int LutStructureTypeId { get; set; }
        public string Username { get; set; }
        //public List<StructureUnitInformation> StructureUnitInformation { get; set; }
        //public List<StructureAssociatedAssessorsParcelNumber> StructureAssociatedAssessorsParcelNumber { get; set; }
        public string StructureApn { get; set; }
        public List<SelectListItem> LUTUnitTypeID { get; set; }
        public List<SelectListItem> LUTTotalBedroomID { get; set; }
        public List<SelectListItem> LutFHAStandards { get; set; }
        public bool IsAddAddress { get; set; }
        public string HouseNum { get; set; }
        public string HouseFracNum { get; set; }
        public string LutPreDirCd { get; set; }
       // public List<LutPreDir> LutPreDirCdList { get; set; }
        public string StreetName { get; set; }
        public string LutStreetTypeCD { get; set; }
       // public List<LutStreetType> LutStreetTypeList { get; set; }
        public string PostDirCd { get; set; }
        public string City { get; set; }
        public string LutStateCD { get; set; }
        //public List<LutState> LutStateCDList { get; set; }
        public List<SelectListItem> LutStateCDListItems { get; set; }
        public List<SelectListItem> LutPreDirCdListItems { get; set; }
        public List<SelectListItem> LutStreetTypeListItems { get; set; }
        public string Zip { get; set; }
        public string ZipSuffix { get; set; }
        public int ServiceRequestId { get; set; }
        public int CaseId { get; set; }
        public int? TotalProjectUnit { get; set; }
        public int? SortOrder { get; set; }
        public string CaseType { get; set; }

        [Display(Name = "Building Description")]
        public string BuildingDescription { get; set; }

        [Display(Name = "Non-Residential")]
        public Nullable<bool> IsNonResidential { get; set; }

        public string NumberOfUnitRequired { get; set; }
        public List<SelectListItem> SiteList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> SiteCaseIdList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> BuildingDescriptionList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> LutTypeofProjectList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> LutApplicableAccessibilityStandardList { get; set; } = new List<SelectListItem>();
    }
}
