using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.DMS
{
    public class FolderDetails
    {
        public string? Name { get; set; }
        public string? Link { get; set; }
        public string? Id { get; set; }
        public List<FolderDetails>? Folders { get; set; }
        public List<FileModel>? Files { get; set; }
        public List<DocumentModel>? Documents { get; set; }
    }
}
