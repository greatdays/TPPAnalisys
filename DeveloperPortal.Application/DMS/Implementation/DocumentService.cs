using DeveloperPortal.Application.Common;
using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Implementation;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Models.PlanReview;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static DeveloperPortal.DataAccess.Entity.Models.Generated.Case;
using static DeveloperPortal.DataAccess.Entity.ViewModels.CommentModel;

namespace DeveloperPortal.Application.DMS.Implementation
{
    public class DocumentService: IDocumentService
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private readonly AAHREntities _aAHREntitiesr;

        public DocumentService( IStoredProcedureExecutor storedProcedureExecutor, AAHREntities aAHREntities)
        {
            _storedProcedureExecutor= storedProcedureExecutor;
            _aAHREntitiesr = aAHREntities;
        }

        public async Task<List<Domain.DMS.FileModel>> GetAllDocumentsBasedOnProjectId(int caseId)
        {
            List<DocumentModel> resultDocuments = new List<DocumentModel>();
            List< Domain.DMS.FileModel> fileModels = new List<Domain.DMS.FileModel>();
            Domain.DMS.FileModel fileModel = null;
            var projectIdParam = new SqlParameter("ProjectID", caseId);

            resultDocuments = await _storedProcedureExecutor.ExecuteStoredProcAsync<DocumentModel>(
                                                    StoredProcedureNames.SP_uspGetDMSDocumentDetails,
                                                    projectIdParam);
            if(resultDocuments!=null && resultDocuments.Count>0)
            {
                foreach (var document in resultDocuments)
                {
                    fileModel = new Domain.DMS.FileModel();
                    fileModel.ID = Convert.ToString(document.DocumentId);
                    fileModel.Roles = "NAC";
                    fileModel.UploadedDate = document.CreatedOn;
                    fileModel.Name = document.Name;
                    fileModel.UploadedBy = document.CreatedBy;
                    fileModel.Category = document.OtherDocumentType;
                    fileModel.Link = document.Link;

                    fileModels.Add(fileModel);
                }
            }
            return fileModels;
        }
        public async Task<DocumentModel> SaveDocument(DocumentModel documentModel)
        {
            //AAHREntities _context = new AAHREntities();
            var username = documentModel.CreatedBy;
            if (documentModel == null)
            {
                return documentModel;
            }
            if (documentModel.DocumentId > 0)
            {
                var document = _aAHREntitiesr.Documents.FirstOrDefault(x => x.DocumentId == documentModel.DocumentId);
                if (document != null)
                {
                    document.Name = documentModel.Name;
                    document.Link = documentModel.Link;
                    document.FileSize = documentModel.FileSize;
                    document.OtherDocumentType = documentModel.OtherDocumentType;
                    document.Comment = documentModel.Comment;
                    document.Attributes = documentModel.Attributes;
                    document.CreatedBy = username;
                    document.CreatedOn = DateTime.Now;
                    document.ModifiedBy = username;
                    document.ModifiedOn = DateTime.Now;
                    _aAHREntitiesr.SaveChanges(username);
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
                    CreatedBy = username,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = username,
                    ModifiedOn = DateTime.Now,
                    IsDeleted = false,
                    AssnDocuments =
                    {
                        new AssnDocument
                        {
                            ReferenceId = documentModel.CaseId.ToString(),
                            ReferenceType = ReferenceType.Case.ToString(),
                            CreatedBy = username,
                            CreatedOn =  DateTime.Now,
                            ModifiedBy = username,
                            ModifiedOn =  DateTime.Now
                        }
                    },
                    AssnFolderDocuments =
                    {
                        new AssnFolderDocument
                        {
                            FolderId = documentModel.FolderId,
                            CreatedBy = username,
                            CreatedOn =  DateTime.Now,
                            ModifiedBy = username,
                            ModifiedOn =  DateTime.Now
                        }
                    }
                };
                _aAHREntitiesr.Documents.Add(document);
                await _aAHREntitiesr.SaveChangesAsync();
                documentModel.FolderId = document.DocumentId;
            }
            return documentModel;
        }
        public async Task<FolderModel> SaveFolder(FolderModel folderModel)
        {
            var username = "jhirpara";
            //AAHREntities _context = new AAHREntities();
            
            if (folderModel == null)
            {
                return folderModel;
            }
            if (folderModel.FolderId > 0)
            {
                var folder = _aAHREntitiesr.Folders.FirstOrDefault(x => x.FolderId == folderModel.FolderId);
                if (folder != null)
                {
                    folder.Name = folderModel.Name;
                    folder.Comment = folderModel.Comment;
                    folder.Attributes = folderModel.Attributes;
                    folder.ModifiedBy = username;
                    folder.ModifiedOn = DateTime.Now;
                    _aAHREntitiesr.SaveChanges(username);
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
                    CreatedBy = username,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = username,
                    ModifiedOn = DateTime.Now,
                    IsDeleted = false,
                    AssnFolders =
                    {
                        new AssnFolder
                        {
                            ProjectId = folderModel.ProjectId,
                            CreatedBy = username,
                            CreatedOn =  DateTime.Now,
                            ModifiedBy = username,
                            ModifiedOn =  DateTime.Now
                        }
                    }
                };
                _aAHREntitiesr.Folders.Add(folder);
                await _aAHREntitiesr.SaveChangesAsync();
                folderModel.FolderId = folder.FolderId;
            }
            return folderModel;
        }
        public async Task<List<FolderModel>> GetFolderDetails(int projectId)
        {
            var projectIdParam = new SqlParameter("ProjectId", projectId);
            List<FolderModel> folderList = await _storedProcedureExecutor.ExecuteStoredProcAsync<FolderModel>(StoredProcedureNames.SP_uspGetDMSFolderDetails, projectIdParam);
            return folderList;
        }

        public async Task<List<FolderModel>> GetSubFolderDetails(int projectId, int parentFolderId)
        {
            var projectIdParam = new SqlParameter("ProjectId", projectId);
            var parentFolderIdParam = new SqlParameter("ParentFolderId", parentFolderId);
            List<FolderModel> folderList = await _storedProcedureExecutor.ExecuteStoredProcAsync<FolderModel>(StoredProcedureNames.SP_uspGetDMSFolderDetails, projectIdParam, parentFolderIdParam);
            return folderList;

        }
    }
}
