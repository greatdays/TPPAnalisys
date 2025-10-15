using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.Dashboard
{
    public sealed class ProjectProvisionRequest
    {
        // Required
        public string ProjectName { get; set; }
        public string PropertyName { get; set; }
        public string APN { get; set; }
        public string ProjectAddress { get; set; }
        public string UserName { get; set; }
        public int LutProjectFundId { get; set; }

        // Optional
        public string RefSiteAddressId { get; set; }
        public string SiteAddressID { get; set; }
        public string HouseNum { get; set; }
        public string HouseFracNum { get; set; }
        public string PreDirCd { get; set; }
        public string StreetName { get; set; }
        public string StreetTypeCd { get; set; }
        public string PostDirCd { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }


    public class ProjectProvision
    {
        /// <summary>
        /// Overall provisioning outcome.
        /// </summary>
        public ProvisionStatus Status { get; set; }

        /// <summary>
        /// Convenience flag for successful provisioning.
        /// </summary>
        public bool Success => Status == ProvisionStatus.Success;

        /// <summary>
        /// Site address ID in PCMS, existing or newly created.
        /// </summary>
        public string RefSiteAddressId { get; set; }

        /// <summary>
        /// Project ID created in PCMS.
        /// </summary>
        public int RefProjectId { get; set; }

        /// <summary>
        /// ProjectSite ID created in PCMS.
        /// </summary>
        public int RefProjectSiteId { get; set; }

        /// <summary>
        /// FileGroup (TEMP####) assigned to the new project.
        /// </summary>
        public string FileGroup { get; set; }

        /// <summary>
        /// Optional diagnostics for logging or UI feedback.
        /// </summary>
        public string ErrorCode { get; set; }        // e.g., SqlException.Number or custom code
        public string ErrorMessage { get; set; }     // friendly message
        public string CorrelationId { get; set; }    // if you pass a trace/correlation ID through

        public override string ToString()
        {
            if (Success)
                return $"Success: ProjectID={RefProjectId}, SiteID={RefProjectSiteId}, FileGroup={FileGroup}";
            else
                return $"Error ({Status}): {ErrorMessage ?? "No details"} [Code={ErrorCode}]";
        }
    }

    public enum ProvisionStatus
    {
        Success,
        ValidationError,
        Conflict,
        SqlError,
        RetryableError,
        UnknownError
    }
}
