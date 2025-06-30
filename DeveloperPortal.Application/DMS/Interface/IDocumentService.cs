using DeveloperPortal.DataAccess.Entity.Models.StoredProcedureModels;
using DeveloperPortal.Domain.DMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.DMS.Interface
{
    public interface IDocumentService
    {
        Task<List<FileModel>> GetAllDocumentsBasedOnProjectId(int caseId);
    }
}
