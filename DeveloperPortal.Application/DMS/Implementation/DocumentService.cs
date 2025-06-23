using DeveloperPortal.Application.Common;
using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.DMS;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.DMS.Implementation
{
    public class DocumentService: IDocumentService
    {
        private readonly IDocumentService _documentService;
        private readonly AAHREntities _context;
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;

        public DocumentService(IDocumentService documentService, AAHREntities context, IStoredProcedureExecutor storedProcedureExecutor)
        {
            _documentService = documentService;
            _context = context;
            _storedProcedureExecutor= storedProcedureExecutor;
        }

        public async Task<List<FileModel>> GetAllDocumentsBasedOnProjectId(int projectId)
        {
            List<DocumentModel> resultDocuments = new List<DocumentModel>();
            List<FileModel> fileModels = new List<FileModel>();
            FileModel fileModel = null;
            var projectIdParam = new SqlParameter("@ProjectID", projectId);

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
