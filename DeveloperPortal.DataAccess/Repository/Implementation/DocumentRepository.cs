using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Models.PlanReview;
using Microsoft.EntityFrameworkCore;
using static DeveloperPortal.DataAccess.Entity.ViewModels.CommentModel;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AAHREntities _context;

        public DocumentRepository(AAHREntities context)
        {
            _context = context;
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
                    document.OtherDocumentType = documentModel.OtherDocumentType;
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
                    OtherDocumentType = documentModel.OtherDocumentType,
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
                    },
                    AssnFolderDocuments =
                    {
                        new AssnFolderDocument
                        {
                            FolderId = documentModel.FolderId,
                            CreatedBy =  documentModel.CreatedBy,
                            CreatedOn =  DateTime.Now,
                            ModifiedBy =  documentModel.CreatedBy,
                            ModifiedOn =  DateTime.Now
                        }
                    }
                };
                _context.Documents.Add(document);
                await _context.SaveChangesAsync();
                documentModel.FolderId = document.DocumentId;
                if (documentModel.FolderId > 0)
                    return true;
                else 
                    return false;
            }
            return true;
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






    }
}
