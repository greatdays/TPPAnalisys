using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Models.PlanReview;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IDocumentRepository
    {
        Task<bool> SaveDocument(DocumentModel documentModel);
        Task<bool> SaveFolder(FolderModel folderModel, string userName);
        Task<int> GetRecentFolderId();
        Task<bool> DeleteDocument(int id);
        List<SelectListItem> GetCategories(string[] categories, string[] referenceKeys = null);
        int GetActualProjectId(int projectId);


    }
}
