
using System;
using System.ComponentModel.DataAnnotations;

namespace ComCon.Document.Entity
{
    [MetadataType(typeof(DocumentMD))]
    public partial class Document: IAuditable
    {
        public class DocumentMD
        {
            public int DocumentID { get; set; }          
            public string Name { get; set; }
            public string Link { get; set; }
            public string FileSize { get; set; }
            public string OtherDocumentType { get; set; }
            public Nullable<System.DateTime> ExpDate { get; set; }
            public string Comment { get; set; }
            public string Attributes { get; set; }
            public Nullable<int> DocumentTemplateID { get; set; }
            public string DocumentNum { get; set; }
            public string DocumentEntity { get; set; }
            public Nullable<bool> IsCurrent { get; set; }
            public Nullable<bool> IsDeleted { get; set; }
            public string ServiceTrackingID { get; set; }            
        }

    }
}
