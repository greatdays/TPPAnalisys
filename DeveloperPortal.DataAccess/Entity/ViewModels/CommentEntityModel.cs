using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DeveloperPortal.DataAccess.Entity.Data.AAHREntities;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Repository.Interface;

namespace DeveloperPortal.DataAccess.Entity.ViewModels
{
    [MetadataType(typeof(CommentMD))]
    public partial class CommentEntityModel : IAuditable
    {
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ModifiedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public partial class CommentMD
        {
            public int CommentId { get; set; }
            public string? CommentText { get; set; }
            public Nullable<bool> IsInternal { get; set; }
            public Nullable<bool> IsWorklog { get; set; }
            public string? JSONAttribute { get; set; }
            public Nullable<bool> IsDeleted { get; set; }
        }
    }
}
