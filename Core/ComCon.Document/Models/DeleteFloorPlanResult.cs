using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Document.Models
{
    public class DeleteFloorPlanResult
    {
        public bool Success { get; set; }
        public List<string> Links { get; set; }
    }

}
