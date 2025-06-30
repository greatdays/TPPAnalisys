using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DeveloperPortal.Areas.Document.Models
{


    public class DMSModel
    {

        public string ControlId { get; set; }
        public ControlViewModel ControlViewModel { get; set; }
        public List<DMSResult> SearchResults { get; set; } = new List<DMSResult>();
        public string ControlConfig { get; set; }
        public DMSModuleContext Context { get; set; }

        [Display(Name = "View Order")]
        public int? ViewOrder { get; set; }
        public string SectionTitle { get; set; }
        public List<string> RenderErrors { get; set; }
        public List<string> TabNames { get; set; }
        public bool? ShowFilter { get; set; } = true;
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
        public DataTable Data { get; set; }
        public List<int> ColumnOrder { get; set; }
        public string TabName { get; set; }
        public SelectList SubCategorySelectList { get; set; }
        public string ControlId { get; set; } 
    }

    public class ControlViewModel
    {
        public string ControlId { get; set; }
        public int CaseId { get; set; }
        public int ProjectSiteId { get; set; }
    }
}
