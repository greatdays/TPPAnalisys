using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.Dashboard
{
    public class APNSearchSiteAddress
    {
        
        public int SiteAddressID { get; set; }
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
        public string? FullAddress { get; set; }
        public bool IsDeleted { get; set; }
        public int HouseID { get; set; }
        public string? APN { get; set; }


    }
}
