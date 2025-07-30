using ComCon.DataAccess.Attributes;
using ComCon.PropertySnapshot.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeveloperPortal.Domain.ProjectDetail
{
    public class BuildingModel
    {
        [Required]
        [Display(Name = "Building Name")]
        public string BuildingName { get; set; }
        [Required]
        [Display(Name = "Building Address")]
        public int? BuildingAddressID { get; set; }
        [Required]
        public int siteAddressId { get; set; }
        
        [Required]
        [Display(Name = "Number of Units")]
        public int? NumberofUnits { get; set; }
        public string BuildingAddress { get; set; }
       
        public int BuildingID { get; set; }
        
        public string BuildingFileNumber { get; set; }
        public List<SelectListItem> BuildingAddressList { get; set; } = new List<SelectListItem>();
        [Required]
        public int? ProjectSiteId { get; set; }
        public int ProjectId { get; set; }
        public int APNId { get; set; }
        public List<UnitModel> UnitModel { get; set; }
        public List<SelectListItem> LutStructureType { get; set; } = new List<SelectListItem>();
        public int LutStructureTypeId { get; set; }
        public string Username { get; set; }
        public string StructureApn { get; set; }
        public List<SelectListItem> LUTUnitTypeID { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> LUTTotalBedroomID { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> LutFHAStandards { get; set; } = new List<SelectListItem>();
        public bool IsAddAddress { get; set; }
        [Display(Name = "HouseNum")]
        
        public string HouseNum { get; set; }
        [Display(Name = "House Fraction Number")]
        public string HouseFracNum { get; set; }
        [Display(Name = "Street Direction")]
        public string LutPreDirCd { get; set; }
        [Required]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        [Display(Name = "Street Type")]
        public string LutStreetTypeCD { get; set; }
       
           public string PostDirCd { get; set; }
        [Display(Name = "City")]
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string LutStateCD { get; set; }
        public List<SelectListItem> LutStateCDListItems { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> LutPreDirCdListItems { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> LutStreetTypeListItems { get; set; } = new List<SelectListItem>();
        [Required]
        [Display(Name = "Zip Code")]
        
        public string Zip { get; set; }
        public string ZipSuffix { get; set; }
        public int ServiceRequestId { get; set; }
        public int CaseId { get; set; }
        public int? TotalProjectUnit { get; set; }
        public int? SortOrder { get; set; }
        public string CaseType { get; set; }
        public string SelectedSiteId { get; set; }

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
