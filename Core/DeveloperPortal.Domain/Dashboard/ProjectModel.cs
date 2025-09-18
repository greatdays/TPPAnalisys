using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.Dashboard
{
    public class ProjectModel
    {

        public string? SiteAddressID { get; set; }
        public string? ProjectAddress { get; set; }
        public string? ProjectName { get; set; }
        public string? PropertyNameInput { get; set; }
        public string? APN { get; set; }

    }
}
