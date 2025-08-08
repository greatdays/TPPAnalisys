using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.DMS
{
    public class DocumentModel
    {
        public int DocumentId { get; set; }
        public int FolderId { get; set; }
        public int CaseId { get; set; }

        public string Name { get; set; } = null!;

        public string FolderName { get; set; } = null!;

        public string Link { get; set; } = null!;

        public string FileSize { get; set; } = null!;

        public string? OtherDocumentType { get; set; }

        public DateTime? ExpDate { get; set; }

        public string? Comment { get; set; }

        public string? Attributes { get; set; }

        public int? DocumentTemplateId { get; set; }

        public string? DocumentNum { get; set; }

        public string? DocumentEntity { get; set; }

        public bool? IsCurrent { get; set; }

        public bool? IsDeleted { get; set; }

        public string? ServiceTrackingId { get; set; }

        /// <summary>
        /// Created By
        /// </summary>
        public string? CreatedBy { get; set; } = null!;

        /// <summary>
        /// Created On
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Modified By
        /// </summary>
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Modified On
        /// </summary>
        public DateTime? ModifiedOn { get; set; }
    }
}
