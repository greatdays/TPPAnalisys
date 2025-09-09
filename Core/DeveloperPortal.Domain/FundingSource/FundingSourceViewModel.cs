using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DeveloperPortal.Domain.FundingSource
{
    public class FundingSourcePageViewModel
    {
        public string CaseId { get; set; }
        public int ControlViewModelId { get; set; }
        public IEnumerable<FundingSourceViewModel> FundingSources { get; set; }
    }
    public class FundingSourceViewModel
    {

        public int FundingSourceId { get; set; }

        [Display(Name = "Funding Source")]
        public string? FundingSource { get; set; } // This is likely from a related table

        [Display(Name = "File Name")]
        public string FileName { get; set; } // This comes from the Document table

        public string Notes { get; set; }

        [Display(Name = "MU (%)")]
        public int? MU_Unit { get; set; }

        [Display(Name = "HV (%)")]
        public int? HV_Unit { get; set; }

        public int? DocumentID { get; set; }

        // Additional properties for auditing, if needed
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public string? CaseId { get; set; }
       

        public IFormFile? File { get; set; } // For file upload

        public string? Description { get; set; }

        public string? Link { get; set; }
        public string? FileSize { get; set; }

    }
}
