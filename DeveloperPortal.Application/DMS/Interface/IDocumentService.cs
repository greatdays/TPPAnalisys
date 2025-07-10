using DeveloperPortal.DataAccess.Entity.Models.StoredProcedureModels;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Models.PlanReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.DMS.Interface
{
    public interface IDocumentService
    {
        Task<List<Domain.DMS.FileModel>> GetAllDocumentsBasedOnProjectId(int caseId);
        Task<DocumentModel> SaveDocument(DocumentModel documentModel);
        Task<FolderModel> SaveFolder(FolderModel folderModel);
        Task<List<FolderModel>> GetFolderDetails(int projectId);
        Task<List<FolderModel>> GetSubFolderDetails(int projectId, int parentFolderId);
        //Task<List<FolderTree>> GetFolderTree(int projectId);
    }
}
