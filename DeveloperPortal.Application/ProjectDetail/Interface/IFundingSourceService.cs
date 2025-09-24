using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Domain.FundingSource;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IFundingSourceService
    {
        Task<List<FundingSourceViewModel>> GetAllFundingSourceDoc(string caseId);
        Task<FundingSourceViewModel> GetFundingSourceById(int funDingSourceId);
        Task<bool> SaveDocumentForFundingSource(FundingSourceViewModel viewModel);
        Task<bool> DeleteFundingSource(int id);
        int? getLuDocumentCategoryId(string category, string subCategory);
    }
}
