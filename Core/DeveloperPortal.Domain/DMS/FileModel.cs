using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.DMS
{
    public class FileModel
    {
        public string? Name { get; set; }
        public string? Link { get; set; }
        public string? ID { get; set; }
       // public string? FileType { get; set; }

        public string? Category { get; set; }
        /// <summary>
        /// UploadedDate
        /// </summary>
        public DateTime UploadedDate { get; set; }
        /// <summary>
        /// ShareWithNAC
        /// </summary>
      //  public bool ShareWithNAC { get; set; }
        public string? Roles { get; set; }

        /// <summary>
        /// UploadedBy
        /// </summary>
        public string UploadedBy { get; set; } = string.Empty;
    }
}
