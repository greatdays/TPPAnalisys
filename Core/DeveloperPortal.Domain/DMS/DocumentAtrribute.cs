using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.DMS
{
    public class DocumentAttributeModel
    {
        public List<string> Types { get; set; }

        public List<string> Groups { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
