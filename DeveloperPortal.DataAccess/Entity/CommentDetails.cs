using DeveloperPortal.DataAccess.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DeveloperPortal.DataAccess.Entity.ViewModels.CommentModel;

namespace DeveloperPortal.DataAccess.Entity
{
    public class CommentDetails
    {
        public static void SaveComment(string refId, ReferenceType refType, string commentText, string userName, string JsonAttribute = null, bool IsWorklog = false, bool IsInternal = false, string roleName = null)
        {
            CommentModel model = new CommentModel
            {
                RefId = refId,
                RefType = refType,
                UserName = userName,
                Comment = commentText,
                IsWorklog = IsWorklog,
                IsInternal = IsInternal,
                JSONAttribute = JsonAttribute,
                Role = roleName
            };
            model.SaveComment();
        }

        public static List<CommentModel> GetComment(string refId, ReferenceType refType, bool IsWorklog = false, bool all = true, bool IsInternal = false, string jsonAttribute = "")
        {
            List<CommentReference> referenceList = new List<CommentReference>
            {
                new CommentReference
                {
                        ReferenceId = refId,
                        ReferenceType = refType.ToString()
                }
            };
            return CommentModel.GetComment(referenceList, IsWorklog, all, IsInternal, jsonAttribute);
        }

        public static void UpdateComment(int CommentId, string commentText, string username, string roleName = null, bool isInternal = false)
        {
            CommentModel.UpdateComment(CommentId, commentText, username, roleName, isInternal);
        }

        public static void DeleteAllComment(string refId, ReferenceType refType, string username)
        {
            CommentModel.DeleteAllComment(refId, refType, username);
        }

        public static void DeleteComment(int CommentId, string username)
        {
            CommentModel.DeleteComment(CommentId, username);
        }
    }
}
