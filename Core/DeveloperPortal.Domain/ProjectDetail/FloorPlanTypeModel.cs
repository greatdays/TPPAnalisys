using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeveloperPortal.Domain.ProjectDetail
{
    public class FloorPlanFileModel
    {
        public int DocID { get; set; }
        public string Name { get; set; }
        public string FileSize { get; set; }
        public string URl { get; set; }
    }


    public class FloorPlanTypeModel
    {
        public int ProjectDetailId { get; set; }
        public int FloorPlanTypeID { get; set; }
        public string Name { get; set; }
        public int ProjectSiteID { get; set; }
        public int StructureID { get; set; }
        public double? SquareFeet { get; set; }
        public int LutTotalBedroomID { get; set; }
        public int LutTotalBathroomID { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int ProjectID { get; set; }
        public int PropsnapShotID { get; set; }
        public int CaseId { get; set; }
        public string BathroomTypes { get; set; }
        public string BathroomOption { get; set; }
        public string GroupBathroomTypes { get; set; }
        public string GroupBathroomOption { get; set; }
        public string UserName { get; set; }
        public List<FloorPlanBathroomTypeModel> FloorPlanBathroomType { get; set; }

        public List<LutBathroomTypes> LutBathroomType { get; set; }
        public List<SelectListItem> LutFloorBathrommOptions { get; set; }
        public List<SelectListItem> SiteList { get; set; }
        public List<SelectListItem> StructureList { get; set; }
        public List<LutTotalBedrooms> LutTotalBedrooms { get; set; }
        public List<LutTotalBathrooms> LutTotalBathrooms { get; set; }
        public List<LutTotalBathroomTypeOption> LutTotalBathroomTypeOption { get; set; }
        public List<LutTotalBathroomsFloorType> LutTotalBathroomsFloorType { get; set; }
        public List<FloorPlanInformation> FloorPlanInformation { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<FloorPlanFileModel> File { get; set; }
        public bool isUsed { get; set; }
        public string[] SupportedFileTypes { get; set; } = new[] { "gif", "jpeg", "jpg", "pdf", "png" };
    }

    public class LutTotalBathroomsFloorType
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class FloorPlanBathroomTypeModel
    {
        public int FloorPlanBathroomTypeID { get; set; }
        public int FloorPlanTypeID { get; set; }
        public int LutBathroomTypeID { get; set; }
        public int? LutBathroomTypeOptionID { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class LutTotalBathrooms
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class LutTotalBedrooms
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class LutBathroomTypes
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class LutTotalBathroomTypeOption
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class FloorPlanInformation
    {
        public int FloorPlanTypeID { get; set; }
        public string Name { get; set; }
        public int ProjectSiteID { get; set; }
        public int StructureID { get; set; }
        public double? SquareFeet { get; set; }
        public int LutTotalBedroomID { get; set; }
        public int LutTotalBathroomID { get; set; }
        public int ProjectID { get; set; }
        public int PropsnapShotID { get; set; }
    }
}
