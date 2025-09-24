using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DeveloperPortal.DataAccess.Common;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Models.PlanReview;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static DeveloperPortal.DataAccess.Entity.Models.Generated.Case;
using static DeveloperPortal.DataAccess.Entity.ViewModels.CommentModel;


namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AAHREntities _context;
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;

        public DocumentRepository(AAHREntities context, IStoredProcedureExecutor storedProcedureExecutor)
        {
            _context = context;
            _storedProcedureExecutor = storedProcedureExecutor;
        }

        public async Task<bool> SaveDocument(DocumentModel documentModel)
        {
            if (documentModel.DocumentId > 0)
            {
                var document = _context.Documents.FirstOrDefault(x => x.DocumentId == documentModel.DocumentId);
                if (document != null)
                {
                    document.Name = documentModel.Name;
                    document.Link = documentModel.Link;
                    document.FileSize = documentModel.FileSize;
                    document.DocumentCategoryId = documentModel.DocumentCategoryId;
                    document.Comment = documentModel.Comment;
                    document.Attributes = documentModel.Attributes;
                    document.CreatedBy = documentModel.CreatedBy;
                    document.CreatedOn = DateTime.Now;
                    document.ModifiedBy = documentModel.CreatedBy;
                    document.ModifiedOn = DateTime.Now;
                    _context.SaveChanges(documentModel.CreatedBy);
                    return true;
                }
            }
            else
            {
                var document = new Document
                {
                    Name = documentModel.Name,
                    Link = documentModel.Link,
                    FileSize = documentModel.FileSize,
                    Comment = documentModel.Comment,
                    Attributes = documentModel.Attributes,
                    DocumentCategoryId = documentModel.DocumentCategoryId,
                    CreatedBy = documentModel.CreatedBy,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = documentModel.CreatedBy,
                    ModifiedOn = DateTime.Now,
                    IsDeleted = false,
                    AssnDocuments =
                    {
                        new AssnDocument
                        {
                            ReferenceId = documentModel.CaseId.ToString(),
                            ReferenceType = ReferenceType.Case.ToString(),
                            CreatedBy =  documentModel.CreatedBy,
                            CreatedOn =  DateTime.Now,
                            ModifiedBy =  documentModel.CreatedBy,
                            ModifiedOn =  DateTime.Now
                        }
                    }
                    //},
                    //AssnFolderDocuments =
                    //{
                    //    new AssnFolderDocument
                    //    {
                    //        FolderId = documentModel?.FolderId,
                    //        CreatedBy =  documentModel.CreatedBy,
                    //        CreatedOn =  DateTime.Now,
                    //        ModifiedBy =  documentModel.CreatedBy,
                    //        ModifiedOn =  DateTime.Now
                    //    }
                    //}
                };
                _context.Documents.Add(document);
                await _context.SaveChangesAsync();
                if (document.DocumentId > 0)
                {
                    UpdateDocumentFolderDetail(new FolderModel() { ProjectId = documentModel.CaseId, Link = documentModel.Link }, "Case", documentModel.CreatedBy);
                    return true;
                }
                else
                {
                    return false;
                }
                   
            }
            return true;
        }
        public async Task<bool> DeleteDocument(int id)
        {
            var deleteDocument = _context.Documents.FirstOrDefault(fs => fs.DocumentId == id);

            if (deleteDocument != null)
            {
                deleteDocument.IsDeleted = true;

                deleteDocument.ModifiedOn = DateTime.Now; // optional, if you have a DeletedDate column

                _context.Documents.Update(deleteDocument);
                _context.SaveChanges();

                return true;

            }
            else
            {
                return false;
            }
        }
        private FolderModel UpdateDocumentFolderDetail(FolderModel folderModel, string refenceType, string username)
        {

            if (folderModel == null)
            {
                return folderModel;
            }
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter() { ParameterName = "@RefenceId", Value = folderModel.ProjectId },
                new SqlParameter() { ParameterName = "@RefenceType", Value = refenceType},
                new SqlParameter() { ParameterName = "@FolderId", Value =  folderModel.FolderId },
                new SqlParameter() { ParameterName = "@Link", Value =  folderModel.Link },
                new SqlParameter() { ParameterName = "@Username", Value = username }
            };
            using (var dataTableUnits = _storedProcedureExecutor.ExecuteStoreProcedure("DMS.uspUpdateDocumentFolderDetailForACHP", sqlParameters))
            {
                var planReviewDocumentList = dataTableUnits.ConvertDataTable<FolderModel>();
                if (planReviewDocumentList != null && planReviewDocumentList.Count > 0)
                {
                    folderModel = planReviewDocumentList[0];
                }
            }

            return folderModel;
        }
        public async Task<bool> SaveFolder(FolderModel folderModel,string userName)
        {
          
            if (folderModel.FolderId > 0)
            {
                var folder = _context.Folders.FirstOrDefault(x => x.FolderId == folderModel.FolderId);
                if (folder != null)
                {
                    folder.Name = folderModel.Name;
                    folder.Comment = folderModel.Comment;
                    folder.Attributes = folderModel.Attributes;
                    folder.ModifiedBy = userName;
                    folder.ModifiedOn = DateTime.Now;
                    _context.SaveChanges(userName);
                }
            }
            else
            {
                var folder = new Folder
                {
                    Name = folderModel.Name,
                    Comment = folderModel.Comment,
                    Attributes = folderModel.Attributes,
                    RefFolderId = folderModel.RefFolderId,
                    CreatedBy = userName,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = userName,
                    ModifiedOn = DateTime.Now,
                    IsDeleted = false,
                    AssnFolders =
                    {
                        new AssnFolder
                        {
                            ProjectId = folderModel.ProjectId,
                            CreatedBy = userName,
                            CreatedOn =  DateTime.Now,
                            ModifiedBy = userName,
                            ModifiedOn =  DateTime.Now
                        }
                    }
                };
                _context.Folders.Add(folder);
                await _context.SaveChangesAsync();
                if (folder.FolderId > 0)
                    return true;
                else
                    return false;
            }
            return true;
        }
        public async Task<int> GetRecentFolderId()
        {
           
                var folderId = await _context.Folders
                    .Where(f => (bool)!f.IsDeleted) // optional filter
                    .OrderByDescending(f => f.CreatedOn)
                    .Select(f => f.FolderId)
                    .FirstOrDefaultAsync();

                return folderId;
           
        }
        public List<SelectListItem> GetCategories(string[] categories, string[] referenceKeys = null)
        {
            var items = new List<SelectListItem>();

            var query = _context.LutDocumentCategories
                .Where(d => categories.Contains(d.Category) && !d.IsDeleted);

            if (referenceKeys != null && referenceKeys.Length > 0)
            {
                query = query.Where(d => referenceKeys.Contains(d.ReferenceKey));
            }

            var docCategories = query
                .OrderBy(d => d.Category)
                .ThenBy(d => d.SubCategory)
                .ToList();

            if (docCategories.Any())
            {
                SelectListGroup currentGroup = new();
                foreach (var dc in docCategories)
                {
                    string categoryTrim = dc.Category.Trim();
                    string subCategoryTrim = dc.SubCategory.Trim();

                    if (!string.Equals(currentGroup.Name, categoryTrim, StringComparison.OrdinalIgnoreCase))
                        currentGroup = new SelectListGroup { Name = categoryTrim };

                    items.Add(new SelectListItem
                    {
                        Value = dc.LutDocumentCategoryId.ToString(), // ✅ use ID here
                        Text = subCategoryTrim,                      // show SubCategory as label
                        Group = currentGroup
                    });
                }
            }

            return items;
        }

        public int GetProjectReference(int projectId)
        {
            return _context.Projects.Where(x => x.ProjectId == projectId).FirstOrDefault().RefProjectId;
        }


    }
}
