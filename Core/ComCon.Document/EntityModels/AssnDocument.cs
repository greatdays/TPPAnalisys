
using System;
using System.ComponentModel.DataAnnotations;

namespace ComCon.Document.Entity
{
    [MetadataType(typeof(AssnDocumentMD))]
    public partial class AssnDocument: IAuditable
    {
        public class AssnDocumentMD
        {
            public int AssnDocumentID { get; set; }
            public int DocumentID { get; set; }
            public string ReferenceID { get; set; }
            public string ReferenceType { get; set; }
            public string AssociationType { get; set; }
            public Nullable<System.DateTime> AssociatedFrom { get; set; }
            public Nullable<System.DateTime> AssociatedTo { get; set; }         
        }

    }
}
