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
using System.Data;
using static DeveloperPortal.DataAccess.Entity.Models.Generated.Case;
using static DeveloperPortal.DataAccess.Entity.ViewModels.CommentModel;

namespace DeveloperPortal.Application.DMS.Implementation
{
    public class DocumentService: IDocumentService
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private readonly IDocumentRepository _documentRepository;


        public DocumentService( IStoredProcedureExecutor storedProcedureExecutor, IDocumentRepository documentRepository)
        {
            _storedProcedureExecutor= storedProcedureExecutor;
            _documentRepository = documentRepository;
        }

        public async Task<FolderDetails> GetAllDocumentsBasedOnProjectId(int caseId)
        {
            List<DocumentModel> resultDocuments = new List<DocumentModel>();
            List< Domain.DMS.FileModel> fileModels = new List<Domain.DMS.FileModel>();
            Domain.DMS.FileModel fileModel = null;
            FolderDetails folderDetails = null;
            var projectIdParam = new SqlParameter("ProjectID", caseId);

            resultDocuments = await _storedProcedureExecutor.ExecuteStoredProcAsync<DocumentModel>(
                                                    StoredProcedureNames.SP_uspGetDMSDocumentDetails,
                                                    projectIdParam);
            if(resultDocuments!=null && resultDocuments.Count>0)
            {
                folderDetails = new FolderDetails();
                folderDetails.Name= resultDocuments[0].FolderName;
         
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
                folderDetails.Files = fileModels;
            }
            else
            {
                folderDetails = new FolderDetails();
            }
                return folderDetails;
        }
        public async Task<DocumentModel> SaveDocument(DocumentModel documentModel)
        {
          
            bool isSuccess = await _documentRepository.SaveDocument(documentModel);
            if (isSuccess)
            {
                return documentModel;
            }
            else
            {
                return new DocumentModel();
            }

        }
        public async Task<FolderModel> SaveFolder(FolderModel folderModel)
        {
            var username = "jhirpara";
            bool isSuccess = true;
            if(folderModel==null)
                return new FolderModel();
            else
            {
                isSuccess = await _documentRepository.SaveFolder(folderModel, username);
                if (isSuccess) 
                { 
                    return folderModel;
                }
                else
                {
                    return new FolderModel();
                }
            }
           
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
