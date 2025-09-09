using System;

namespace ComCon.Document.Entity
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}
