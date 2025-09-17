using DeveloperPortal.Models.PlanReview;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.DMS
{
    public class DMSModel
    {

        public string ControlId { get; set; }
        public ControlViewModel ControlViewModel { get; set; }
        public List<DMSResult> SearchResults { get; set; } = new List<DMSResult>();
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectFolderName { get; set; }
        public List<string> RenderErrors { get; set; }

        public string SectionTitle { get; set; }
        public bool? ShowFilter { get; set; } = true;
        public List<string> TabNames { get; set; }
        public FolderDetails FolderModel { get; set; }
        public FolderModel DMSFolders { get; set; }//separate needed to create
        public DMSModel()
        {
            //Context = DMSModuleContext.Unknown;
            RenderErrors = new List<string>();
            SearchResults = new List<DMSResult>();
            TabNames = new List<string>();
        }
    }

    public enum DMSModuleContext
    {
        Unknown,
        NewConstructionRehabProject,
        NewConstructionRehabProperty,
        ExistingProject,
        ExistingProperty,
        RetrofitProject,
        RetrofitProperty,
        ConstructionSite,
        Grievance,
        PolicyProject,
        PolicySite,
        Training,
        EnforcementProject,
        GrievanceAppeal
    }

    public class DMSResult
    {
        public string CaseId { get; set; }
        public string ControlContext { get; set; }
        public string ControlId { get; set; }
        public List<int> ColumnOrder { get; set; }

        /// <summary>
        /// Changes the name of a column header.
        /// i.e. Used when Sub Category data is displayed, but the column header should say Category
        /// </summary>
        public Dictionary<int, string> ColumnRenames { get; set; }
        public DataTable Data { get; set; }
        /// <summary>
        /// Within the total results, what index is this result?  Needed for data refresh
        /// </summary>
        public int DataIndex { get; set; }

        public bool? DisableStatusDropdown { get; set; }

        /// <summary>
        /// This is the data grid of document results serialized to Json.
        /// It is then used when editing to pull in the values of the document metadata being edited so that there is no
        /// Ajax call to get these values.
        /// </summary>
        public string JsonResult { get; set; }
        public bool? ShowApproval { get; set; }
        public bool? ShowEdit { get; set; }
        public bool? ShowAudienceDropdown { get; set; }
        public SelectList StatusSelectList { get; set; }
        public SelectList AudienceSelectList { get; set; }

        [Display(Name = "View Order")]
        public int? ViewOrder { get; set; }
        public List<SelectListItem> SubCategorySelectList { get; set; }

        [Display(Name = "Supported File Types")]
        public string[] SupportedFileTypes { get; } = new[] { "doc", "docx", "gif", "jpeg", "jpg", "pdf", "png", "ppt", "pptx", "txt", "xls", "xlsx" };

        [Display(Name = "Supported Image Types")]
        public string[] SupportedImageTypes { get; } = new[] { "gif", "jpeg", "jpg", "png" };

        /// <summary>
        /// This is the max byte size of a file before it re-routes to the large file processor.
        /// Anything below this amount (or null) will be sent directly to the DMS server and block the UI.
        /// </summary>
        [Display(Name = "LargeFileThreshold (bytes)")]
        public int? LargeFileThreshold { get; set; }

        [Display(Name = "Maximum Number of Files")]
        public int MaxNumberOfFiles { get; } = 20;

        [Display(Name = "Maximum File Size")]
        public int MaxFileSize { get; set; }

        [Display(Name = "Received Date")]
        [Required]
        public DateTime ReceivedDate { get; set; } = DateTime.Today;

        [Display(Name = "Primary Key")]
        [Required]
        public string PrimaryKey { get; set; }

        [Required]
        public string Category { get; set; }

        [Display(Name = "Category")]
        [Required]
        public string SubCategory { get; set; }

        public string Status { get; set; }

        public string Audience { get; set; }

        [Display(Name = "HIMS #")]
        public string HIMSNumber { get; set; }

        [Display(Name = "AcHP #")]
        public string AcHPNumber { get; set; }

        public string AchpProjectId { get; set; }
        public string AchpPropertyId { get; set; }

        public string APN { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "File Description")]
        //[StringLength(1000, ErrorMessageResourceType = typeof(Resources.Grievance), ErrorMessageResourceName = "MaxthousandMsg")]
        public string Description { get; set; }

        [Display(Name = "System Description")]
        public string SystemDescription { get; set; }

        [Display(Name = "Comments")]
        // [StringLength(1000, ErrorMessageResourceType = typeof(Resources.Grievance), ErrorMessageResourceName = "MaxthousandMsg")]
        public string Comments { get; set; }

        [Display(Name = "Files")]
        [Required]
        // public List<HttpPostedFileBase> Files { get; set; }

        public string ProjectId { get; set; }
        public string PropertyId { get; set; }

        public bool? ShowFilter { get; set; }

        /// <summary>
        /// This is what's passed by ComCon as the control is rendered.
        /// </summary>
        public string ControlConfig { get; set; }

        public DMSResult()
        {
            ControlContext = "";
            ControlConfig = null;
            DisableStatusDropdown = null;
            MaxFileSize = 50;
            ShowAudienceDropdown = true;
        }

    }

    public class ControlViewModel
    {
        public string ControlId { get; set; }
        public int CaseId { get; set; }
        public int ProjectSiteId { get; set; }
    }
}
