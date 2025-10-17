using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.FundingSource;
using DeveloperPortal.Models.IDM;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Index.HPRtree;
using DeveloperPortal.Domain.DMS;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public interface IFundingSourceRepository
    {
        Task<List<FundingSourceViewModel>> GetFundingSourceByUsers(string referenceId, string userName, bool verified);

        Task<FundingSourceViewModel> GetFundingSourceById(int funDingSourceId);

        Task<bool> SaveDocumentForFundingSource(FundingSourceViewModel viewModel);

        Task<bool> DeleteFundingSource(int id , string modifiedBy);
        int? getLuDocumentCategoryId(string category, string subCategory);
        Document getDocumentById(int? id);
        Task<FundingSource> GetFundingSourcebyId(int id);
        bool IsContactVerified(int contactIdentifierID, int ProjectId);

    }
}
