using DeveloperPortal.Application.Common;
using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.DMS;
using Microsoft.Data.SqlClient;

namespace DeveloperPortal.Application.DMS.Implementation
{
    public class DocumentService: IDocumentService
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;

        public DocumentService( IStoredProcedureExecutor storedProcedureExecutor)
        {
            _storedProcedureExecutor= storedProcedureExecutor;
        }

        public async Task<List<FileModel>> GetAllDocumentsBasedOnProjectId(int caseId)
        {
            List<DocumentModel> resultDocuments = new List<DocumentModel>();
            List<FileModel> fileModels = new List<FileModel>();
            FileModel fileModel = null;
            var projectIdParam = new SqlParameter("ProjectID", caseId);

            resultDocuments = await _storedProcedureExecutor.ExecuteStoredProcAsync<DocumentModel>(
                                                    StoredProcedureNames.SP_uspGetDMSDocumentDetails,
                                                    projectIdParam);
            if(resultDocuments!=null && resultDocuments.Count>0)
            {
                foreach (var document in resultDocuments)
                {
                    fileModel = new FileModel();
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
    }
}
