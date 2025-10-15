using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.ProjectDetail
{
    public class SiteProvisionRequest
    {
        // Required
        [Range(1, int.MaxValue)]
        public int PcmsProjectId { get; set; }

        [Required, StringLength(100)]
        public string PrimaryAPN { get; set; }

        [Required, StringLength(50)]
        public string FileNumber { get; set; }

        [Required, StringLength(200)]
        public string PropertyName { get; set; }

        [Required, StringLength(128)]
        public string UserName { get; set; }

        // Optional
        public int? ExistingPcmsSiteAddressId { get; set; }

        [StringLength(500)]
        public string ProjectAddress { get; set; }

        // Address parts (used when creating SiteAddress)
        [StringLength(10)] public string HouseNum { get; set; }
        [StringLength(10)] public string HouseFracNum { get; set; }
        [StringLength(2)] public string PreDirCd { get; set; }
        [StringLength(100)] public string StreetName { get; set; }
        [StringLength(10)] public string StreetTypeCd { get; set; }
        [StringLength(2)] public string PostDirCd { get; set; }
        [StringLength(100)] public string City { get; set; }
        [StringLength(10)] public string Zip { get; set; }

        public SiteProvisionRequest()
        {
            PrimaryAPN = string.Empty;
            FileNumber = string.Empty;
            PropertyName = string.Empty;
            UserName = string.Empty;
            ProjectAddress = string.Empty;
            HouseNum = string.Empty;
            HouseFracNum = string.Empty;
            PreDirCd = string.Empty;
            StreetName = string.Empty;
            StreetTypeCd = string.Empty;
            PostDirCd = string.Empty;
            City = string.Empty;
            Zip = string.Empty;
        }
    }


    public class SiteProvisionResponse
    {
        public int SiteAddressId { get; set; }
        public int ProjectSiteId { get; set; }
        public string FullAddress { get; set; }
        public string CorrelationId { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public string FileNumber { get; set; }

        public SiteProvisionResponse()
        {
            FullAddress = string.Empty;
            CorrelationId = string.Empty;
            ErrorCode = string.Empty;
            ErrorMessage = string.Empty;
        }
    }
}
