using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DeveloperPortal.DataAccess.Entity.ViewModels
{
    public class CommentModel
    {
        [Required]
        public string RefId { get; set; }
        [Required]
        public ReferenceType RefType { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Comment { get; set; }
        public int CommentId { get; set; }
        public bool IsWorklog { get; set; }
        public bool IsInternal { get; set; }
        public string JSONAttribute { get; set; }
        public DateTime CommentDatetime { get; set; }
        public string CommentCreatedBy { get; set; }
        public string CommentEditedBy { get; set; }
        public string Role { get; set; }

        public void SaveComment()
        {
            using (AAHREntities db = new AAHREntities())
            {
                db.Comments.Add(new DeveloperPortal.DataAccess.Entity.Models.Generated.Comment
                {
                    CommentText = Comment,
                    IsInternal = IsInternal,
                    IsWorklog = IsWorklog,
                    JSONAttribute = JSONAttribute,
                    IsDeleted = false,
                    Role = Role,
                    AssnComment = new AssnComment { ReferenceID = RefId, ReferenceType = RefType.ToString() }
                });
                db.SaveChanges(UserName);
            }
        }

        public static List<CommentModel> GetComment(List<CommentReference> referenceList, bool IsWorklog = false, bool all = true, bool IsInternal = false, string jsonAttribute = "")
        {
            using (AAHREntities db = new AAHREntities())
            {
                List<CommentModel> query = new List<CommentModel>();
                foreach (var item in referenceList)
                {
                    var List = db.AssnComments.Where(m => m.ReferenceID == item.ReferenceID && m.ReferenceType == item.ReferenceType && m.Comment.IsDeleted == false && m.Comment.IsWorklog == IsWorklog).Select(x => new CommentModel
                    {
                        CommentId = x.CommentID,
                        Comment = x.Comment.CommentText,
                        IsWorklog = x.Comment.IsWorklog.HasValue ? x.Comment.IsWorklog.Value : false,
                        IsInternal = x.Comment.IsInternal.HasValue ? x.Comment.IsInternal.Value : false,
                        JSONAttribute = x.Comment.JSONAttribute,
                        CommentDatetime = (DateTime)x.Comment.ModifiedOn,
                        CommentCreatedBy = x.Comment.CreatedBy,
                        CommentEditedBy = x.Comment.ModifiedBy,
                        Role = x.Comment.Role
                    }).ToList();

                    query.AddRange(List);
                }
                if (!IsWorklog && !all && !IsInternal)
                {
                    return query.Where(m => m.IsWorklog == false).ToList();
                }
                else if (IsWorklog && !all)
                {
                    return query.Where(m => m.IsWorklog == true).ToList();
                }
                else if (!IsWorklog && IsInternal)
                {
                    return query.Where(m => m.IsWorklog == false && m.IsInternal == true).ToList();
                }
                else if (all)
                {
                    return query.ToList();
                }


                else if (!IsWorklog && !all && IsInternal && jsonAttribute != string.Empty)
                {
                    return db.vwComments.Where(w => referenceList.Any(y => y.ReferenceID == w.ReferenceID && y.ReferenceType.ToString() == w.ReferenceType) && w.IsWorklog != true &&
                                            w.IsDeleted == false && w.JSONAttribute == jsonAttribute)
                                           .Select(s => new CommentModel
                                           {
                                               CommentId = s.CommentID,
                                               RefId = s.ReferenceID,
                                               Comment = s.CommentText,
                                               IsInternal = s.IsInternal.HasValue ? s.IsInternal.Value : false,
                                               CommentCreatedBy = s.CreatedUserName,
                                               CommentDatetime = s.CreatedOn,
                                           }).ToList();

                }

            }
            return new List<CommentModel>();
        }

        public static void UpdateComment(int commentId, string commentText, string username, string roleName = null, bool isInternal = false)
        {
            using (AAHREntities db = new AAHREntities())
            {
                DeveloperPortal.DataAccess.Entity.Models.Generated.Comment comment = db.Comments.Find(commentId);
                comment.CommentText = commentText;
                comment.Role = roleName;
                comment.IsInternal = isInternal;
                db.SaveChanges(username);
            }
        }

        public static void DeleteAllComment(string refId, ReferenceType refType, string username)
        {
            using (AAHREntities db = new AAHREntities())
            {
                foreach (AssnComment item in db.AssnComments.Where(m => m.ReferenceID == refId && m.ReferenceType == refType.ToString()))
                {
                    item.Comment.IsDeleted = true;
                }

                db.SaveChanges(username);
            }
        }

        public static void DeleteComment(int commentId, string username)
        {
            using (AAHREntities db = new AAHREntities())
            {
                DeveloperPortal.DataAccess.Entity.Models.Generated.Comment comment = db.Comments.Find(commentId);
                comment.IsDeleted = true;
                db.SaveChanges(username);
            }
        }

        public static DeveloperPortal.DataAccess.Entity.Models.Generated.Comment FindCommentByRefID(string referenceID, string referenceType)
        {
            using (var db = new AAHREntities())
            {
                var assnComments = db.AssnComments.Where(x => x.ReferenceID == referenceID && x.ReferenceType == referenceType && x.Comment.IsDeleted == false).OrderByDescending(y => y.CommentID).FirstOrDefault();
                if (assnComments != null)
                {
                    return db.Comments.FirstOrDefault(x => x.CommentID == assnComments.CommentID);
                }

            }
            return null;
        }

        public class CommentReference
        {
            public string ReferenceID { get; set; }
            public string ReferenceType { get; set; }
        }

        public enum ReferenceType
        {
            Case,
            CaseLog,
            ServiceRequest,
            Inspection,
            Violation,
            Notice,
            Contact,
            PropSnapshot,
            GMCheckList
        }
    }
}
