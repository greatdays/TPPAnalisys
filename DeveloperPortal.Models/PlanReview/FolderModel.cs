using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Models.PlanReview
{

    public class FolderModel
    {
        public string? Name { get; set; }
        public string? Link { get; set; }
        public string? ID { get; set; }
        public List<FolderModel> Folders { get; set; }
        public List<FileModel> Files { get; set; }

        public FolderModel()
        {
            Folders = new List<FolderModel>();
            Files = new List<FileModel>();
        }
    }
    public class FileModel
    {
        public string? Name { get; set; }
        public string? Link { get; set; }
        public string? ID { get; set; }
        public string? FileType { get; set; }
        /// <summary>
        /// UploadedDate
        /// </summary>
        public DateTime UploadedDate { get; set; }
        /// <summary>
        /// ShareWithNAC
        /// </summary>
        public bool ShareWithNAC { get; set; }

        /// <summary>
        /// UploadedBy
        /// </summary>
        public string UploadedBy { get; set; } = string.Empty;

    }

}
